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
            this.DAddWorkspaceForm = new ReaLTaiizor.Forms.DungeonForm();
            this.TxtWorkspaceName = new ReaLTaiizor.Controls.DungeonTextBox();
            this.BtnOK = new ReaLTaiizor.Controls.DungeonButtonRight();
            this.dungeonControlBox1 = new ReaLTaiizor.Controls.DungeonControlBox();
            this.DAddWorkspaceForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // DAddWorkspaceForm
            // 
            this.DAddWorkspaceForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.DAddWorkspaceForm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.DAddWorkspaceForm.Controls.Add(this.dungeonControlBox1);
            this.DAddWorkspaceForm.Controls.Add(this.BtnOK);
            this.DAddWorkspaceForm.Controls.Add(this.TxtWorkspaceName);
            this.DAddWorkspaceForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DAddWorkspaceForm.FillEdgeColorA = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.DAddWorkspaceForm.FillEdgeColorB = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.DAddWorkspaceForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DAddWorkspaceForm.FooterEdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.DAddWorkspaceForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(219)))), ((int)(((byte)(210)))));
            this.DAddWorkspaceForm.HeaderEdgeColorA = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(85)))), ((int)(((byte)(77)))));
            this.DAddWorkspaceForm.HeaderEdgeColorB = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(68)))), ((int)(((byte)(63)))));
            this.DAddWorkspaceForm.Location = new System.Drawing.Point(0, 0);
            this.DAddWorkspaceForm.Name = "DAddWorkspaceForm";
            this.DAddWorkspaceForm.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.DAddWorkspaceForm.RoundCorners = true;
            this.DAddWorkspaceForm.Sizable = false;
            this.DAddWorkspaceForm.Size = new System.Drawing.Size(400, 200);
            this.DAddWorkspaceForm.SmartBounds = true;
            this.DAddWorkspaceForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.DAddWorkspaceForm.TabIndex = 0;
            this.DAddWorkspaceForm.Text = "添加工作区";
            this.DAddWorkspaceForm.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(219)))), ((int)(((byte)(210)))));
            // 
            // TxtWorkspaceName
            // 
            this.TxtWorkspaceName.BackColor = System.Drawing.Color.Transparent;
            this.TxtWorkspaceName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TxtWorkspaceName.EdgeColor = System.Drawing.Color.White;
            this.TxtWorkspaceName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtWorkspaceName.ForeColor = System.Drawing.Color.DimGray;
            this.TxtWorkspaceName.Location = new System.Drawing.Point(77, 90);
            this.TxtWorkspaceName.MaxLength = 32767;
            this.TxtWorkspaceName.Multiline = false;
            this.TxtWorkspaceName.Name = "TxtWorkspaceName";
            this.TxtWorkspaceName.ReadOnly = false;
            this.TxtWorkspaceName.Size = new System.Drawing.Size(157, 28);
            this.TxtWorkspaceName.TabIndex = 0;
            this.TxtWorkspaceName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtWorkspaceName.UseSystemPasswordChar = false;
            // 
            // BtnOK
            // 
            this.BtnOK.BackColor = System.Drawing.Color.Transparent;
            this.BtnOK.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOK.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.BtnOK.Image = null;
            this.BtnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOK.InactiveColorA = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(175)))), ((int)(((byte)(143)))));
            this.BtnOK.InactiveColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnOK.Location = new System.Drawing.Point(255, 88);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.PressedColorA = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnOK.PressedColorB = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(146)))), ((int)(((byte)(106)))));
            this.BtnOK.PressedContourColorA = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnOK.PressedContourColorB = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(120)))), ((int)(((byte)(101)))));
            this.BtnOK.Size = new System.Drawing.Size(60, 30);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "确定";
            this.BtnOK.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // dungeonControlBox1
            // 
            this.dungeonControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dungeonControlBox1.DefaultLocation = true;
            this.dungeonControlBox1.EnableMaximize = true;
            this.dungeonControlBox1.EnableMinimize = true;
            this.dungeonControlBox1.Font = new System.Drawing.Font("Marlett", 7F);
            this.dungeonControlBox1.Location = new System.Drawing.Point(11, 12);
            this.dungeonControlBox1.Name = "dungeonControlBox1";
            this.dungeonControlBox1.Size = new System.Drawing.Size(64, 22);
            this.dungeonControlBox1.TabIndex = 2;
            this.dungeonControlBox1.Text = "dungeonControlBox1";
            // 
            // AddWorkspaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.DAddWorkspaceForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "AddWorkspaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加工作区";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.AddWorkspaceForm_Load);
            this.DAddWorkspaceForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.DungeonForm DAddWorkspaceForm;
        private ReaLTaiizor.Controls.DungeonControlBox dungeonControlBox1;
        private ReaLTaiizor.Controls.DungeonButtonRight BtnOK;
        public ReaLTaiizor.Controls.DungeonTextBox TxtWorkspaceName;
    }
}