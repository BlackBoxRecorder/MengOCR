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
using static ReaLTaiizor.Drawing.Poison.PoisonPaint.ForeColor;
using static System.Net.Mime.MediaTypeNames;

namespace MengOCR
{

    public partial class MainForm : Form
    {
        private readonly FileSystemWatcher FsWatcher = new FileSystemWatcher();
        private readonly PaddleOCREngine engine;
        private ScreenSnap snapForm;
        private Bitmap curBitmap;

        private readonly string SnapSaveDir = "";

        private readonly List<string> ImgFileList = new List<string>();

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
        }

        private void BtnSnapshot_Click(object sender, EventArgs e)
        {
            TakeSnapshot();
        }

        /// <summary>
        /// 初始化文件变化监听
        /// </summary>
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

                    UpdateImgListBox(fi.Name);

                }));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateImgListBox(string item)
        {
            UListImagesFiles.Items.Insert(0, item);
            StatTotalFileNum.Text = $"共{UListImagesFiles.Items.Count}个图片";
        }

        private string RunOCR<T>(T img)
        {
            int success = 0;
            string result = "";
            do
            {
                try
                {
                    if (typeof(T) == typeof(string))
                    {
                        OCRResult ocrResult = engine.DetectText(img as string) ??
                            throw new Exception("识别出错了！！！");
                        result = ocrResult.Text;
                    }
                    else if (typeof(T) == typeof(System.Drawing.Image))
                    {
                        OCRResult ocrResult = engine.DetectText(img as System.Drawing.Image) ??
                            throw new Exception("识别出错了！！！");
                        result = ocrResult.Text;
                    }
                    else
                    {
                        result = "出错了！！！";
                    }

                    StatWordCount.Text = $"共识别{result.Length}个字";

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

        private void NotifyIconOCR_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;//窗口正常显示
            this.ShowInTaskbar = true;//在任务栏中显示该窗口
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                NotifyIconOCR.Visible = false;
                StatTotalFileNum.Text = string.Empty;
                StatWordCount.Text = string.Empty;

                UListImagesFiles.Items.Clear();
                var files = Directory.GetFiles(SnapSaveDir).ToList();
                foreach (var file in files)
                {
                    ImgFileList.Add(file);

                    var fi = new FileInfo(file);
                    UpdateImgListBox(fi.Name);

                }

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
            //判断按下的键（Alt + A）
            if (e.KeyValue == (int)Keys.X && (int)Control.ModifierKeys == (int)Keys.Alt)
            {
                //截图
                TakeSnapshot();
                Console.WriteLine($"{DateTime.Now} : 截图");
            }
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

        private void ScreenShotOk_Click(object sender, EventArgs e)
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
            this.PictureSnaped.Image = bmp;

            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
            var txt = this.RunOCR(this.PictureSnaped.Image);
            this.UTextOCRResult.Text = txt;

            //保存图片
            var filename = $"{DateTime.Now.ToLocalTime().ToString().Replace('/', '-').Replace(':', '.')}.png";
            var imgFilename = Path.Combine(SnapSaveDir, filename);
            bmp.Save(imgFilename, System.Drawing.Imaging.ImageFormat.Png);

            ImgFileList.Add(filename);

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

        private void BtnCopyResultText_Click(object sender, EventArgs e)
        {
            try
            {
                var txt = UTextOCRResult.Text;
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

                var txt = RunOCR<System.Drawing.Image>(PictureSnaped.Image);

                if (!string.IsNullOrEmpty(txt))
                {
                    UTextOCRResult.Text = txt;
                }

            }
            catch (Exception)
            {

            }
        }

        private void UListImagesFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //切换图片列表，同时切换图片
                if (UListImagesFiles.SelectedIndex < 0)
                {
                    return;
                }
                string filename = UListImagesFiles.SelectedItem.ToString();
                string imgPath = Path.Combine(SnapSaveDir, filename);

                if (File.Exists(imgPath))
                {
                    PictureSnaped.ImageLocation = imgPath;
                }

            }
            catch (Exception)
            {

            }
        }

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


        private void ImgPreview()
        {
            try
            {
                var w = PictureSnaped.Width;
                var h = PictureSnaped.Height;

                var iw = PictureSnaped.Image.Height;
                var ih = PictureSnaped.Image.Width;

                if (iw > w || ih > h)
                {//图片比窗口大
                    PictureSnaped.SizeMode = PictureBoxSizeMode.Zoom;
                    Console.WriteLine("图片比窗口大");
                }
                else
                {//图片比窗口小
                    PictureSnaped.SizeMode = PictureBoxSizeMode.CenterImage;
                    Console.WriteLine("图片比窗口小");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PictureSnaped_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ImgPreview();

        }

        private void UListImagesFiles_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Right)
                {
                    return;
                }

                HFileListMenu.Show(UListImagesFiles, new Point(e.X, e.Y));



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void HMenuRename_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = UListImagesFiles.SelectedItem.ToString();

                var file = Path.Combine(SnapSaveDir, selected);
                if (File.Exists(file))
                {
                    //TODO 重命名窗口
                    //var newname = "";
                    if (false)
                    {
                        //File.Move(file, newname);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void HMenuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = UListImagesFiles.SelectedItem.ToString();

                var file = Path.Combine(SnapSaveDir, selected);
                if (File.Exists(file))
                {
                    var res = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                    {
                        File.Delete(file);
                        //TODO 更新文件列表
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void UMainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                HMainMenu.Show(this, new Point(e.X, e.Y));
            }
        }
    }
}
