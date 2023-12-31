﻿using MengOCR.Forms;
using NLog;
using PaddleOCRSharp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace MengOCR
{
    public partial class MainForm : Form
    {
        public static readonly Logger logger = LogManager.GetLogger("MainForm");

        private PaddleOCREngine engine;
        private ScreenSnap snapForm;
        private Bitmap curBitmap;
        private string snapSaveDir = "";
        private readonly KeyboardHook k_hook = new KeyboardHook();
        private string keyBinding = "";
        private bool spaceSeparate = false;
        private bool isExit = false;
        private bool isShowMain = false;


        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitOCR()
        {
            Task.Run(() =>
            {
                OCRModelConfig config = null;
                OCRParameter oCRParameter = new OCRParameter();
                engine = new PaddleOCREngine(config, oCRParameter);
            });
        }

        private string RunOCR(Image img)
        {
            int success = 0;
            string result = "";
            do
            {
                try
                {
                    var ocrResult = engine.DetectStructure(img) ??
                        throw new Exception("识别出错了！！！");

                    result = Utils.Structure2String(ocrResult, spaceSeparate);
                    TxtOCRResult.Text = result;

                    return result;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    success++;
                }
            } while (0 < success && success < 5);

            return result;
        }

        /// <summary>
        /// 截取整个屏幕图像
        /// </summary>
        /// <returns></returns>
        public Bitmap GetScreen()
        {
            //获取整个屏幕图像,不包括任务栏
            Rectangle ScreenArea = Screen.GetBounds(this);
            Bitmap bmp = new Bitmap(ScreenArea.Width, ScreenArea.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(ScreenArea.Width, ScreenArea.Height));
            }
            return bmp;
        }

        private void TakeSnapshot()
        {
            try
            {
                this.Visible = false;
                Thread.Sleep(200);

                this.curBitmap = GetScreen();
                snapForm = new ScreenSnap();
                snapForm.ScreenShotOk += new EventHandler(ScreenShotOk_Click);

                snapForm.BackgroundImage = this.curBitmap;
                snapForm.StartPosition = FormStartPosition.Manual;//起始位置
                snapForm.ShowDialog();
                snapForm.ScreenShotOk -= new EventHandler(ScreenShotOk_Click);
                snapForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ScreenShotOk_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(snapForm.End.X - snapForm.Start.X,
                    snapForm.End.Y - snapForm.Start.Y);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    int w = snapForm.End.X - snapForm.Start.X;
                    int h = snapForm.End.Y - snapForm.Start.Y;
                    //在画布上要显示的区域（记得像素加1）
                    Rectangle destRect = new Rectangle(0, 0, w + 1, h + 1);
                    //图像上要截取的区域
                    Rectangle srcRect = new Rectangle(snapForm.Start.X, snapForm.Start.Y, w + 1, h + 1);
                    //加图像绘制到画布上
                    g.DrawImage(curBitmap, destRect, srcRect, GraphicsUnit.Pixel);
                }

                var txt = this.RunOCR(bmp);
                this.TxtOCRResult.Text = txt;

                //保存图片
                var filename = $"{DateTime.Now.ToLocalTime().ToString().Replace('/', '-').Replace(':', '.')}.png";
                var idx = CmbWorkspace.SelectedIndex;
                var space = CmbWorkspace.Items[idx].ToString();

                var spaceDir = Path.Combine(snapSaveDir, space);
                if (!Directory.Exists(spaceDir))
                {
                    Directory.CreateDirectory(spaceDir);
                }

                var imgFilename = Path.Combine(spaceDir, filename);
                bmp.Save(imgFilename, System.Drawing.Imaging.ImageFormat.Png);

                this.PicBoxSnap.ImageLocation = imgFilename;

                var item = new OcrDataItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreateTime = DateTime.Now,
                    ContentTxt = txt,
                    ImgFileName = filename,
                    WorkspaceName = space,
                };

                ListBoxImgFiles.Items.Add(item);

                await StoreData.Instance.AddOCRItemAsync(item);

                if (isShowMain)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                    this.StartPosition = FormStartPosition.CenterScreen;
                    this.Visible = true;
                }
                else
                {
                    NotifyIconOCR.ShowBalloonTip(1000, "提示", "截图完成", ToolTipIcon.Info);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ImgPreview()
        {
            try
            {
                var w = PicBoxSnap.Width;
                var h = PicBoxSnap.Height;

                var iw = PicBoxSnap.Image.Height;
                var ih = PicBoxSnap.Image.Width;

                if (iw > w || ih > h)
                {//图片比窗口大
                    PicBoxSnap.SizeMode = PictureBoxSizeMode.Zoom;
                    Console.WriteLine("图片比窗口大");
                }
                else
                {//图片比窗口小
                    PicBoxSnap.SizeMode = PictureBoxSizeMode.CenterImage;
                    Console.WriteLine("图片比窗口小");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 从store重新加载工作区到下拉列表
        /// </summary>
        private void ReloadWorkspace(string selectedSpace = "")
        {
            try
            {
                var spaces = StoreData.Instance.GetWorkspaceAsync();

                CmbWorkspace.Items.Clear();

                foreach (var item in spaces)
                {
                    CmbWorkspace.Items.Add(item.Name);
                }


                if (CmbWorkspace.Items.Count > 0 && !CmbWorkspace.Items.Contains(selectedSpace))
                {
                    CmbWorkspace.SelectedIndex = 0;
                }
                else
                {
                    var idx = CmbWorkspace.Items.IndexOf(selectedSpace);
                    CmbWorkspace.SelectedIndex = idx;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 重新加载文件列表
        /// 切换工作区后, 删除文件后
        /// </summary>
        private void ReloadFileList()
        {
            try
            {
                var space = GetSelectedWorkspace();
                //从StoreData读取数据源
                var all = StoreData.Instance.GetOCRItemsByWorkspace(space);
                ListBoxImgFiles.Items.Clear();
                foreach (var item in all)
                {
                    ListBoxImgFiles.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetSelectedWorkspace()
        {
            var idx = CmbWorkspace.SelectedIndex;
            if (idx == -1)
            {
                return "默认工作区";
            }
            var spaceDir = CmbWorkspace.Items[idx].ToString();
            return spaceDir;
        }

        /// <summary>
        /// 选择一个存储目录，重建store
        /// </summary>
        private void ReBuildStore()
        {
            Task.Run(async () =>
            {
                await StoreData.Instance.ClearStore();
                await StoreData.Instance.InitWorkspace();
                await StoreData.Instance.SyncWorkspace(snapSaveDir);

                var allItems = StoreData.Instance.GetAllOCRItems();

                foreach (var item in allItems)
                {
                    var filepath = Path.Combine(snapSaveDir, item.WorkspaceName, item.ImgFileName);
                    if (!File.Exists(filepath))
                    {
                        throw new FileNotFoundException(filepath);
                    }
                    var img = Image.FromFile(filepath);
                    var ocrResult = engine.DetectStructure(img as System.Drawing.Image) ??
                        throw new Exception("识别出错了！！！");

                    var result = Utils.Structure2String(ocrResult, spaceSeparate);

                    item.ContentTxt = result;

                    await StoreData.Instance.UpdateOCRItemAsync(item);
                }

            });
        }

        private async void MainForm_LoadAsync(object sender, EventArgs e)
        {
            InitOCR();

            StoreData.Instance.InitConfig();

            snapSaveDir = StoreData.Instance.GetKeyVal<string>(StoreKeys.SnapSaveDir);
            keyBinding = StoreData.Instance.GetKeyVal<string>(StoreKeys.KeyBingding);
            isExit = StoreData.Instance.GetKeyVal<bool>(StoreKeys.CloseExit);
            isShowMain = StoreData.Instance.GetKeyVal<bool>(StoreKeys.SnapShowMain);

            if (!Directory.Exists(snapSaveDir))
            {
                Directory.CreateDirectory(snapSaveDir);
            }

            ListBoxImgFiles.DisplayMember = "ImgFileName";
            ListBoxImgFiles.ValueMember = "ImgFileName";

            await StoreData.Instance.InitWorkspace();

            ReloadWorkspace();
            ReloadFileList();

            k_hook.KeyDownEvent += new KeyEventHandler(Hook_KeyDown);//钩住键按下
            k_hook.Start();//安装键盘钩子

            NotifyIconOCR.Visible = true;
            NotifyIconOCR.ContextMenuStrip = IconMenu;

        }


        private void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape &&
                (snapForm.WindowState == FormWindowState.Maximized ||
                !snapForm.IsDisposed ||
                snapForm.TopMost))
            {
                snapForm.Close();
                snapForm.Dispose();
                return;
            }


            if (string.IsNullOrEmpty(keyBinding) || !keyBinding.Contains("+"))
            {
                return;
            }

            var mkey = keyBinding.Split('+')[0];
            var key = keyBinding.Split('+')[1];

            if (e.KeyCode.ToString() == key && Control.ModifierKeys.ToString() == mkey)
            {
                TakeSnapshot();
                logger.Info($"{DateTime.Now} : 快捷键截图");
            }
        }


        private void NotifyIconOCR_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;//窗口正常显示
            this.ShowInTaskbar = true;//在任务栏中显示该窗口
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

        }

        private void BtnSnapshot_Click(object sender, EventArgs e)
        {
            TakeSnapshot();
        }

        private void BtnCopyResult_Click(object sender, EventArgs e)
        {
            var txt = TxtOCRResult.Text;
            if (txt.Length > 1)
            {
                Clipboard.Clear();
                Clipboard.SetText(txt);
            }
        }

        private void BtnRunOCR_Click(object sender, EventArgs e)
        {
            try
            {
                var txt = RunOCR(PicBoxSnap.Image);
                if (!string.IsNullOrEmpty(txt))
                {
                    TxtOCRResult.Text = txt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var keyword = TxtKeyword.Text;
            if (string.IsNullOrEmpty(keyword))
            {
                return;
            }

            var items = StoreData.Instance.SearchAsync(keyword);
            CmbWorkspace.SelectedIndex = -1;
            ListBoxImgFiles.Items.Clear();
            foreach (var item in items)
            {
                ListBoxImgFiles.Items.Add(item);
            }
        }

        private void ListBoxImgFiles_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || ListBoxImgFiles.SelectedIndex < 0)
            {
                return;
            }

            MenuFileList.Show(ListBoxImgFiles, new Point(e.X, e.Y));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (isExit)
                {
                    engine.Dispose();
                    k_hook.KeyDownEvent -= new KeyEventHandler(Hook_KeyDown);
                    k_hook.Stop();
                    NotifyIconOCR.Visible = false;
                }
                else
                {
                    if (e.CloseReason == CloseReason.UserClosing)
                    {
                        //是否取消close操作
                        e.Cancel = true;
                        //this.WindowState = FormWindowState.Minimized;
                        this.Visible = false;
                        //图标显示在托盘区
                        NotifyIconOCR.Visible = true;
                        //NotifyIconOCR.ShowBalloonTip(2000, "提示", "双击图标显示主窗口", ToolTipIcon.Info);

                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

        }

        private void ListBoxImgFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //切换图片列表，同时切换图片
                if (ListBoxImgFiles.SelectedIndex < 0)
                {
                    return;
                }
                if (!(ListBoxImgFiles.SelectedItem is OcrDataItem ocr)) { return; }
                string imgPath = Path.Combine(snapSaveDir, ocr.WorkspaceName, ocr.ImgFileName);

                TxtOCRResult.Text = ocr.ContentTxt;

                if (File.Exists(imgPath))
                {
                    PicBoxSnap.ImageLocation = imgPath;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CmbWorkspace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbWorkspace.SelectedIndex < 0)
            {
                return;
            }
            ReloadFileList();
        }

        private void PicBoxSnap_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ImgPreview();
        }

        private void BtnStateSpaceSeparate_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


        }

        private void BtnStateSpaceEnable_Click(object sender, EventArgs e)
        {
            BtnStateSpaceDisable.Checked = false;
            BtnStateSpaceDisable.CheckState = CheckState.Unchecked;
            BtnStateSpaceEnable.Checked = true;
            BtnStateSpaceEnable.CheckState = CheckState.Checked;

            spaceSeparate = true;
        }

        private void BtnStateSpaceDisable_Click(object sender, EventArgs e)
        {
            BtnStateSpaceDisable.Checked = true;
            BtnStateSpaceDisable.CheckState = CheckState.Checked;
            BtnStateSpaceEnable.Checked = false;
            BtnStateSpaceEnable.CheckState = CheckState.Unchecked;

            spaceSeparate = false;
        }

        private async void MenuNewWorkspace_Click(object sender, EventArgs e)
        {
            var inputform = new InputForm();
            inputform.Text = "添加工作区";
            inputform.ShowDialog(this);
            var newspace = inputform.NewValue;
            if (string.IsNullOrEmpty(newspace))
            {
                return;
            }
            await StoreData.Instance.AddWorkspaceAsync(newspace);

            ReloadWorkspace(newspace);
        }

        private async void MenuRenameWorkSpace_Click(object sender, EventArgs e)
        {
            try
            {
                var space = GetSelectedWorkspace();

                var source = Path.Combine(snapSaveDir, space);
                var form = new InputForm();
                form.Text = "工作区重命名";
                form.OldValue = space;
                form.ShowDialog(this);
                var newspace = form.NewValue;
                if (string.IsNullOrEmpty(newspace))
                {
                    return;
                }
                var dist = Path.Combine(snapSaveDir, newspace);
                //修改目录名称
                if (Directory.Exists(source))
                {
                    Directory.Move(source, dist);
                }

                //修改Store中的工作区名称

                var items = StoreData.Instance.GetOCRItemsByWorkspace(space);

                foreach (var item in items)
                {
                    item.WorkspaceName = newspace;
                    await StoreData.Instance.UpdateOCRItemAsync(item);
                }

                StoreData.Instance.DeleteWorkspaceAsync(space);
                await StoreData.Instance.AddWorkspaceAsync(newspace);
                //重新加载工作区
                ReloadWorkspace(newspace);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuDelWorkspace_Click(object sender, EventArgs e)
        {
            try
            {
                var space = GetSelectedWorkspace();
                var res = MessageBox.Show($"是否删除工作区：{space}", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    //删除Store
                    StoreData.Instance.DeleteWorkspaceAsync(space);

                    //删除工作区目录
                    var dir = Path.Combine(snapSaveDir, space);
                    if (Directory.Exists(dir))
                    {
                        Directory.Delete(dir, true);
                    }

                    //重新加载工作区
                    ReloadWorkspace();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void MenuFileRename_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBoxImgFiles.SelectedItem is OcrDataItem item)
                {
                    var oldname = item.ImgFileName;
                    //重命名窗体
                    var form = new InputForm();
                    form.Text = "文件重命名";
                    form.OldValue = oldname;
                    form.ShowDialog(this);
                    var newname = form.NewValue;
                    if (string.IsNullOrEmpty(newname))
                    {
                        return;
                    }

                    item.ImgFileName = newname;

                    //更新store
                    await StoreData.Instance.UpdateOCRItemAsync(item);
                    //更新文件名
                    var source = Path.Combine(snapSaveDir, item.WorkspaceName, oldname);
                    var dist = Path.Combine(snapSaveDir, item.WorkspaceName, newname);

                    if (File.Exists(source))
                    {
                        File.Move(source, dist);
                    }
                    //重新加载文件列表
                    ReloadFileList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void MenuFileDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBoxImgFiles.SelectedItem is OcrDataItem item)
                {
                    //删除store
                    await StoreData.Instance.DeleteOCRItemAsync(item.Id);
                    //删除文件

                    var file = Path.Combine(snapSaveDir, item.WorkspaceName, item.ImgFileName);
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                    //重新加载文件列表
                    ReloadFileList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuConfig_Click(object sender, EventArgs e)
        {
            var form = new ConfigForm();
            form.RebuildStoreClick += Form_RebuildStoreClick;
            form.ShowDialog(this);
            form.RebuildStoreClick -= Form_RebuildStoreClick;

            isExit = StoreData.Instance.GetKeyVal<bool>(StoreKeys.CloseExit);
            isShowMain = StoreData.Instance.GetKeyVal<bool>(StoreKeys.SnapShowMain);
        }

        private void Form_RebuildStoreClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("是否重建缓存？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                ReBuildStore();
            }
        }

        private void BtnIconMenuExit_Click(object sender, EventArgs e)
        {
            isExit = true;
            Close();
        }

        private void BtnExportPdf_Click(object sender, EventArgs e)
        {
            var exportform = new ExportPdfForm();
            exportform.ShowDialog(this);
        }

    }
}
