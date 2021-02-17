using CefSharp;
using CefSharp.WinForms;
using Chromium.Additional;
using Chromium.Properties;
using Chromium.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromium
{
    public partial class TabManager : Form
    {
        public TabManager()
        {
            InitializeComponent();
            var s = new CefSettings()
            {
                CachePath = Environment.CurrentDirectory + "/Cache",
                IgnoreCertificateErrors = true
            };
            Cef.Initialize(s);
        }
        private void TabManager_Load(object sender, EventArgs e)
        {
            Tabs.NewTab += new EventHandler<string>((s, e1) => { NewTab(e1); });
            Tabs.CloseTab += new EventHandler<int>((s, e1) => { CloseTab(e1); });
        }
        public static void ShowFormInContainerControl(Control ctl, Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Visible = true;
            ctl.Controls.Add(form);
        }
        int tabsindex = 0;
        // Item lists
        readonly Dictionary<int, Control> tabsList = new Dictionary<int, Control>();
        readonly Dictionary<int, Control> tabsList1 = new Dictionary<int, Control>();
        readonly Dictionary<int, Control> tabsList2 = new Dictionary<int, Control>();
        private void CreateTabManager()
        {
            this.Invoke(new Action(() =>
            {
                string url = Program.s.Startpage;
                #region Initialize TabManager Design
                Panel tabtop = new Panel();
                PictureBox icon = new PictureBox();

                tabtop.Width = 40;
                tabtop.Height = 40;
                tabtop.Left = tabsindex * 151;
                tabtop.Top = 0;
                tabtop.BackColor = ColorDesigner.CurrentDesign.Background;
                tabtop.Click += new EventHandler((s, e) =>
                {
                    Tabs.New(url);
                });

                icon.Height = 20;
                icon.Width = 20;
                icon.Top = 10;
                icon.Left = 10;
                icon.SizeMode = PictureBoxSizeMode.Zoom;
                icon.Image = ColorDesigner.CurrentDesign.Newtab;
                icon.Click += new EventHandler((s, e) =>
                {
                    Tabs.New(url);
                });

                Panel ol = new Panel
                {
                    Top = tabtop.Top - 1,
                    Left = tabtop.Left - 1,
                    Width = tabtop.Width + 1 + 1,
                    Height = tabtop.Height + 1 + 1,
                    BackColor = ColorDesigner.CurrentDesign.Outlines,
                    Anchor = tabtop.Anchor
                };
                ol.ToRoundedCorners(3);
                tabtop.ToRoundedCorners(3);
                #endregion

                this.Controls.Add(tabtop);
                this.Controls.Add(ol);
                tabtop.Controls.Add(icon);
                tabsList1[tabsindex] = tabtop;
                tabsList2[tabsindex] = ol;
            }));
        }
        private void CreateSettingsManager()
        {
            this.Invoke(new Action(() =>
            {
                #region Initialize Settings Button
                Panel tabtop = new Panel();
                PictureBox icon = new PictureBox();

                tabtop.Width = 40;
                tabtop.Height = 40;
                tabtop.Left = this.Width - 61;
                tabtop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                tabtop.Top = 0;
                tabtop.BackColor = ColorDesigner.CurrentDesign.Background;
                tabtop.Click += new EventHandler((s, e) =>
                {
                    new WebBrowserSettingsUi().ShowDialog();
                });

                icon.Height = 20;
                icon.Width = 20;
                icon.Top = 10;
                icon.Left = 10;
                icon.SizeMode = PictureBoxSizeMode.Zoom;
                icon.Image = ColorDesigner.CurrentDesign.Settings;
                icon.Click += new EventHandler((s, e) =>
                {
                    new WebBrowserSettingsUi().ShowDialog();
                });

                Panel ol = new Panel
                {
                    Top = tabtop.Top - 1,
                    Left = tabtop.Left - 1,
                    Width = tabtop.Width + 1 + 1,
                    Height = tabtop.Height + 1 + 1,
                    BackColor = ColorDesigner.CurrentDesign.Outlines,
                    Anchor = tabtop.Anchor
                };
                ol.ToRoundedCorners(3);
                tabtop.ToRoundedCorners(3);
                #endregion

                this.Controls.Add(tabtop);
                this.Controls.Add(ol);
                tabtop.Controls.Add(icon);
                tabsList1[tabsindex] = tabtop;
                tabsList2[tabsindex] = ol;
            }));
        }
        /// <summary>
        /// Check internet connection
        /// </summary>
        /// <returns></returns>
        public static bool CheckIfOnline()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Init new tab by url
        /// </summary>
        /// <param name="url"></param>
        private void NewTab(string url)
        {
            this.Invoke(new Action(() =>
            {
                var site = new WebTab(url);
                #region Initialize Tab Controls and Browser
                //Panel for Tab
                Panel tabtop = new Panel();
                // Browser Tab
                Panel tabview = new Panel();
                // Site Icon
                PictureBox icon = new PictureBox();
                // Close Button
                PictureBox close = new PictureBox();
                // Display site title
                Label name = new Label();


                site.WebTextChanged += new EventHandler((s, e) =>
                {
                    name.Text = site.Text;
                    if (tabview.Visible)
                    {
                        this.Text = site.Text + " - Dalks Browser";
                    }
                });
                site.IconChanged += new EventHandler((s, e) =>
                {
                    icon.Image = site.Icon.ToBitmap();
                    if (tabview.Visible)
                    {
                        this.Icon = site.Icon;
                    }
                });
                tabview.Top = 40;
                tabview.Left = 0;
                tabview.Width = this.Width;
                tabview.Height = this.Height - 40;
                tabview.Anchor = (AnchorStyles)1 | (AnchorStyles)2 | (AnchorStyles)4 | (AnchorStyles)8;

                //If online show site
                //Else show offline game
                if (CheckIfOnline())
                    ShowFormInContainerControl(tabview, site);
                else
                {
                    ShowFormInContainerControl(tabview, new OfflineGame());
                    name.Text = "Sorry, you are offline!";
                }

                tabtop.Width = 150;
                tabtop.Height = 40;
                tabtop.Left = 40 + tabsindex * 151;
                tabtop.Top = 0;
                tabtop.BackColor = ColorDesigner.CurrentDesign.Background;
                tabtop.Click += new EventHandler((s, e) =>
                {
                    foreach (var v in tabsList)
                        v.Value.Visible = false;
                    tabview.Visible = true;
                    this.Text = site.Text + " - Dalks Browser";
                    this.Icon = site.Icon;
                });

                icon.Height = 20;
                icon.Width = 20;
                icon.Top = 10;
                icon.Left = 10;
                icon.SizeMode = PictureBoxSizeMode.Zoom;
                icon.Image = site.Icon.ToBitmap();
                icon.Click += new EventHandler((s, e) =>
                {
                    foreach (var v in tabsList)
                        v.Value.Visible = false;
                    tabview.Visible = true;
                    this.Text = site.Text + " - Dalks Browser";
                    this.Icon = site.Icon;
                });

                close.Height = 20;
                close.Width = 20;
                close.Top = 10;
                close.Left = 120;
                close.SizeMode = PictureBoxSizeMode.Zoom;
                close.Image = ColorDesigner.CurrentDesign.Close;
                int ti = tabsindex;
                close.Click += new EventHandler((s, e) =>
                {
                    Tabs.Close(ti);
                });

                name.Left = 40;
                name.Top = 10;
                name.AutoSize = false;
                name.Width = 80;
                name.Height = 20;
                name.TextAlign = ContentAlignment.MiddleCenter;
                name.Click += new EventHandler((s, e) =>
                {
                    foreach (var v in tabsList)
                        v.Value.Visible = false;
                    tabview.Visible = true;
                    this.Text = site.Text + " - Dalks Browser";
                    this.Icon = site.Icon;
                });

                Panel ol = new Panel
                {
                    Top = tabtop.Top - 1,
                    Left = tabtop.Left - 1,
                    Width = tabtop.Width + 1 + 1,
                    Height = tabtop.Height + 1 + 1,
                    BackColor = ColorDesigner.CurrentDesign.Outlines,
                    Anchor = tabtop.Anchor
                };
                ol.ToRoundedCorners(3);
                tabtop.ToRoundedCorners(3);
                #endregion

                // Add to Controls and lists
                this.Controls.Add(tabtop);
                this.Controls.Add(tabview);
                this.Controls.Add(ol);
                tabtop.Controls.Add(icon);
                tabtop.Controls.Add(close);
                tabtop.Controls.Add(name);
                tabsList[tabsindex] = tabview;
                tabsList1[tabsindex] = tabtop;
                tabsList2[tabsindex] = ol;
                tabsindex++;
            }));
        }
        /// <summary>
        /// Close a tab by index
        /// </summary>
        /// <param name="ti"></param>
        private void CloseTab(int ti)
        {
            //dispose tab objects
            try { tabsList[ti].Dispose(); } catch (Exception ex) { MessageBox.Show(ex.ToString());}
            try { tabsList1[ti].Dispose(); } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            try { tabsList2[ti].Dispose(); } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            //move highers lover
            foreach(var v in tabsList1)
            {
                if (v.Key > ti - 1)
                {
                    v.Value.Left -= 151;
                }
            }
            foreach (var v in tabsList2)
            {
                if (v.Key > ti - 1)
                {
                    v.Value.Left -= 151;
                }
            }
            tabsindex--;
        }

        private void TabManager_Shown(object sender, EventArgs e)
        {
            CreateTabManager();
            CreateSettingsManager();
        }

        private void TabManager_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void TabManager_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void TabManager_DragLeave(object sender, EventArgs e)
        {

        }

        private void TabManager_DragOver(object sender, DragEventArgs e)
        {

        }

        private void TabManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseDialog cd = new CloseDialog();
            if (Data.RunningDownloads != 0)
                if (cd.ShowDialog() == DialogResult.OK)
                    e.Cancel = false;
                else e.Cancel = true;
        }
    }
}
