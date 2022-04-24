namespace Presentation.About
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.lblLogin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("MV Boli", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(190)))), ((int)(((byte)(120)))));
            this.lblLogin.Location = new System.Drawing.Point(188, 45);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(374, 55);
            this.lblLogin.TabIndex = 7;
            this.lblLogin.Text = "¿Quiénes somos?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label2.Location = new System.Drawing.Point(87, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(592, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ronald Manuel Brito Hiraldo | 2021-0084\r\n";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(190)))), ((int)(((byte)(120)))));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(112, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 5);
            this.panel1.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(376, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(190)))), ((int)(((byte)(120)))));
            this.panel2.Location = new System.Drawing.Point(171, 325);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 5);
            this.panel2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label1.Location = new System.Drawing.Point(140, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 37);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sander Jostin Arias | 2020-10182\r\n";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(97)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}