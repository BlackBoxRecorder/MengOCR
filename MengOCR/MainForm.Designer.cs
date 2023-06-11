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
            this.dungeonForm1 = new ReaLTaiizor.Forms.DungeonForm();
            this.dungeonControlBox1 = new ReaLTaiizor.Controls.DungeonControlBox();
            this.dungeonForm1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dungeonForm1
            // 
            this.dungeonForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dungeonForm1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.dungeonForm1.Controls.Add(this.dungeonControlBox1);
            this.dungeonForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dungeonForm1.FillEdgeColorA = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.dungeonForm1.FillEdgeColorB = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.dungeonForm1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dungeonForm1.FooterEdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.dungeonForm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(219)))), ((int)(((byte)(210)))));
            this.dungeonForm1.HeaderEdgeColorA = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(85)))), ((int)(((byte)(77)))));
            this.dungeonForm1.HeaderEdgeColorB = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.dungeonForm1.Location = new System.Drawing.Point(0, 0);
            this.dungeonForm1.Name = "dungeonForm1";
            this.dungeonForm1.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.dungeonForm1.RoundCorners = true;
            this.dungeonForm1.Sizable = true;
            this.dungeonForm1.Size = new System.Drawing.Size(800, 450);
            this.dungeonForm1.SmartBounds = true;
            this.dungeonForm1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.dungeonForm1.TabIndex = 0;
            this.dungeonForm1.Text = "萌萌哒OCR";
            this.dungeonForm1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(219)))), ((int)(((byte)(210)))));
            // 
            // dungeonControlBox1
            // 
            this.dungeonControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dungeonControlBox1.DefaultLocation = true;
            this.dungeonControlBox1.EnableMaximize = true;
            this.dungeonControlBox1.EnableMinimize = true;
            this.dungeonControlBox1.Font = new System.Drawing.Font("Marlett", 7F);
            this.dungeonControlBox1.Location = new System.Drawing.Point(5, 13);
            this.dungeonControlBox1.Name = "dungeonControlBox1";
            this.dungeonControlBox1.Size = new System.Drawing.Size(64, 22);
            this.dungeonControlBox1.TabIndex = 0;
            this.dungeonControlBox1.Text = "dungeonControlBox1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dungeonForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "MainForm";
            this.Text = "萌萌哒OCR";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.dungeonForm1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.DungeonForm dungeonForm1;
        private ReaLTaiizor.Controls.DungeonControlBox dungeonControlBox1;
    }
}

