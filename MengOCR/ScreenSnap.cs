using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MengOCR
{
    public partial class ScreenSnap : Form
    {
        private Point start = new Point(0, 0);
        public Point Start
        {
            get { return start; }

            set { start = value; }
        }
        private Point end = new Point(0, 0);
        public Point End
        {
            get { return end; }

            set { end = value; }
        }

        public event EventHandler ScreenShotOk;


        public ScreenSnap()
        {
            InitializeComponent();
            //以下采用双缓冲方式，减少闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.Top = 0;
            this.Left = 0;
            //当前窗口最大化，且不显示标题栏
            Rectangle ScreenArea = Screen.GetBounds(this);
            this.MaximumSize = new Size(ScreenArea.Width, ScreenArea.Height);

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //鼠标，十字键
            this.Cursor = Cursors.Cross;
            this.BackgroundImageLayout = ImageLayout.Center;
        }

        private void ScreenSnap_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //using (Graphics g = this.CreateGraphics())
            {
                Pen p = Pens.Red;
                e.Graphics.DrawRectangle(p, new Rectangle(Start, new Size(End.X - Start.X, End.Y - Start.Y)));
            }
        }

        private void ScreenSnap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Start = e.Location;
            }
        }

        private void ScreenSnap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                End = e.Location;
                this.Refresh();
            }
        }

        private void ScreenSnap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Location == Start)
                {
                    return;
                }
                End = e.Location;
                ScreenShotOk?.Invoke(this, null);
                this.Close();
            }
        }
    }
}
