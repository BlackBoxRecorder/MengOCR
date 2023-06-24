﻿using MengOCR.Forms;
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
        private readonly FileSystemWatcher FsWatcher = new FileSystemWatcher();
        private readonly PaddleOCREngine engine;
        private ScreenSnap snapForm;
        private Bitmap curBitmap;
        private readonly string SnapSaveDir = "";

        private bool spaceSeparate = false;

        public MainForm()
        {
            InitializeComponent();

            //使用默认中英文V3模型
            OCRModelConfig config = null;
            //使用默认参数
            OCRParameter oCRParameter = new OCRParameter();
            //识别结果对象
            //建议程序全局初始化一次即可，不必每次识别都初始化，容易报错。     
            engine = new PaddleOCREngine(config, oCRParameter);

            var userPicDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            SnapSaveDir = Path.Combine(userPicDir, "MengOCR");

            if (!Directory.Exists(SnapSaveDir))
            {
                Directory.CreateDirectory(SnapSaveDir);
            }

            OnFsChanges();

            Task.Run(async () =>
            {
                await StoreData.Instance.InitWorkspace();
                await StoreData.Instance.SyncWorkspace(SnapSaveDir);
            });


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
                    Console.WriteLine(ex.Message);
                    success++;
                }
            } while (0 < success && success < 5);

            return result;
        }

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
        private void ReloadWorkspace()
        {
            try
            {
                var spaces = StoreData.Instance.GetWorkspaceAsync();

                CmbWorkspace.Items.Clear();

                foreach (var item in spaces)
                {
                    CmbWorkspace.Items.Add(item.Name);
                }

                if (CmbWorkspace.Items.Count > 0)
                {
                    CmbWorkspace.SelectedIndex = 0;
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

        #region 事件

        private void MainForm_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                NotifyIconOCR.Visible = false;
                ListBoxImgFiles.DisplayMember = "ImgFileName";
                ListBoxImgFiles.ValueMember = "ImgFileName";

                ReloadWorkspace();
                ReloadFileList();

                var k_hook = new KeyboardHook();
                k_hook.KeyDownEvent += new KeyEventHandler(Hook_KeyDown);//钩住键按下
                k_hook.Start();//安装键盘钩子

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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


        #endregion

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                NotifyIconOCR.Visible = true;
                ShowInTaskbar = false;
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
            try
            {
                var txt = TxtOCRResult.Text;
                if (txt.Length > 1)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(txt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
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

        }

        private void ListBoxImgFiles_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Right || ListBoxImgFiles.SelectedIndex < 0)
                {
                    return;
                }

                MenuFileList.Show(ListBoxImgFiles, new Point(e.X, e.Y));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.Dispose();

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
            try
            {
                var inputform = new InputForm();
                inputform.ShowDialog(this);
                var newspace = inputform.NewValue;

                await StoreData.Instance.AddWorkspaceAsync(newspace);

                ReloadWorkspace();

            }
            catch (Exception ex)
            {

            }
        }

        private void MenuRenameWorkSpace_Click(object sender, EventArgs e)
        {
            try
            {

                var space = GetSelectedWorkspace();

                var source = Path.Combine(SnapSaveDir, space);

                //修改目录名称


                //修改Store中的工作区名称


                //重新加载工作区
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
    }
}
