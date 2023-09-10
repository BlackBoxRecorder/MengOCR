namespace MengOCR.Forms
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSaveConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSnapSaveDir = new System.Windows.Forms.TextBox();
            this.BtnSelectSaveDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnRebuildStore = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtKeybinding = new System.Windows.Forms.TextBox();
            this.RBtnShowMain = new System.Windows.Forms.RadioButton();
            this.RBtnNotify = new System.Windows.Forms.RadioButton();
            this.RBtnClose = new System.Windows.Forms.RadioButton();
            this.RBtnMini = new System.Windows.Forms.RadioButton();
            this.GroupCloseOpt = new System.Windows.Forms.GroupBox();
            this.GroupSnapOpt = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.GroupCloseOpt.SuspendLayout();
            this.GroupSnapOpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSaveConfig);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 67);
            this.panel1.TabIndex = 0;
            // 
            // BtnSaveConfig
            // 
            this.BtnSaveConfig.Location = new System.Drawing.Point(602, 22);
            this.BtnSaveConfig.Name = "BtnSaveConfig";
            this.BtnSaveConfig.Size = new System.Drawing.Size(75, 25);
            this.BtnSaveConfig.TabIndex = 0;
            this.BtnSaveConfig.Text = "确定";
            this.BtnSaveConfig.UseVisualStyleBackColor = true;
            this.BtnSaveConfig.Click += new System.EventHandler(this.BtnSaveConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "存储位置";
            // 
            // TxtSnapSaveDir
            // 
            this.TxtSnapSaveDir.Location = new System.Drawing.Point(88, 33);
            this.TxtSnapSaveDir.Name = "TxtSnapSaveDir";
            this.TxtSnapSaveDir.Size = new System.Drawing.Size(369, 21);
            this.TxtSnapSaveDir.TabIndex = 2;
            // 
            // BtnSelectSaveDir
            // 
            this.BtnSelectSaveDir.Location = new System.Drawing.Point(463, 33);
            this.BtnSelectSaveDir.Name = "BtnSelectSaveDir";
            this.BtnSelectSaveDir.Size = new System.Drawing.Size(75, 23);
            this.BtnSelectSaveDir.TabIndex = 3;
            this.BtnSelectSaveDir.Text = "浏览";
            this.BtnSelectSaveDir.UseVisualStyleBackColor = true;
            this.BtnSelectSaveDir.Click += new System.EventHandler(this.BtnSelectSaveDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "重建缓存";
            // 
            // BtnRebuildStore
            // 
            this.BtnRebuildStore.Location = new System.Drawing.Point(88, 65);
            this.BtnRebuildStore.Name = "BtnRebuildStore";
            this.BtnRebuildStore.Size = new System.Drawing.Size(75, 23);
            this.BtnRebuildStore.TabIndex = 5;
            this.BtnRebuildStore.Text = "重建缓存";
            this.BtnRebuildStore.UseVisualStyleBackColor = true;
            this.BtnRebuildStore.Click += new System.EventHandler(this.BtnRebuildStore_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "快捷键";
            // 
            // TxtKeybinding
            // 
            this.TxtKeybinding.Location = new System.Drawing.Point(88, 104);
            this.TxtKeybinding.Name = "TxtKeybinding";
            this.TxtKeybinding.ReadOnly = true;
            this.TxtKeybinding.Size = new System.Drawing.Size(144, 21);
            this.TxtKeybinding.TabIndex = 7;
            this.TxtKeybinding.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtKeybinding_KeyDown);
            // 
            // RBtnShowMain
            // 
            this.RBtnShowMain.AutoSize = true;
            this.RBtnShowMain.Location = new System.Drawing.Point(26, 32);
            this.RBtnShowMain.Name = "RBtnShowMain";
            this.RBtnShowMain.Size = new System.Drawing.Size(83, 16);
            this.RBtnShowMain.TabIndex = 9;
            this.RBtnShowMain.TabStop = true;
            this.RBtnShowMain.Text = "显示主窗口";
            this.RBtnShowMain.UseVisualStyleBackColor = true;
            this.RBtnShowMain.CheckedChanged += new System.EventHandler(this.RBtnShowMain_CheckedChanged);
            // 
            // RBtnNotify
            // 
            this.RBtnNotify.AutoSize = true;
            this.RBtnNotify.Location = new System.Drawing.Point(135, 32);
            this.RBtnNotify.Name = "RBtnNotify";
            this.RBtnNotify.Size = new System.Drawing.Size(71, 16);
            this.RBtnNotify.TabIndex = 10;
            this.RBtnNotify.TabStop = true;
            this.RBtnNotify.Text = "截图提醒";
            this.RBtnNotify.UseVisualStyleBackColor = true;
            this.RBtnNotify.CheckedChanged += new System.EventHandler(this.RBtnNotify_CheckedChanged);
            // 
            // RBtnClose
            // 
            this.RBtnClose.AutoSize = true;
            this.RBtnClose.Location = new System.Drawing.Point(24, 32);
            this.RBtnClose.Name = "RBtnClose";
            this.RBtnClose.Size = new System.Drawing.Size(71, 16);
            this.RBtnClose.TabIndex = 12;
            this.RBtnClose.TabStop = true;
            this.RBtnClose.Text = "退出程序";
            this.RBtnClose.UseVisualStyleBackColor = true;
            this.RBtnClose.CheckedChanged += new System.EventHandler(this.RBtnClose_CheckedChanged);
            // 
            // RBtnMini
            // 
            this.RBtnMini.AutoSize = true;
            this.RBtnMini.Location = new System.Drawing.Point(132, 32);
            this.RBtnMini.Name = "RBtnMini";
            this.RBtnMini.Size = new System.Drawing.Size(95, 16);
            this.RBtnMini.TabIndex = 13;
            this.RBtnMini.TabStop = true;
            this.RBtnMini.Text = "最小化到托盘";
            this.RBtnMini.UseVisualStyleBackColor = true;
            this.RBtnMini.CheckedChanged += new System.EventHandler(this.RBtnMini_CheckedChanged);
            // 
            // GroupCloseOpt
            // 
            this.GroupCloseOpt.Controls.Add(this.RBtnClose);
            this.GroupCloseOpt.Controls.Add(this.RBtnMini);
            this.GroupCloseOpt.Location = new System.Drawing.Point(31, 163);
            this.GroupCloseOpt.Name = "GroupCloseOpt";
            this.GroupCloseOpt.Size = new System.Drawing.Size(249, 66);
            this.GroupCloseOpt.TabIndex = 14;
            this.GroupCloseOpt.TabStop = false;
            this.GroupCloseOpt.Text = "关闭按钮";
            // 
            // GroupSnapOpt
            // 
            this.GroupSnapOpt.Controls.Add(this.RBtnShowMain);
            this.GroupSnapOpt.Controls.Add(this.RBtnNotify);
            this.GroupSnapOpt.Location = new System.Drawing.Point(303, 163);
            this.GroupSnapOpt.Name = "GroupSnapOpt";
            this.GroupSnapOpt.Size = new System.Drawing.Size(235, 66);
            this.GroupSnapOpt.TabIndex = 15;
            this.GroupSnapOpt.TabStop = false;
            this.GroupSnapOpt.Text = "截图选项";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.GroupSnapOpt);
            this.Controls.Add(this.GroupCloseOpt);
            this.Controls.Add(this.TxtKeybinding);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnRebuildStore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnSelectSaveDir);
            this.Controls.Add(this.TxtSnapSaveDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.panel1.ResumeLayout(false);
            this.GroupCloseOpt.ResumeLayout(false);
            this.GroupCloseOpt.PerformLayout();
            this.GroupSnapOpt.ResumeLayout(false);
            this.GroupSnapOpt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSaveConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSnapSaveDir;
        private System.Windows.Forms.Button BtnSelectSaveDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnRebuildStore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtKeybinding;
        private System.Windows.Forms.RadioButton RBtnShowMain;
        private System.Windows.Forms.RadioButton RBtnNotify;
        private System.Windows.Forms.RadioButton RBtnClose;
        private System.Windows.Forms.RadioButton RBtnMini;
        private System.Windows.Forms.GroupBox GroupCloseOpt;
        private System.Windows.Forms.GroupBox GroupSnapOpt;
    }
}