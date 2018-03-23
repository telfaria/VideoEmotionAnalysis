namespace VideoEmotionAnalysis
{
   public partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.APIKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkSaveFrame = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFileSelect);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "解析ファイルの指定";
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Location = new System.Drawing.Point(289, 20);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(93, 23);
            this.btnFileSelect.TabIndex = 1;
            this.btnFileSelect.Text = "ファイルの選択";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(6, 22);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(277, 19);
            this.txtFileName.TabIndex = 0;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Location = new System.Drawing.Point(295, 60);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(75, 23);
            this.btnAnalysis.TabIndex = 1;
            this.btnAnalysis.Text = "解析";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSaveFrame);
            this.groupBox2.Controls.Add(this.lblProgress);
            this.groupBox2.Controls.Add(this.pbProgress);
            this.groupBox2.Controls.Add(this.btnAnalysis);
            this.groupBox2.Location = new System.Drawing.Point(18, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 90);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "解析進捗";
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(173, 60);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(116, 23);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(6, 18);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(364, 23);
            this.pbProgress.TabIndex = 2;
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(412, 29);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(295, 149);
            this.txtInfo.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.optionsOToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 26);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitQToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(57, 22);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // quitQToolStripMenuItem
            // 
            this.quitQToolStripMenuItem.Name = "quitQToolStripMenuItem";
            this.quitQToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.quitQToolStripMenuItem.Text = "Quit(&Q)";
            this.quitQToolStripMenuItem.Click += new System.EventHandler(this.quitQToolStripMenuItem_Click);
            // 
            // optionsOToolStripMenuItem
            // 
            this.optionsOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.APIKeyToolStripMenuItem});
            this.optionsOToolStripMenuItem.Name = "optionsOToolStripMenuItem";
            this.optionsOToolStripMenuItem.Size = new System.Drawing.Size(83, 22);
            this.optionsOToolStripMenuItem.Text = "Options(&O)";
            // 
            // APIKeyToolStripMenuItem
            // 
            this.APIKeyToolStripMenuItem.Name = "APIKeyToolStripMenuItem";
            this.APIKeyToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.APIKeyToolStripMenuItem.Text = "API Key(&K)";
            this.APIKeyToolStripMenuItem.Click += new System.EventHandler(this.aPIKeyToolStripMenuItem_Click);
            // 
            // chkSaveFrame
            // 
            this.chkSaveFrame.AutoSize = true;
            this.chkSaveFrame.Location = new System.Drawing.Point(6, 64);
            this.chkSaveFrame.Name = "chkSaveFrame";
            this.chkSaveFrame.Size = new System.Drawing.Size(140, 16);
            this.chkSaveFrame.TabIndex = 4;
            this.chkSaveFrame.Text = "検出時のフレームを保存";
            this.chkSaveFrame.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 190);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem APIKeyToolStripMenuItem;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.CheckBox chkSaveFrame;
    }
}

