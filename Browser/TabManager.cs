using CefSharp;
using CefSharp.WinForms;
using Chromium.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                IgnoreCertificateErrors = false
            };
            Cef.Initialize(s);
        }
        private void TabManager_Load(object sender, EventArgs e)
        {
            Tabs.NewTab += new EventHandler<string>((s, e1) => { NewTab(e1); });
            Tabs.CloseTab += new EventHandler<int>((s, e1) => { CloseTab(e1); });
        }
        public static void ShowFormInContainerControl(Control ctl, Form frm)
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Visible = true;
            ctl.Controls.Add(frm);
        }
        int tabsindex = 0;
        readonly Dictionary<int, Control> tabsList = new Dictionary<int, Control>();
        readonly Dictionary<int, Control> tabsList1 = new Dictionary<int, Control>();
        readonly Dictionary<int, Control> tabsList2 = new Dictionary<int, Control>();
        private void CreateTabManager()
        {
            this.Invoke(new Action(() =>
            {
                string url = Program.s.Startpage;
                #region init
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
                #region init
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
        private void NewTab(string url)
        {
            this.Invoke(new Action(() =>
            {
                var site = new WebTab(url);
                #region init
                Panel tabtop = new Panel();
                Panel tabview = new Panel();
                PictureBox icon = new PictureBox();
                PictureBox close = new PictureBox();
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
                ShowFormInContainerControl(tabview, site);

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

        private void CloseTab(int ti)
        {
            try { tabsList[ti].Dispose(); } catch (Exception ex) { MessageBox.Show(ex.ToString());}
            try { tabsList1[ti].Dispose(); } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            try { tabsList2[ti].Dispose(); } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
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
    }
}
