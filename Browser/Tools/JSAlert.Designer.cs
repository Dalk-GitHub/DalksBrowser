
namespace Chromium
{
    partial class JSAlert
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
            this.close = new System.Windows.Forms.PictureBox();
            this.webmtit = new System.Windows.Forms.Label();
            this.WMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.Image = ColorDesigner.CurrentDesign.Close;
            this.close.Location = new System.Drawing.Point(358, 12);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(30, 30);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close.TabIndex = 0;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // webmtit
            // 
            this.webmtit.Location = new System.Drawing.Point(12, 12);
            this.webmtit.Name = "webmtit";
            this.webmtit.Size = new System.Drawing.Size(340, 30);
            this.webmtit.TabIndex = 1;
            this.webmtit.Text = "Website has sent a message:";
            this.webmtit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WMessage
            // 
            this.WMessage.Location = new System.Drawing.Point(12, 56);
            this.WMessage.Name = "WMessage";
            this.WMessage.Size = new System.Drawing.Size(376, 335);
            this.WMessage.TabIndex = 2;
            this.WMessage.Text = "Webmessage";
            this.WMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // JSAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.WMessage);
            this.Controls.Add(this.webmtit);
            this.Controls.Add(this.close);
            this.ForeColor = ColorDesigner.CurrentDesign.Foreground;
            this.BackColor = ColorDesigner.CurrentDesign.Background;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.Name = "JSAlert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JSAlert";
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.Label webmtit;
        public System.Windows.Forms.Label WMessage;
    }
}