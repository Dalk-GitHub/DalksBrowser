using CefSharp;
using CefSharp.Handler;
using CefSharp.WinForms;
using Chromium.Additional;
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
#pragma warning disable IDE0044
        bool l = false;
#pragma warning restore IDE0044
        private void Form1_Load(object sender, EventArgs e)
        {
            if(!l)
            chromiumWebBrowser1.Load("http://google.com");
            url.PaintOutlines(ColorDesigner.CurrentDesign.Outlines, 1, this,5);
        }
        private bool toolable = false;

        private void ChromiumWebBrowser1_KeyDown(object sender, KeyEventArgs e)
        {
            if (toolable)
            {
                // toggle dev tools
                if (e.KeyCode == Keys.F12)
                {
                    if (!KeyHandler.Devtools)
                    {
                        chromiumWebBrowser1.ShowDevTools();
                        KeyHandler.Devtools = true;
                    }
                    else
                    {
                        chromiumWebBrowser1.CloseDevTools();
                        KeyHandler.Devtools = false;
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
        KeyWebHandler KeyHandler = new KeyWebHandler();
        /// <summary>
        /// Load page url
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ChromiumWebBrowser1_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            toolable = true;
            chromiumWebBrowser1.LifeSpanHandler = new NewTab();
            chromiumWebBrowser1.KeyboardHandler = new Keyhandler();
            chromiumWebBrowser1.JsDialogHandler = new JSHandler();
            chromiumWebBrowser1.DownloadHandler = new FileDownloadHandle();
            chromiumWebBrowser1.KeyboardHandler = KeyHandler;
            if(l)
            chromiumWebBrowser1.Load(_url);
        }
        #region finished events
        /// <summary>
        /// Update tab title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Check if server is reachable
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public bool CheckWebsite(string URL)
        {
            try
            {
                WebClient wc = new WebClient();
                string testing = wc.DownloadString(URL);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Key press in url bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Seturl()
        {
            Thread t = new Thread(new ThreadStart(new Action(() =>
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
                this.Invoke(new Action(() =>
                {
                    chromiumWebBrowser1.Focus();
                }));

            })));
            t.Start();
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        /// <summary>
        /// Update and download icon = websites favicon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChromiumWebBrowser1_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    url.Text = e.Address;
                    /*void rd()
                    {
                        if (dohigher)
                            visitindex++;
                        visitedUrls[visitindex] = e.Address;
                        dohigher = true;
                    }
                    rd();*/
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
            if(url.Text.Replace("\r","").Replace("\n","") != url.Text)
            {
                url.Text = url.Text.Replace("\r", "").Replace("\n", "");
                Seturl();
            }
        }
 
        private void WebTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            fis.ForEach((s) => { try { File.Delete(s); } catch (Exception) { } });
        }

        private void WebTab_FormClosed(object sender, FormClosedEventArgs e)
        {
            fis.ForEach((s) => { try { File.Delete(s); } catch (Exception) { } });
        }
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
        /// <summary>
        /// Go back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Reload page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reload_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Reload();
        }

        private void ChromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

        }
        public EventHandler WebTextChanged { get; set; }
        public EventHandler IconChanged { get; set; }
        /// <summary>
        /// Execute next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Next_Click(sender,e);
        }
        #endregion
        private void Devtoggle_Click(object sender, EventArgs e)
        {
            if (!KeyHandler.Devtools)
            {
                chromiumWebBrowser1.ShowDevTools();
                KeyHandler.Devtools = true;
            }
            else
            {
                chromiumWebBrowser1.CloseDevTools();
                KeyHandler.Devtools = false;
            }
        }

        private void ChromiumWebBrowser1_JavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            MessageBox.Show((string)e.Message);
        }

        private void Scres_Click(object sender, EventArgs e)
        {
            Data.Screenshot();
        }
    }

    public class NewTab : ILifeSpanHandler
    {
        /// <summary>
    /// 
    /// </summary>
    /// <param name="chromiumWebBrowser"></param>
    /// <param name="browser"></param>
    /// <returns></returns>
        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chromiumWebBrowser"></param>
        /// <param name="browser"></param>
        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chromiumWebBrowser"></param>
        /// <param name="browser"></param>
        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }
        /// <summary>
        /// Handle tab opened
        /// </summary>
        /// <param name="chromiumWebBrowser"></param>
        /// <param name="browser"></param>
        /// <param name="frame"></param>
        /// <param name="targetUrl"></param>
        /// <param name="targetFrameName"></param>
        /// <param name="targetDisposition"></param>
        /// <param name="userGesture"></param>
        /// <param name="popupFeatures"></param>
        /// <param name="windowInfo"></param>
        /// <param name="browserSettings"></param>
        /// <param name="noJavascriptAccess"></param>
        /// <param name="newBrowser"></param>
        /// <returns></returns>
        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            Tabs.New(targetUrl);
            newBrowser = null;
            return true;
        }
    }
}