namespace Presentation
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.barPanel = new System.Windows.Forms.Panel();
            this.progressBarPanel = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.barPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // barPanel
            // 
            this.barPanel.BackColor = System.Drawing.Color.Transparent;
            this.barPanel.Controls.Add(this.progressBarPanel);
            this.barPanel.Location = new System.Drawing.Point(0, 438);
            this.barPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barPanel.Name = "barPanel";
            this.barPanel.Size = new System.Drawing.Size(881, 14);
            this.barPanel.TabIndex = 1;
            // 
            // progressBarPanel
            // 
            this.progressBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(180)))), ((int)(((byte)(159)))));
            this.progressBarPanel.Location = new System.Drawing.Point(0, 0);
            this.progressBarPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBarPanel.Name = "progressBarPanel";
            this.progressBarPanel.Size = new System.Drawing.Size(41, 34);
            this.progressBarPanel.TabIndex = 2;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Javanese Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblVersion.Location = new System.Drawing.Point(519, 268);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(113, 91);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "v1.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(84, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(528, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(97)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.barPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.barPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel barPanel;
        private System.Windows.Forms.Panel progressBarPanel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}