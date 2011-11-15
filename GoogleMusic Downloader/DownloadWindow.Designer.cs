namespace GoogleMusic_Downloader
{
    partial class DownloadWindow
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.lbActivity = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.songProgressBar = new System.Windows.Forms.ProgressBar();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(13, 13);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(244, 381);
			this.listBox1.TabIndex = 0;
			// 
			// lbActivity
			// 
			this.lbActivity.AutoSize = true;
			this.lbActivity.Location = new System.Drawing.Point(263, 92);
			this.lbActivity.Name = "lbActivity";
			this.lbActivity.Size = new System.Drawing.Size(95, 13);
			this.lbActivity.TabIndex = 1;
			this.lbActivity.Text = "Now downloading:";
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Location = new System.Drawing.Point(365, 92);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(27, 13);
			this.lbTitle.TabIndex = 2;
			this.lbTitle.Text = "Title";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(266, 207);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(388, 23);
			this.progressBar1.TabIndex = 3;
			// 
			// songProgressBar
			// 
			this.songProgressBar.Location = new System.Drawing.Point(266, 124);
			this.songProgressBar.Name = "songProgressBar";
			this.songProgressBar.Size = new System.Drawing.Size(388, 23);
			this.songProgressBar.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(263, 177);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Total progress";
			// 
			// DownloadWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 401);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.songProgressBar);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.lbActivity);
			this.Controls.Add(this.listBox1);
			this.Name = "DownloadWindow";
			this.Text = "Google Music Backup - Pablo Carballude";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClose);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbActivity;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar songProgressBar;
        private System.Windows.Forms.Label label2;
    }
}