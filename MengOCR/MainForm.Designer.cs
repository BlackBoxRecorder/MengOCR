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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuWorkspace = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNewWorkspace = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRenameWorkSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelWorkspace = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtKeyword = new System.Windows.Forms.TextBox();
            this.BtnRunOCR = new System.Windows.Forms.Button();
            this.BtnCopyResult = new System.Windows.Forms.Button();
            this.BtnSnapshot = new System.Windows.Forms.Button();
            this.CmbWorkspace = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListBoxImgFiles = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TxtOCRResult = new System.Windows.Forms.RichTextBox();
            this.PicBoxSnap = new System.Windows.Forms.PictureBox();
            this.StatusStripBar = new System.Windows.Forms.StatusStrip();
            this.BtnStateSpaceSeparate = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnStateSpaceDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnStateSpaceEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIconOCR = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuFileList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuFileRename = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPdfOCR = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVideoOCR = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxSnap)).BeginInit();
            this.StatusStripBar.SuspendLayout();
            this.MenuFileList.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuWorkspace,
            this.MenuConfig,
            this.MenuPdfOCR,
            this.MenuVideoOCR});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(944, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MenuWorkspace
            // 
            this.MenuWorkspace.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNewWorkspace,
            this.MenuRenameWorkSpace,
            this.MenuDelWorkspace});
            this.MenuWorkspace.Name = "MenuWorkspace";
            this.MenuWorkspace.Size = new System.Drawing.Size(56, 21);
            this.MenuWorkspace.Text = "工作区";
            // 
            // MenuNewWorkspace
            // 
            this.MenuNewWorkspace.Name = "MenuNewWorkspace";
            this.MenuNewWorkspace.Size = new System.Drawing.Size(112, 22);
            this.MenuNewWorkspace.Text = "新建";
            this.MenuNewWorkspace.Click += new System.EventHandler(this.MenuNewWorkspace_Click);
            // 
            // MenuRenameWorkSpace
            // 
            this.MenuRenameWorkSpace.Name = "MenuRenameWorkSpace";
            this.MenuRenameWorkSpace.Size = new System.Drawing.Size(112, 22);
            this.MenuRenameWorkSpace.Text = "重命名";
            this.MenuRenameWorkSpace.Click += new System.EventHandler(this.MenuRenameWorkSpace_Click);
            // 
            // MenuDelWorkspace
            // 
            this.MenuDelWorkspace.Name = "MenuDelWorkspace";
            this.MenuDelWorkspace.Size = new System.Drawing.Size(112, 22);
            this.MenuDelWorkspace.Text = "删除";
            this.MenuDelWorkspace.Click += new System.EventHandler(this.MenuDelWorkspace_Click);
            // 
            // MenuConfig
            // 
            this.MenuConfig.Name = "MenuConfig";
            this.MenuConfig.Size = new System.Drawing.Size(44, 21);
            this.MenuConfig.Text = "设置";
            this.MenuConfig.Click += new System.EventHandler(this.MenuConfig_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.BtnRunOCR);
            this.panel1.Controls.Add(this.BtnCopyResult);
            this.panel1.Controls.Add(this.BtnSnapshot);
            this.panel1.Controls.Add(this.CmbWorkspace);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 44);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnSearch);
            this.panel2.Controls.Add(this.TxtKeyword);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(658, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 44);
            this.panel2.TabIndex = 4;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(196, 8);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 25);
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtKeyword
            // 
            this.TxtKeyword.Location = new System.Drawing.Point(30, 10);
            this.TxtKeyword.Name = "TxtKeyword";
            this.TxtKeyword.Size = new System.Drawing.Size(160, 21);
            this.TxtKeyword.TabIndex = 0;
            // 
            // BtnRunOCR
            // 
            this.BtnRunOCR.Location = new System.Drawing.Point(332, 10);
            this.BtnRunOCR.Name = "BtnRunOCR";
            this.BtnRunOCR.Size = new System.Drawing.Size(75, 25);
            this.BtnRunOCR.TabIndex = 3;
            this.BtnRunOCR.Text = "识别";
            this.BtnRunOCR.UseVisualStyleBackColor = true;
            this.BtnRunOCR.Click += new System.EventHandler(this.BtnRunOCR_Click);
            // 
            // BtnCopyResult
            // 
            this.BtnCopyResult.Location = new System.Drawing.Point(251, 10);
            this.BtnCopyResult.Name = "BtnCopyResult";
            this.BtnCopyResult.Size = new System.Drawing.Size(75, 25);
            this.BtnCopyResult.TabIndex = 2;
            this.BtnCopyResult.Text = "复制";
            this.BtnCopyResult.UseVisualStyleBackColor = true;
            this.BtnCopyResult.Click += new System.EventHandler(this.BtnCopyResult_Click);
            // 
            // BtnSnapshot
            // 
            this.BtnSnapshot.Location = new System.Drawing.Point(170, 10);
            this.BtnSnapshot.Name = "BtnSnapshot";
            this.BtnSnapshot.Size = new System.Drawing.Size(75, 25);
            this.BtnSnapshot.TabIndex = 1;
            this.BtnSnapshot.Text = "截图";
            this.BtnSnapshot.UseVisualStyleBackColor = true;
            this.BtnSnapshot.Click += new System.EventHandler(this.BtnSnapshot_Click);
            // 
            // CmbWorkspace
            // 
            this.CmbWorkspace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbWorkspace.FormattingEnabled = true;
            this.CmbWorkspace.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CmbWorkspace.Location = new System.Drawing.Point(13, 12);
            this.CmbWorkspace.Name = "CmbWorkspace";
            this.CmbWorkspace.Size = new System.Drawing.Size(150, 20);
            this.CmbWorkspace.TabIndex = 1;
            this.CmbWorkspace.SelectedIndexChanged += new System.EventHandler(this.CmbWorkspace_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 69);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListBoxImgFiles);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(944, 432);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // ListBoxImgFiles
            // 
            this.ListBoxImgFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxImgFiles.FormattingEnabled = true;
            this.ListBoxImgFiles.ItemHeight = 12;
            this.ListBoxImgFiles.Location = new System.Drawing.Point(8, 2);
            this.ListBoxImgFiles.Name = "ListBoxImgFiles";
            this.ListBoxImgFiles.Size = new System.Drawing.Size(232, 428);
            this.ListBoxImgFiles.TabIndex = 0;
            this.ListBoxImgFiles.SelectedIndexChanged += new System.EventHandler(this.ListBoxImgFiles_SelectedIndexChanged);
            this.ListBoxImgFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListBoxImgFiles_MouseUp);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TxtOCRResult);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.PicBoxSnap);
            this.splitContainer2.Size = new System.Drawing.Size(702, 432);
            this.splitContainer2.SplitterDistance = 320;
            this.splitContainer2.TabIndex = 0;
            // 
            // TxtOCRResult
            // 
            this.TxtOCRResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtOCRResult.Location = new System.Drawing.Point(2, 2);
            this.TxtOCRResult.Margin = new System.Windows.Forms.Padding(20);
            this.TxtOCRResult.Name = "TxtOCRResult";
            this.TxtOCRResult.Size = new System.Drawing.Size(316, 428);
            this.TxtOCRResult.TabIndex = 0;
            this.TxtOCRResult.Text = "";
            // 
            // PicBoxSnap
            // 
            this.PicBoxSnap.BackColor = System.Drawing.SystemColors.Info;
            this.PicBoxSnap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxSnap.Location = new System.Drawing.Point(0, 0);
            this.PicBoxSnap.Name = "PicBoxSnap";
            this.PicBoxSnap.Padding = new System.Windows.Forms.Padding(2);
            this.PicBoxSnap.Size = new System.Drawing.Size(378, 432);
            this.PicBoxSnap.TabIndex = 0;
            this.PicBoxSnap.TabStop = false;
            this.PicBoxSnap.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.PicBoxSnap_LoadCompleted);
            // 
            // StatusStripBar
            // 
            this.StatusStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnStateSpaceSeparate});
            this.StatusStripBar.Location = new System.Drawing.Point(0, 478);
            this.StatusStripBar.Name = "StatusStripBar";
            this.StatusStripBar.Size = new System.Drawing.Size(944, 23);
            this.StatusStripBar.TabIndex = 3;
            this.StatusStripBar.Text = "statusStrip1";
            // 
            // BtnStateSpaceSeparate
            // 
            this.BtnStateSpaceSeparate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnStateSpaceSeparate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnStateSpaceDisable,
            this.BtnStateSpaceEnable});
            this.BtnStateSpaceSeparate.Image = ((System.Drawing.Image)(resources.GetObject("BtnStateSpaceSeparate.Image")));
            this.BtnStateSpaceSeparate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnStateSpaceSeparate.Name = "BtnStateSpaceSeparate";
            this.BtnStateSpaceSeparate.Size = new System.Drawing.Size(69, 21);
            this.BtnStateSpaceSeparate.Text = "空格分隔";
            this.BtnStateSpaceSeparate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnStateSpaceSeparate.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BtnStateSpaceSeparate_DropDownItemClicked);
            // 
            // BtnStateSpaceDisable
            // 
            this.BtnStateSpaceDisable.Checked = true;
            this.BtnStateSpaceDisable.CheckOnClick = true;
            this.BtnStateSpaceDisable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BtnStateSpaceDisable.Name = "BtnStateSpaceDisable";
            this.BtnStateSpaceDisable.Size = new System.Drawing.Size(160, 22);
            this.BtnStateSpaceDisable.Text = "不使用空格分隔";
            this.BtnStateSpaceDisable.Click += new System.EventHandler(this.BtnStateSpaceDisable_Click);
            // 
            // BtnStateSpaceEnable
            // 
            this.BtnStateSpaceEnable.CheckOnClick = true;
            this.BtnStateSpaceEnable.Name = "BtnStateSpaceEnable";
            this.BtnStateSpaceEnable.Size = new System.Drawing.Size(160, 22);
            this.BtnStateSpaceEnable.Text = "使用空格分隔";
            this.BtnStateSpaceEnable.Click += new System.EventHandler(this.BtnStateSpaceEnable_Click);
            // 
            // NotifyIconOCR
            // 
            this.NotifyIconOCR.Text = "notifyIcon1";
            this.NotifyIconOCR.Visible = true;
            this.NotifyIconOCR.Click += new System.EventHandler(this.NotifyIconOCR_Click);
            // 
            // MenuFileList
            // 
            this.MenuFileList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileRename,
            this.MenuFileDelete});
            this.MenuFileList.Name = "MenuFileList";
            this.MenuFileList.Size = new System.Drawing.Size(113, 48);
            // 
            // MenuFileRename
            // 
            this.MenuFileRename.Name = "MenuFileRename";
            this.MenuFileRename.Size = new System.Drawing.Size(112, 22);
            this.MenuFileRename.Text = "重命名";
            this.MenuFileRename.Click += new System.EventHandler(this.MenuFileRename_Click);
            // 
            // MenuFileDelete
            // 
            this.MenuFileDelete.Name = "MenuFileDelete";
            this.MenuFileDelete.Size = new System.Drawing.Size(112, 22);
            this.MenuFileDelete.Text = "删除";
            this.MenuFileDelete.Click += new System.EventHandler(this.MenuFileDelete_Click);
            // 
            // MenuPdfOCR
            // 
            this.MenuPdfOCR.Name = "MenuPdfOCR";
            this.MenuPdfOCR.Size = new System.Drawing.Size(66, 21);
            this.MenuPdfOCR.Text = "PDF识别";
            // 
            // MenuVideoOCR
            // 
            this.MenuVideoOCR.Name = "MenuVideoOCR";
            this.MenuVideoOCR.Size = new System.Drawing.Size(70, 21);
            this.MenuVideoOCR.Text = "视频OCR";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.StatusStripBar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "萌萌哒OCR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_LoadAsync);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxSnap)).EndInit();
            this.StatusStripBar.ResumeLayout(false);
            this.StatusStripBar.PerformLayout();
            this.MenuFileList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuWorkspace;
        private System.Windows.Forms.ToolStripMenuItem MenuNewWorkspace;
        private System.Windows.Forms.ToolStripMenuItem MenuConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox TxtOCRResult;
        private System.Windows.Forms.PictureBox PicBoxSnap;
        private System.Windows.Forms.StatusStrip StatusStripBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtKeyword;
        private System.Windows.Forms.Button BtnRunOCR;
        private System.Windows.Forms.Button BtnCopyResult;
        private System.Windows.Forms.Button BtnSnapshot;
        private System.Windows.Forms.ComboBox CmbWorkspace;
        private System.Windows.Forms.ListBox ListBoxImgFiles;
        private System.Windows.Forms.NotifyIcon NotifyIconOCR;
        private System.Windows.Forms.ContextMenuStrip MenuFileList;
        private System.Windows.Forms.ToolStripMenuItem MenuFileRename;
        private System.Windows.Forms.ToolStripMenuItem MenuFileDelete;
        private System.Windows.Forms.ToolStripMenuItem MenuRenameWorkSpace;
        private System.Windows.Forms.ToolStripMenuItem MenuDelWorkspace;
        private System.Windows.Forms.ToolStripDropDownButton BtnStateSpaceSeparate;
        private System.Windows.Forms.ToolStripMenuItem BtnStateSpaceDisable;
        private System.Windows.Forms.ToolStripMenuItem BtnStateSpaceEnable;
        private System.Windows.Forms.ToolStripMenuItem MenuPdfOCR;
        private System.Windows.Forms.ToolStripMenuItem MenuVideoOCR;
    }
}

