namespace MengOCR
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UMainForm = new ReaLTaiizor.Forms.DungeonForm();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.UListImagesFiles = new ReaLTaiizor.Controls.DungeonListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.UTextOCRResult = new ReaLTaiizor.Controls.DungeonRichTextBox();
            this.PictureSnaped = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnSnapshot = new ReaLTaiizor.Controls.DungeonButtonRight();
            this.BtnCopyResultText = new ReaLTaiizor.Controls.DungeonButtonRight();
            this.StatusStripBar = new System.Windows.Forms.StatusStrip();
            this.StatTotalFileNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatWordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatAbout = new System.Windows.Forms.ToolStripStatusLabel();
            this.UMainControlBox = new ReaLTaiizor.Controls.DungeonControlBox();
            this.NotifyIconOCR = new System.Windows.Forms.NotifyIcon(this.components);
            this.BtnRunOCR = new ReaLTaiizor.Controls.DungeonButtonRight();
            this.UMainForm.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureSnaped)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.StatusStripBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // UMainForm
            // 
            this.UMainForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.UMainForm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.UMainForm.Controls.Add(this.panel2);
            this.UMainForm.Controls.Add(this.panel1);
            this.UMainForm.Controls.Add(this.StatusStripBar);
            this.UMainForm.Controls.Add(this.UMainControlBox);
            this.UMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UMainForm.FillEdgeColorA = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.UMainForm.FillEdgeColorB = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.UMainForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UMainForm.FooterEdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.UMainForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(219)))), ((int)(((byte)(210)))));
            this.UMainForm.HeaderEdgeColorA = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(85)))), ((int)(((byte)(77)))));
            this.UMainForm.HeaderEdgeColorB = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.UMainForm.Location = new System.Drawing.Point(0, 0);
            this.UMainForm.MinimumSize = new System.Drawing.Size(500, 250);
            this.UMainForm.Name = "UMainForm";
            this.UMainForm.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.UMainForm.RoundCorners = true;
            this.UMainForm.Sizable = true;
            this.UMainForm.Size = new System.Drawing.Size(800, 450);
            this.UMainForm.SmartBounds = true;
            this.UMainForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.UMainForm.TabIndex = 0;
            this.UMainForm.Text = "萌萌哒OCR";
            this.UMainForm.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(219)))), ((int)(((byte)(210)))));
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 313);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.UListImagesFiles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(760, 313);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 0;
            // 
            // UListImagesFiles
            // 
            this.UListImagesFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UListImagesFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.UListImagesFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.UListImagesFiles.FormattingEnabled = true;
            this.UListImagesFiles.IntegralHeight = false;
            this.UListImagesFiles.ItemHeight = 18;
            this.UListImagesFiles.Location = new System.Drawing.Point(0, 0);
            this.UListImagesFiles.Name = "UListImagesFiles";
            this.UListImagesFiles.Size = new System.Drawing.Size(185, 313);
            this.UListImagesFiles.TabIndex = 0;
            this.UListImagesFiles.SelectedIndexChanged += new System.EventHandler(this.UListImagesFiles_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.UTextOCRResult);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitContainer2.Panel2.Controls.Add(this.PictureSnaped);
            this.splitContainer2.Size = new System.Drawing.Size(571, 313);
            this.splitContainer2.SplitterDistance = 274;
            this.splitContainer2.TabIndex = 0;
            // 
            // UTextOCRResult
            // 
            this.UTextOCRResult.AutoWordSelection = false;
            this.UTextOCRResult.BackColor = System.Drawing.Color.Transparent;
            this.UTextOCRResult.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.UTextOCRResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UTextOCRResult.EdgeColor = System.Drawing.Color.White;
            this.UTextOCRResult.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UTextOCRResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.UTextOCRResult.Location = new System.Drawing.Point(0, 0);
            this.UTextOCRResult.Name = "UTextOCRResult";
            this.UTextOCRResult.ReadOnly = false;
            this.UTextOCRResult.Size = new System.Drawing.Size(274, 313);
            this.UTextOCRResult.TabIndex = 0;
            this.UTextOCRResult.Text = "图片文字识别识别结果在这里！";
            this.UTextOCRResult.TextBackColor = System.Drawing.Color.White;
            this.UTextOCRResult.WordWrap = true;
            // 
            // PictureSnaped
            // 
            this.PictureSnaped.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(184)))));
            this.PictureSnaped.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureSnaped.Image = global::MengOCR.Properties.Resources._325d39fe881611ebb6edd017c2d2eca2;
            this.PictureSnaped.Location = new System.Drawing.Point(0, 0);
            this.PictureSnaped.Name = "PictureSnaped";
            this.PictureSnaped.Size = new System.Drawing.Size(293, 313);
            this.PictureSnaped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureSnaped.TabIndex = 0;
            this.PictureSnaped.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 43);
            this.panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtnSnapshot);
            this.flowLayoutPanel1.Controls.Add(this.BtnCopyResultText);
            this.flowLayoutPanel1.Controls.Add(this.BtnRunOCR);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(760, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // BtnSnapshot
            // 
            this.BtnSnapshot.BackColor = System.Drawing.Color.Transparent;
            this.BtnSnapshot.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnSnapshot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flowLayoutPanel1.SetFlowBreak(this.BtnSnapshot, true);
            this.BtnSnapshot.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.BtnSnapshot.Image = null;
            this.BtnSnapshot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSnapshot.InactiveColorA = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(175)))), ((int)(((byte)(143)))));
            this.BtnSnapshot.InactiveColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnSnapshot.Location = new System.Drawing.Point(3, 3);
            this.BtnSnapshot.Name = "BtnSnapshot";
            this.BtnSnapshot.PressedColorA = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnSnapshot.PressedColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnSnapshot.PressedContourColorA = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnSnapshot.PressedContourColorB = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnSnapshot.Size = new System.Drawing.Size(60, 30);
            this.BtnSnapshot.TabIndex = 0;
            this.BtnSnapshot.Text = "截图";
            this.BtnSnapshot.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnSnapshot.Click += new System.EventHandler(this.BtnSnapshot_Click);
            // 
            // BtnCopyResultText
            // 
            this.BtnCopyResultText.BackColor = System.Drawing.Color.Transparent;
            this.BtnCopyResultText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnCopyResultText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCopyResultText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.BtnCopyResultText.Image = null;
            this.BtnCopyResultText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCopyResultText.InactiveColorA = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(175)))), ((int)(((byte)(143)))));
            this.BtnCopyResultText.InactiveColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnCopyResultText.Location = new System.Drawing.Point(69, 3);
            this.BtnCopyResultText.Name = "BtnCopyResultText";
            this.BtnCopyResultText.PressedColorA = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnCopyResultText.PressedColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnCopyResultText.PressedContourColorA = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnCopyResultText.PressedContourColorB = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnCopyResultText.Size = new System.Drawing.Size(60, 30);
            this.BtnCopyResultText.TabIndex = 1;
            this.BtnCopyResultText.Text = "复制";
            this.BtnCopyResultText.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnCopyResultText.Click += new System.EventHandler(this.BtnCopyResultText_Click);
            // 
            // StatusStripBar
            // 
            this.StatusStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatTotalFileNum,
            this.StatWordCount,
            this.toolStripStatusLabel2,
            this.StatAbout});
            this.StatusStripBar.Location = new System.Drawing.Point(20, 412);
            this.StatusStripBar.Name = "StatusStripBar";
            this.StatusStripBar.Size = new System.Drawing.Size(760, 22);
            this.StatusStripBar.TabIndex = 1;
            this.StatusStripBar.Text = "statusStrip1";
            // 
            // StatTotalFileNum
            // 
            this.StatTotalFileNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StatTotalFileNum.Name = "StatTotalFileNum";
            this.StatTotalFileNum.Size = new System.Drawing.Size(53, 17);
            this.StatTotalFileNum.Text = "共123个";
            // 
            // StatWordCount
            // 
            this.StatWordCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StatWordCount.Name = "StatWordCount";
            this.StatWordCount.Size = new System.Drawing.Size(89, 17);
            this.StatWordCount.Text = "识别出123个字";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(571, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // StatAbout
            // 
            this.StatAbout.IsLink = true;
            this.StatAbout.Name = "StatAbout";
            this.StatAbout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StatAbout.Size = new System.Drawing.Size(32, 17);
            this.StatAbout.Text = "关于";
            // 
            // UMainControlBox
            // 
            this.UMainControlBox.BackColor = System.Drawing.Color.Transparent;
            this.UMainControlBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UMainControlBox.DefaultLocation = true;
            this.UMainControlBox.EnableMaximize = true;
            this.UMainControlBox.EnableMinimize = true;
            this.UMainControlBox.Font = new System.Drawing.Font("Marlett", 7F);
            this.UMainControlBox.Location = new System.Drawing.Point(5, 13);
            this.UMainControlBox.Name = "UMainControlBox";
            this.UMainControlBox.Size = new System.Drawing.Size(64, 22);
            this.UMainControlBox.TabIndex = 0;
            this.UMainControlBox.Text = "UMainControlBox";
            // 
            // NotifyIconOCR
            // 
            this.NotifyIconOCR.Text = "萌萌哒OCR";
            this.NotifyIconOCR.Visible = true;
            this.NotifyIconOCR.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconOCR_MouseClick);
            // 
            // BtnRunOCR
            // 
            this.BtnRunOCR.BackColor = System.Drawing.Color.Transparent;
            this.BtnRunOCR.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnRunOCR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRunOCR.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.BtnRunOCR.Image = null;
            this.BtnRunOCR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRunOCR.InactiveColorA = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(175)))), ((int)(((byte)(143)))));
            this.BtnRunOCR.InactiveColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnRunOCR.Location = new System.Drawing.Point(135, 3);
            this.BtnRunOCR.Name = "BtnRunOCR";
            this.BtnRunOCR.PressedColorA = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnRunOCR.PressedColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnRunOCR.PressedContourColorA = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnRunOCR.PressedContourColorB = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnRunOCR.Size = new System.Drawing.Size(60, 30);
            this.BtnRunOCR.TabIndex = 2;
            this.BtnRunOCR.Text = "识别";
            this.BtnRunOCR.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnRunOCR.Click += new System.EventHandler(this.BtnRunOCR_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UMainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(500, 250);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "萌萌哒OCR";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.UMainForm.ResumeLayout(false);
            this.UMainForm.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureSnaped)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.StatusStripBar.ResumeLayout(false);
            this.StatusStripBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.DungeonForm UMainForm;
        private ReaLTaiizor.Controls.DungeonControlBox UMainControlBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ReaLTaiizor.Controls.DungeonListBox UListImagesFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip StatusStripBar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.DungeonButtonRight BtnSnapshot;
        private ReaLTaiizor.Controls.DungeonButtonRight BtnCopyResultText;
        private ReaLTaiizor.Controls.DungeonRichTextBox UTextOCRResult;
        private System.Windows.Forms.PictureBox PictureSnaped;
        private System.Windows.Forms.ToolStripStatusLabel StatTotalFileNum;
        private System.Windows.Forms.ToolStripStatusLabel StatWordCount;
        private System.Windows.Forms.ToolStripStatusLabel StatAbout;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.NotifyIcon NotifyIconOCR;
        private ReaLTaiizor.Controls.DungeonButtonRight BtnRunOCR;
    }
}

