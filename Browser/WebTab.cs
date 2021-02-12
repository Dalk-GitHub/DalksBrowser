using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromium
{
    public partial class WebTab : Form
    {
        public WebTab()
        {
            InitializeComponent();
            chromiumWebBrowser1.BrowserSettings = new BrowserSettings
            {
                Javascript = CefState.Enabled
            };
        }
        public WebTab(string url)
        {
            InitializeComponent();
            chromiumWebBrowser1.BrowserSettings = new BrowserSettings
            {
                Javascript = CefState.Enabled
            };
            l = true;
            _url = url;
        }
        readonly string _url = "";
#pragma warning disable IDE0044 // Modifizierer "readonly" hinzufügen
        bool l = false;
#pragma warning restore IDE0044 // Modifizierer "readonly" hinzufügen
        private void Form1_Load(object sender, EventArgs e)
        {
            if(!l)
            chromiumWebBrowser1.Load("http://google.com");
            url.PaintOutlines(ColorDesigner.CurrentDesign.Outlines, 1, this,5);
        }
        bool f12 = false;
        private bool toolable = false;

        private void ChromiumWebBrowser1_KeyDown(object sender, KeyEventArgs e)
        {
            if (toolable)
            {
                if (e.KeyCode == Keys.F12)
                {
                    if (!f12)
                    {
                        chromiumWebBrowser1.ShowDevTools();
                        f12 = !f12;
                    }
                    else
                    {
                        chromiumWebBrowser1.CloseDevTools();
                        f12 = !f12;
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ChromiumWebBrowser1_KeyDown(sender, e);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void ChromiumWebBrowser1_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            toolable = true;
            chromiumWebBrowser1.LifeSpanHandler = new NewTab();
            if(l)
            chromiumWebBrowser1.Load(_url);
        }
        #region finished events
        private void ChromiumWebBrowser1_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    this.Text = e.Title;
                    WebTextChanged("", EventArgs.Empty);
                }));
            }
            catch (Exception)
            {

            }
        }

        private void Devtools_Click(object sender, EventArgs e)
        {
            if (toolable)
            {
                if (!f12)
                {
                    chromiumWebBrowser1.ShowDevTools();
                    f12 = !f12;
                }
                else
                {
                    chromiumWebBrowser1.CloseDevTools();
                    f12 = !f12;
                }
            }
        }
        public bool CheckWebsite(string URL)
        {
            try
            {
                WebClient wc = new WebClient();
                string HTMLSource = wc.DownloadString(URL);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(new Action(() =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (url.Text.StartsWith("http://"))
                        chromiumWebBrowser1.Load(url.Text);
                    else if (url.Text.StartsWith("https://"))
                        chromiumWebBrowser1.Load(url.Text);
                    else
                    {
                        if (CheckWebsite(url.Text))
                            chromiumWebBrowser1.Load(url.Text);
                        else if (CheckWebsite("http://" + url.Text))
                            chromiumWebBrowser1.Load("http://" + url.Text);
                        else if (CheckWebsite("https://" + url.Text))
                            chromiumWebBrowser1.Load("https://" + url.Text);
                        else
                        {
                            chromiumWebBrowser1.Load(Data.IncorrectUrl(url.Text));
                        }
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    this.Invoke(new Action(() =>
                    {
                        chromiumWebBrowser1.Focus();
                    }));
                }
            })));
            t.Start();
        }

        private void ChromiumWebBrowser1_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    url.Text = e.Address;
                    void rd()
                    {
                        if (dohigher)
                            visitindex++;
                        visitedUrls[visitindex] = e.Address;
                        dohigher = true;
                    }
                    rd();
                    WebClient wc = new WebClient();
                    Uri urls = new Uri(e.Address);
                    if (!Directory.Exists("./fav"))
                        Directory.CreateDirectory("./fav");
                    if (!File.Exists("./fav/" + urls.Host + ".ico"))
                    {
                        wc.DownloadFile(string.Format("http://www.google.com/s2/favicons?domain={0}", urls.Host), "./fav/" + urls.Host + ".ico");
                        fis.Add("./fav/" + urls.Host + ".ico");
                    }
                    Bitmap icon = (Bitmap)Image.FromFile("./fav/" + urls.Host + ".ico");
                    this.Icon = Icon.FromHandle(icon.GetHicon());
                    IconChanged("", EventArgs.Empty);
                }));
            }
            catch (Exception) { }
        }
        public List<string> fis = new List<string>();
        private void Url_TextChanged(object sender, EventArgs e)
        {

        }
 
        private void WebTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            fis.ForEach((s) => { try { File.Delete(s); } catch (Exception) { } });
        }

        private void WebTab_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cef.Shutdown();
            fis.ForEach((s) => { try { File.Delete(s); } catch (Exception) { } });
        }
#pragma warning disable IDE0044 // Modifizierer "readonly" hinzufügen
        Dictionary<int, string> visitedUrls = new Dictionary<int, string>();
#pragma warning restore IDE0044 // Modifizierer "readonly" hinzufügen
        int visitindex;
        private bool dohigher = true;

        private void Next_Click(object sender, EventArgs e)
        {
            try
            {
                chromiumWebBrowser1.Forward();
                previous.Enabled = true;
            }
            catch (Exception)
            {
                next.Enabled = false;
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            try
            {
                chromiumWebBrowser1.Back();
                next.Enabled = true;
            }
            catch (Exception)
            {
                previous.Enabled = false;
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Reload();
        }

        private void ChromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

        }
        public EventHandler WebTextChanged { get; set; }
        public EventHandler IconChanged { get; set; }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Next_Click(sender,e);
        }
        #endregion

        bool devtool = false;
        private void Devtoggle_Click(object sender, EventArgs e)
        {
            if (devtool)
            {
                chromiumWebBrowser1.ShowDevTools();
                devtool = !devtool;
            }
            else
            {
                chromiumWebBrowser1.CloseDevTools();
                devtool = !devtool;
            }
        }
    }
    public class NewTab : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return true;
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }
        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            Tabs.New(targetUrl);
            newBrowser = null;
            return true;
        }
    }
}