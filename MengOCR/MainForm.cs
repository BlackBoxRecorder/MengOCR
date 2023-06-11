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

        private readonly PaddleOCREngine engine;
        private ScreenSnap snapForm;
        private Bitmap curBitmap;

        private readonly string SnapSaveDir = "";

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

        }

        private void BtnSnapshot_Click(object sender, EventArgs e)
        {
            TakeSnapshot();
        }





        private string RunOCR<T>(T img)
        {
            int success = 0;
            do
            {
                try
                {
                    if (typeof(T) == typeof(string))
                    {
                        OCRResult ocrResult = engine.DetectText(img as string) ??
                            throw new Exception("识别出错了！！！");
                        return ocrResult.Text;
                    }
                    else if (typeof(T) == typeof(Image))
                    {
                        OCRResult ocrResult = engine.DetectText(img as Image) ??
                            throw new Exception("识别出错了！！！");
                        return ocrResult.Text;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    success++;
                }
            } while (0 < success && success < 5);

            return "";
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
            var imgFilename = Path.Combine(SnapSaveDir,
                $"{DateTime.Now.ToLocalTime().ToString().Replace('/', '-').Replace(':', '.')}.png");
            bmp.Save(imgFilename, System.Drawing.Imaging.ImageFormat.Png);
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
    }
}
