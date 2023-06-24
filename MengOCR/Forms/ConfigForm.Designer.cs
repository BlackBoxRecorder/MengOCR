﻿namespace MengOCR.Forms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSaveConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSnapSaveDir = new System.Windows.Forms.TextBox();
            this.BtnSelectSaveDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnRebuildStore = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.BtnRebuildStore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnSelectSaveDir);
            this.Controls.Add(this.TxtSnapSaveDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.panel1.ResumeLayout(false);
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
    }
}