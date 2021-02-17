
namespace Chromium
{
    partial class TabManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabManager));
            this.SuspendLayout();
            // 
            // TabManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Chromium.ColorDesigner.CurrentDesign.Background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ForeColor = Chromium.ColorDesigner.CurrentDesign.Foreground;
            this.Icon = global::Chromium.Properties.Resources.favicon;
            this.Name = "TabManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dalks Browser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TabManager_FormClosing);
            this.Load += new System.EventHandler(this.TabManager_Load);
            this.Shown += new System.EventHandler(this.TabManager_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TabManager_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TabManager_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.TabManager_DragOver);
            this.DragLeave += new System.EventHandler(this.TabManager_DragLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}