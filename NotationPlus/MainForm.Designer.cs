namespace NotationPlus
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_OpenMidi = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.mainView = new System.Windows.Forms.PictureBox();
            this.dlgOpenMidi = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslZoomRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuMain.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(546, 25);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile_OpenMidi});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(58, 21);
            this.tsmiFile.Text = "文件(&F)";
            // 
            // tsmiFile_OpenMidi
            // 
            this.tsmiFile_OpenMidi.Name = "tsmiFile_OpenMidi";
            this.tsmiFile_OpenMidi.Size = new System.Drawing.Size(118, 22);
            this.tsmiFile_OpenMidi.Text = "打开(&O)";
            this.tsmiFile_OpenMidi.Click += new System.EventHandler(this.tsmiFile_OpenMidi_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.Controls.Add(this.hScrollBar1);
            this.pnlContainer.Controls.Add(this.mainView);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 25);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(546, 352);
            this.pnlContainer.TabIndex = 1;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 334);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(546, 18);
            this.hScrollBar1.TabIndex = 1;
            // 
            // mainView
            // 
            this.mainView.BackColor = System.Drawing.Color.White;
            this.mainView.Location = new System.Drawing.Point(0, 0);
            this.mainView.Name = "mainView";
            this.mainView.Padding = new System.Windows.Forms.Padding(50);
            this.mainView.Size = new System.Drawing.Size(165, 144);
            this.mainView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainView.TabIndex = 0;
            this.mainView.TabStop = false;
            this.mainView.Paint += new System.Windows.Forms.PaintEventHandler(this.mainView_Paint);
            // 
            // dlgOpenMidi
            // 
            this.dlgOpenMidi.Filter = "(*.mid)|*.mid";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslZoomRate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 377);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(546, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslZoomRate
            // 
            this.tsslZoomRate.Name = "tsslZoomRate";
            this.tsslZoomRate.Size = new System.Drawing.Size(40, 17);
            this.tsslZoomRate.Text = "100%";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 399);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "StavePlus";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_OpenMidi;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.OpenFileDialog dlgOpenMidi;
        private System.Windows.Forms.PictureBox mainView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslZoomRate;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}

