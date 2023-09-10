using ImageMagick;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MengOCR.Forms
{
    public partial class ExportPdfForm : Form
    {
        private Color SelectedBgColor = Color.White;


        public ExportPdfForm()
        {
            InitializeComponent();
        }

        private void ExportPdfForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblExportInfo.Text = "";

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
            string exportpath = "";
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

                if (CkbImgOrder.Checked)
                {
                    images.Reverse();
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = $"{space}.pdf"
                };
                var res = saveFileDialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    exportpath = saveFileDialog.FileName;
                    images.Write(exportpath);
                }

            }

            if (CkbExportText.Checked)
            {
                string restxt = string.Empty;

                //读取当前工作区的识别结果
                var items = StoreData.Instance.GetOCRItemsByWorkspace(space);
                foreach (var item in items)
                {
                    restxt += item.ContentTxt;
                    restxt += "\n";
                }

                File.WriteAllText($"{exportpath.Replace(".pdf", "")}.txt", restxt);
            }

        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                LblExportInfo.Text = "正在导出，请稍等...";
                BtnExport.Enabled = false;
                Export();
                LblExportInfo.Text = "导出成功";
            }
            catch (Exception ex)
            {
                LblExportInfo.Text = $"导出错误:{ex.Message}";
            }
            BtnExport.Enabled = true;

        }

        private void CmbSetPageWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var show = CmbSetPageWidth.SelectedIndex > 0;
            if (show)
            {
                TxtSetWidth.Visible = true;
                TxtSetWidth.Text = "1280";
            }
            else
            {
                TxtSetWidth.Visible = false;
            }
        }
    }
}
