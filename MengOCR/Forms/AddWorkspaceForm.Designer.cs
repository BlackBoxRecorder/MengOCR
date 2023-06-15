namespace MengOCR.Forms
{
    partial class AddWorkspaceForm
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
            this.FAddWorkspaceForm = new ReaLTaiizor.Forms.ForeverForm();
            this.TxtWorkspaceName = new ReaLTaiizor.Controls.ForeverTextBox();
            this.FBtnClose = new ReaLTaiizor.Controls.ForeverButton();
            this.FAddWorkspaceForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // FAddWorkspaceForm
            // 
            this.FAddWorkspaceForm.BackColor = System.Drawing.Color.White;
            this.FAddWorkspaceForm.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.FAddWorkspaceForm.BorderColor = System.Drawing.Color.DodgerBlue;
            this.FAddWorkspaceForm.Controls.Add(this.FBtnClose);
            this.FAddWorkspaceForm.Controls.Add(this.TxtWorkspaceName);
            this.FAddWorkspaceForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FAddWorkspaceForm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FAddWorkspaceForm.ForeverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.FAddWorkspaceForm.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.FAddWorkspaceForm.HeaderMaximize = false;
            this.FAddWorkspaceForm.HeaderTextFont = new System.Drawing.Font("Segoe UI", 12F);
            this.FAddWorkspaceForm.Image = null;
            this.FAddWorkspaceForm.Location = new System.Drawing.Point(0, 0);
            this.FAddWorkspaceForm.MinimumSize = new System.Drawing.Size(210, 50);
            this.FAddWorkspaceForm.Name = "FAddWorkspaceForm";
            this.FAddWorkspaceForm.Padding = new System.Windows.Forms.Padding(1, 51, 1, 1);
            this.FAddWorkspaceForm.Sizable = false;
            this.FAddWorkspaceForm.Size = new System.Drawing.Size(400, 200);
            this.FAddWorkspaceForm.TabIndex = 0;
            this.FAddWorkspaceForm.Text = "添加工作区";
            this.FAddWorkspaceForm.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.FAddWorkspaceForm.TextLight = System.Drawing.Color.SeaGreen;
            // 
            // TxtWorkspaceName
            // 
            this.TxtWorkspaceName.BackColor = System.Drawing.Color.Transparent;
            this.TxtWorkspaceName.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.TxtWorkspaceName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.TxtWorkspaceName.FocusOnHover = false;
            this.TxtWorkspaceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TxtWorkspaceName.Location = new System.Drawing.Point(101, 77);
            this.TxtWorkspaceName.MaxLength = 32767;
            this.TxtWorkspaceName.Multiline = false;
            this.TxtWorkspaceName.Name = "TxtWorkspaceName";
            this.TxtWorkspaceName.ReadOnly = false;
            this.TxtWorkspaceName.Size = new System.Drawing.Size(199, 29);
            this.TxtWorkspaceName.TabIndex = 0;
            this.TxtWorkspaceName.Text = "工作区名称";
            this.TxtWorkspaceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtWorkspaceName.UseSystemPasswordChar = false;
            // 
            // FBtnClose
            // 
            this.FBtnClose.BackColor = System.Drawing.Color.Transparent;
            this.FBtnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.FBtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FBtnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FBtnClose.Location = new System.Drawing.Point(164, 134);
            this.FBtnClose.Name = "FBtnClose";
            this.FBtnClose.Rounded = false;
            this.FBtnClose.Size = new System.Drawing.Size(60, 30);
            this.FBtnClose.TabIndex = 1;
            this.FBtnClose.Text = "添加";
            this.FBtnClose.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.FBtnClose.Click += new System.EventHandler(this.FBtnClose_Click);
            // 
            // AddWorkspaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.FAddWorkspaceForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddWorkspaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddWorkspaceForm";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FAddWorkspaceForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm FAddWorkspaceForm;
        private ReaLTaiizor.Controls.ForeverButton FBtnClose;
        public ReaLTaiizor.Controls.ForeverTextBox TxtWorkspaceName;
    }
}