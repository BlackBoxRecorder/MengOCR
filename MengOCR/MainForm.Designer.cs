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
            this.UMainForm = new ReaLTaiizor.Forms.DungeonForm();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dungeonListBox1 = new ReaLTaiizor.Controls.DungeonListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dungeonRichTextBox1 = new ReaLTaiizor.Controls.DungeonRichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dungeonButtonRight1 = new ReaLTaiizor.Controls.DungeonButtonRight();
            this.dungeonButtonRight2 = new ReaLTaiizor.Controls.DungeonButtonRight();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.UMainControlBox = new ReaLTaiizor.Controls.DungeonControlBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UMainForm
            // 
            this.UMainForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.UMainForm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.UMainForm.Controls.Add(this.panel2);
            this.UMainForm.Controls.Add(this.panel1);
            this.UMainForm.Controls.Add(this.statusStrip1);
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
            this.splitContainer1.Panel1.Controls.Add(this.dungeonListBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(760, 313);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 0;
            // 
            // dungeonListBox1
            // 
            this.dungeonListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dungeonListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dungeonListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dungeonListBox1.FormattingEnabled = true;
            this.dungeonListBox1.IntegralHeight = false;
            this.dungeonListBox1.ItemHeight = 18;
            this.dungeonListBox1.Items.AddRange(new object[] {
            "测试",
            "文件",
            "20点40分",
            "啊手动阀手动阀",
            "请问请问废弃物",
            "qefqwefwe却无法请问",
            "犬瘟热反动权威让父亲为",
            "qwerfqer "});
            this.dungeonListBox1.Location = new System.Drawing.Point(0, 0);
            this.dungeonListBox1.Name = "dungeonListBox1";
            this.dungeonListBox1.Size = new System.Drawing.Size(185, 313);
            this.dungeonListBox1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dungeonRichTextBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer2.Size = new System.Drawing.Size(571, 313);
            this.splitContainer2.SplitterDistance = 274;
            this.splitContainer2.TabIndex = 0;
            // 
            // dungeonRichTextBox1
            // 
            this.dungeonRichTextBox1.AutoWordSelection = false;
            this.dungeonRichTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonRichTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.dungeonRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dungeonRichTextBox1.EdgeColor = System.Drawing.Color.White;
            this.dungeonRichTextBox1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dungeonRichTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.dungeonRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.dungeonRichTextBox1.Name = "dungeonRichTextBox1";
            this.dungeonRichTextBox1.ReadOnly = false;
            this.dungeonRichTextBox1.Size = new System.Drawing.Size(274, 313);
            this.dungeonRichTextBox1.TabIndex = 0;
            this.dungeonRichTextBox1.Text = "图片文字识别识别结果在这里！";
            this.dungeonRichTextBox1.TextBackColor = System.Drawing.Color.White;
            this.dungeonRichTextBox1.WordWrap = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(184)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MengOCR.Properties.Resources._325d39fe881611ebb6edd017c2d2eca2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(293, 313);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            this.flowLayoutPanel1.Controls.Add(this.dungeonButtonRight1);
            this.flowLayoutPanel1.Controls.Add(this.dungeonButtonRight2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(760, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // dungeonButtonRight1
            // 
            this.dungeonButtonRight1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonButtonRight1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.dungeonButtonRight1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flowLayoutPanel1.SetFlowBreak(this.dungeonButtonRight1, true);
            this.dungeonButtonRight1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dungeonButtonRight1.Image = null;
            this.dungeonButtonRight1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dungeonButtonRight1.InactiveColorA = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(175)))), ((int)(((byte)(143)))));
            this.dungeonButtonRight1.InactiveColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.dungeonButtonRight1.Location = new System.Drawing.Point(3, 3);
            this.dungeonButtonRight1.Name = "dungeonButtonRight1";
            this.dungeonButtonRight1.PressedColorA = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.dungeonButtonRight1.PressedColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.dungeonButtonRight1.PressedContourColorA = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.dungeonButtonRight1.PressedContourColorB = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.dungeonButtonRight1.Size = new System.Drawing.Size(60, 30);
            this.dungeonButtonRight1.TabIndex = 0;
            this.dungeonButtonRight1.Text = "截图";
            this.dungeonButtonRight1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dungeonButtonRight2
            // 
            this.dungeonButtonRight2.BackColor = System.Drawing.Color.Transparent;
            this.dungeonButtonRight2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.dungeonButtonRight2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dungeonButtonRight2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dungeonButtonRight2.Image = null;
            this.dungeonButtonRight2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dungeonButtonRight2.InactiveColorA = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(175)))), ((int)(((byte)(143)))));
            this.dungeonButtonRight2.InactiveColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.dungeonButtonRight2.Location = new System.Drawing.Point(69, 3);
            this.dungeonButtonRight2.Name = "dungeonButtonRight2";
            this.dungeonButtonRight2.PressedColorA = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.dungeonButtonRight2.PressedColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.dungeonButtonRight2.PressedContourColorA = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.dungeonButtonRight2.PressedContourColorB = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.dungeonButtonRight2.Size = new System.Drawing.Size(60, 30);
            this.dungeonButtonRight2.TabIndex = 1;
            this.dungeonButtonRight2.Text = "复制";
            this.dungeonButtonRight2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(20, 412);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(760, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UMainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "萌萌哒OCR";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.DungeonForm UMainForm;
        private ReaLTaiizor.Controls.DungeonControlBox UMainControlBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ReaLTaiizor.Controls.DungeonListBox dungeonListBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.DungeonButtonRight dungeonButtonRight1;
        private ReaLTaiizor.Controls.DungeonButtonRight dungeonButtonRight2;
        private ReaLTaiizor.Controls.DungeonRichTextBox dungeonRichTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

