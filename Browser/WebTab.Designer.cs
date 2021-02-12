
namespace Chromium
{
    partial class WebTab
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebTab));
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.url = new System.Windows.Forms.TextBox();
            this.devtoggle = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.PictureBox();
            this.reload = new System.Windows.Forms.PictureBox();
            this.previous = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.devtoggle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previous)).BeginInit();
            this.SuspendLayout();
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(0, 43);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(1223, 582);
            this.chromiumWebBrowser1.TabIndex = 0;
            this.chromiumWebBrowser1.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.ChromiumWebBrowser1_LoadingStateChanged);
            this.chromiumWebBrowser1.AddressChanged += new System.EventHandler<CefSharp.AddressChangedEventArgs>(this.ChromiumWebBrowser1_AddressChanged);
            this.chromiumWebBrowser1.TitleChanged += new System.EventHandler<CefSharp.TitleChangedEventArgs>(this.ChromiumWebBrowser1_TitleChanged);
            this.chromiumWebBrowser1.IsBrowserInitializedChanged += new System.EventHandler(this.ChromiumWebBrowser1_IsBrowserInitializedChanged);
            this.chromiumWebBrowser1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChromiumWebBrowser1_KeyDown);
            // 
            // url
            // 
            this.url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.url.BackColor = ColorDesigner.CurrentDesign.Background;
            this.url.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.url.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.url.ForeColor = ColorDesigner.CurrentDesign.Foreground;
            this.url.Location = new System.Drawing.Point(106, 10);
            this.url.Name = "url";
            this.url.Multiline = true;
            this.url.Size = new System.Drawing.Size(1087, 23);
            this.url.TabIndex = 1;
            this.url.Text = "http://google.com";
            this.url.TextChanged += new System.EventHandler(this.Url_TextChanged);
            this.url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // devtoggle
            // 
            this.devtoggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.devtoggle.Image = ColorDesigner.CurrentDesign.Devtools;
            this.devtoggle.Location = new System.Drawing.Point(1199, 8);
            this.devtoggle.Name = "devtoggle";
            this.devtoggle.Size = new System.Drawing.Size(26, 26);
            this.devtoggle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.devtoggle.TabIndex = 5;
            this.devtoggle.TabStop = false;
            this.devtoggle.Click += new System.EventHandler(this.Devtoggle_Click);
            // 
            // next
            // 
            this.next.Image = ColorDesigner.CurrentDesign.Next;
            this.next.Location = new System.Drawing.Point(42, 8);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(26, 26);
            this.next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.next.TabIndex = 4;
            this.next.TabStop = false;
            this.next.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // reload
            // 
            this.reload.Image = ColorDesigner.CurrentDesign.Reload;
            this.reload.Location = new System.Drawing.Point(74, 8);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(26, 26);
            this.reload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.reload.TabIndex = 3;
            this.reload.TabStop = false;
            this.reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // previous
            // 
            this.previous.Image = ColorDesigner.CurrentDesign.Previous;
            this.previous.Location = new System.Drawing.Point(10, 8);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(26, 26);
            this.previous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previous.TabIndex = 2;
            this.previous.TabStop = false;
            this.previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // WebTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ColorDesigner.CurrentDesign.Background;
            this.ClientSize = new System.Drawing.Size(1240, 665);
            this.Controls.Add(this.devtoggle);
            this.Controls.Add(this.next);
            this.Controls.Add(this.reload);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.url);
            this.Controls.Add(this.chromiumWebBrowser1);
            this.ForeColor = ColorDesigner.CurrentDesign.Foreground;
            this.Name = "WebTab";
            this.Text = "New Tab";
            this.Icon = Chromium.Properties.Resources.favicon;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebTab_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WebTab_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.devtoggle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previous)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.PictureBox previous;
        private System.Windows.Forms.PictureBox reload;
        private System.Windows.Forms.PictureBox next;
        private System.Windows.Forms.PictureBox devtoggle;
    }
}

