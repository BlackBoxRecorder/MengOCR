using MengOCR.Forms;
using NLog;
using PaddleOCRSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MengOCR
{
    public partial class MainForm : Form
    {
        public static readonly Logger logger = LogManager.GetLogger("MainForm");


        private readonly FileSystemWatcher FsWatcher = new FileSystemWatcher();
        private readonly PaddleOCREngine engine;
        private ScreenSnap snapForm;
        private Bitmap curBitmap;
        private readonly string SnapSaveDir = "";
        private readonly KeyboardHook k_hook = new KeyboardHook();

        private bool spaceSeparate = false;




        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            //使用默认中英文V3模型
            OCRModelConfig config = null;
            //使用默认参数
            OCRParameter oCRParameter = new OCRParameter();
            //识别结果对象
            //建议程序全局初始化一次即可，不必每次识别都初始化，容易报错。     
            engine = new PaddleOCREngine(config, oCRParameter);

            SnapSaveDir = StoreData.Instance.GetKeyVal<string>("snapSaveDir");

            if (string.IsNullOrEmpty(SnapSaveDir))
            {//没有设置路径，设为默认
                var userPicDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                SnapSaveDir = Path.Combine(userPicDir, "MengOCR");

                StoreData.Instance.SetKeyVal<string>("snapSaveDir", SnapSaveDir);
            }
            else
            {

            }

            if (!Directory.Exists(SnapSaveDir))
            {
                Directory.CreateDirectory(SnapSaveDir);
            }

            OnFsChanges();
        }

        private void OnFsChanges()
        {
            FsWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            FsWatcher.IncludeSubdirectories = true;
            FsWatcher.Path = SnapSaveDir;
            FsWatcher.Created += new FileSystemEventHandler(FsWatcher_Created);
            FsWatcher.EnableRaisingEvents = true;
        }

        private void FsWatcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                string newImgPath = e.FullPath;
                if (!Utils.IsImageFile(newImgPath)) return;
                this.BeginInvoke(new EventHandler(delegate
                {
                    FileInfo fi = new FileInfo(newImgPath);
                }));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string RunOCR(Image img)
        {
            int success = 0;
            string result = "";
            do
            {
                try
                {
                    var ocrResult = engine.DetectStructure(img as System.Drawing.Image) ??
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
                this.Hide();//隐藏当前
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
                Bitmap bmp = new Bitmap(snapForm.End.X - snapForm.Start.X, snapForm.End.Y - snapForm.Start.Y);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    int w = snapForm.End.X - snapForm.Start.X;
                    int h = snapForm.End.Y - snapForm.Start.Y;
                    Rectangle destRect = new Rectangle(0, 0, w + 1, h + 1);//在画布上要显示的区域（记得像素加1）
                    Rectangle srcRect = new Rectangle(snapForm.Start.X, snapForm.Start.Y, w + 1, h + 1);//图像上要截取的区域
                    g.DrawImage(curBitmap, destRect, srcRect, GraphicsUnit.Pixel);//加图像绘制到画布上
                }
                this.PicBoxSnap.Image = bmp;

                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Show();
                var txt = this.RunOCR(bmp);
                this.TxtOCRResult.Text = txt;

                //保存图片
                var filename = $"{DateTime.Now.ToLocalTime().ToString().Replace('/', '-').Replace(':', '.')}.png";
                var idx = CmbWorkspace.SelectedIndex;
                var space = CmbWorkspace.Items[idx].ToString();

                var spaceDir = Path.Combine(SnapSaveDir, space);
                if (!Directory.Exists(spaceDir))
                {
                    Directory.CreateDirectory(spaceDir);
                }

                var imgFilename = Path.Combine(spaceDir, filename);
                bmp.Save(imgFilename, System.Drawing.Imaging.ImageFormat.Png);

                var item = new OcrDataItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreateTime = DateTime.Now,
                    ContentTxt = txt,
                    ImgFileName = filename,
                    WorkspaceName = space,
                };

                ListBoxImgFiles.Items.Insert(0, item);

                await StoreData.Instance.AddOCRItemAsync(item);
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
                await StoreData.Instance.SyncWorkspace(SnapSaveDir);

                var allItems = StoreData.Instance.GetAllOCRItems();

                foreach (var item in allItems)
                {
                    var filepath = Path.Combine(SnapSaveDir, item.WorkspaceName, item.ImgFileName);
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

        private void MainForm_LoadAsync(object sender, EventArgs e)
        {

            NotifyIconOCR.Visible = false;
            ListBoxImgFiles.DisplayMember = "ImgFileName";
            ListBoxImgFiles.ValueMember = "ImgFileName";

            ReloadWorkspace();
            ReloadFileList();

            k_hook.KeyDownEvent += new KeyEventHandler(Hook_KeyDown);//钩住键按下
            k_hook.Start();//安装键盘钩子
        }


        private void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            //判断按下的键（Alt + X）
            if (e.KeyValue == (int)Keys.X && (int)Control.ModifierKeys == (int)Keys.Alt)
            {
                //截图
                TakeSnapshot();
                Console.WriteLine($"{DateTime.Now} : 截图");
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
            if (this.WindowState == FormWindowState.Minimized)
            {
                NotifyIconOCR.Visible = true;
                //ShowInTaskbar = false;
            }
            else
            {
                NotifyIconOCR.Visible = false;
            }
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
                engine.Dispose();
                k_hook.KeyDownEvent -= new KeyEventHandler(Hook_KeyDown);
                k_hook.Stop();
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
                string imgPath = Path.Combine(SnapSaveDir, ocr.WorkspaceName, ocr.ImgFileName);

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

                var source = Path.Combine(SnapSaveDir, space);
                var form = new InputForm();
                form.Text = "工作区重命名";
                form.OldValue = space;
                form.ShowDialog(this);
                var newspace = form.NewValue;
                if (string.IsNullOrEmpty(newspace))
                {
                    return;
                }
                var dist = Path.Combine(SnapSaveDir, newspace);
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
                    var dir = Path.Combine(SnapSaveDir, space);
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
                    var source = Path.Combine(SnapSaveDir, item.WorkspaceName, oldname);
                    var dist = Path.Combine(SnapSaveDir, item.WorkspaceName, newname);

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

                    var file = Path.Combine(SnapSaveDir, item.WorkspaceName, item.ImgFileName);
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

        }

        private void Form_RebuildStoreClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("是否重建缓存？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                ReBuildStore();
            }
        }
    }
}
