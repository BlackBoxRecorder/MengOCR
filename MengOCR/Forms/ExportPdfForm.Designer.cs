namespace MengOCR.Forms
{
    partial class ExportPdfForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportPdfForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbWorkspace = new System.Windows.Forms.ComboBox();
            this.TxtExportPath = new System.Windows.Forms.TextBox();
            this.CmbSetPageWidth = new System.Windows.Forms.ComboBox();
            this.TxtSetWidth = new System.Windows.Forms.TextBox();
            this.CkbExportText = new System.Windows.Forms.CheckBox();
            this.BtnExport = new System.Windows.Forms.Button();
            this.BtnColorPicker = new System.Windows.Forms.Button();
            this.BtnSelectExportPath = new System.Windows.Forms.Button();
            this.ColorSelectedIcon = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择工作区";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "导出路径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "页面宽度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "背景颜色";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "导出文本";
            // 
            // CmbWorkspace
            // 
            this.CmbWorkspace.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmbWorkspace.FormattingEnabled = true;
            this.CmbWorkspace.Location = new System.Drawing.Point(120, 22);
            this.CmbWorkspace.Name = "CmbWorkspace";
            this.CmbWorkspace.Size = new System.Drawing.Size(175, 24);
            this.CmbWorkspace.TabIndex = 5;
            // 
            // TxtExportPath
            // 
            this.TxtExportPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtExportPath.Location = new System.Drawing.Point(120, 61);
            this.TxtExportPath.MaximumSize = new System.Drawing.Size(300, 25);
            this.TxtExportPath.Name = "TxtExportPath";
            this.TxtExportPath.Size = new System.Drawing.Size(300, 25);
            this.TxtExportPath.TabIndex = 6;
            // 
            // CmbSetPageWidth
            // 
            this.CmbSetPageWidth.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmbSetPageWidth.FormattingEnabled = true;
            this.CmbSetPageWidth.Location = new System.Drawing.Point(120, 101);
            this.CmbSetPageWidth.Name = "CmbSetPageWidth";
            this.CmbSetPageWidth.Size = new System.Drawing.Size(143, 24);
            this.CmbSetPageWidth.TabIndex = 7;
            // 
            // TxtSetWidth
            // 
            this.TxtSetWidth.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtSetWidth.Location = new System.Drawing.Point(293, 99);
            this.TxtSetWidth.Name = "TxtSetWidth";
            this.TxtSetWidth.Size = new System.Drawing.Size(100, 26);
            this.TxtSetWidth.TabIndex = 8;
            // 
            // CkbExportText
            // 
            this.CkbExportText.AutoSize = true;
            this.CkbExportText.Location = new System.Drawing.Point(120, 187);
            this.CkbExportText.Name = "CkbExportText";
            this.CkbExportText.Size = new System.Drawing.Size(78, 16);
            this.CkbExportText.TabIndex = 9;
            this.CkbExportText.Text = "导出 .txt";
            this.CkbExportText.UseVisualStyleBackColor = true;
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(441, 249);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(75, 25);
            this.BtnExport.TabIndex = 10;
            this.BtnExport.Text = "导出";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnColorPicker
            // 
            this.BtnColorPicker.Location = new System.Drawing.Point(120, 143);
            this.BtnColorPicker.Name = "BtnColorPicker";
            this.BtnColorPicker.Size = new System.Drawing.Size(75, 25);
            this.BtnColorPicker.TabIndex = 11;
            this.BtnColorPicker.Text = "选择颜色";
            this.BtnColorPicker.UseVisualStyleBackColor = true;
            this.BtnColorPicker.Click += new System.EventHandler(this.BtnColorPicker_Click);
            // 
            // BtnSelectExportPath
            // 
            this.BtnSelectExportPath.Location = new System.Drawing.Point(426, 62);
            this.BtnSelectExportPath.Name = "BtnSelectExportPath";
            this.BtnSelectExportPath.Size = new System.Drawing.Size(75, 25);
            this.BtnSelectExportPath.TabIndex = 12;
            this.BtnSelectExportPath.Text = "浏览";
            this.BtnSelectExportPath.UseVisualStyleBackColor = true;
            // 
            // ColorSelectedIcon
            // 
            this.ColorSelectedIcon.BackColor = System.Drawing.Color.White;
            this.ColorSelectedIcon.Location = new System.Drawing.Point(210, 144);
            this.ColorSelectedIcon.Name = "ColorSelectedIcon";
            this.ColorSelectedIcon.Size = new System.Drawing.Size(25, 25);
            this.ColorSelectedIcon.TabIndex = 13;
            // 
            // ExportPdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 296);
            this.Controls.Add(this.ColorSelectedIcon);
            this.Controls.Add(this.BtnSelectExportPath);
            this.Controls.Add(this.BtnColorPicker);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.CkbExportText);
            this.Controls.Add(this.TxtSetWidth);
            this.Controls.Add(this.CmbSetPageWidth);
            this.Controls.Add(this.TxtExportPath);
            this.Controls.Add(this.CmbWorkspace);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExportPdfForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导出PDF";
            this.Load += new System.EventHandler(this.ExportPdfForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbWorkspace;
        private System.Windows.Forms.TextBox TxtExportPath;
        private System.Windows.Forms.ComboBox CmbSetPageWidth;
        private System.Windows.Forms.TextBox TxtSetWidth;
        private System.Windows.Forms.CheckBox CkbExportText;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Button BtnColorPicker;
        private System.Windows.Forms.Button BtnSelectExportPath;
        private System.Windows.Forms.Panel ColorSelectedIcon;
    }
}