using ImageMagick;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MengOCR.Forms
{
    public partial class ExportPdfForm : Form
    {
        private Color SelectedBgColor;


        public ExportPdfForm()
        {
            InitializeComponent();
        }

        private void ExportPdfForm_Load(object sender, EventArgs e)
        {
            try
            {
                var spaces = StoreData.Instance.GetWorkspaceAsync();

                foreach (var item in spaces)
                {
                    CmbWorkspace.Items.Add(item.Name);
                }

                CmbWorkspace.SelectedIndex = 0;

                var docupath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                TxtExportPath.Text = docupath;

                CkbExportText.Checked = true;

                CmbSetPageWidth.Items.Add("自适应图片宽度");
                CmbSetPageWidth.Items.Add("自定义");

                CmbSetPageWidth.SelectedIndex = 0;

                TxtSetWidth.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnColorPicker_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.ShowDialog();
                var color = colorDialog.Color;
                ColorSelectedIcon.BackColor = color;
                SelectedBgColor = color;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Export()
        {
            var dir = Directory.GetCurrentDirectory();
            MagickNET.SetGhostscriptDirectory(Path.Combine(dir, "dll"));
            var idx = CmbWorkspace.SelectedIndex;
            var space = CmbWorkspace.Items[idx].ToString();
            var imgbase = StoreData.Instance.GetKeyVal<string>("snapSaveDir");
            var imgdir = Path.Combine(imgbase, space);
            if (!Directory.Exists(imgdir))
            {
                MessageBox.Show("工作区目录不存在");
                return;
            }
            int margin = 20;
            int maxwidth = 0;
            int bgwidth;
            var files = Directory.GetFiles(imgdir);

            foreach (var file in files)
            {
                var img = new MagickImage(file);
                if (img.Width > maxwidth)
                {
                    maxwidth = img.Width;
                }
            }

            if (CmbSetPageWidth.SelectedIndex > 0)
            {//页面宽度是设定的最大宽度
                if (!int.TryParse(TxtSetWidth.Text, out bgwidth))
                {
                    bgwidth = 1280;
                }
            }
            else
            {//自适应图片，页面宽度是图片的最大宽度
                bgwidth = maxwidth;
            }

            if (bgwidth < maxwidth)
            {//要对图片进行缩放
                //TODO
            }



            var bgcolor = MagickColor.FromRgb(SelectedBgColor.R, SelectedBgColor.G, SelectedBgColor.B);
            using (var images = new MagickImageCollection())
            {
                foreach (var file in files)
                {
                    var img = new MagickImage(file);
                    var bac = new MagickImage(bgcolor, bgwidth, img.Height + margin);

                    int x = (bgwidth - img.Width) / 2;
                    bac.Composite(img, x, margin / 2);
                    images.Add(bac);
                }

                if (images.Count < 1)
                {
                    MessageBox.Show($"Failed to export");
                    return;
                }

                //导出文件向导，勾选导出txt文本，选择导出路径，导出后打开
                //统一图片分辨率，将图片放到白色背景上统一大小
                //导出一张大图
                //排序

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = $"{space}.pdf";
                var res = saveFileDialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    images.Write(saveFileDialog.FileName);
                }

            }

            if (CkbExportText.Checked)
            {

            }

        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            Export();
        }
    }
}
