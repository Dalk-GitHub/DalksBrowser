using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thread = System.Threading.Thread;
using ThreadStart = System.Threading.ThreadStart;


namespace Chromium
{
    public partial class WebBrowserSettingsUi : Form
    {
        public WebBrowserSettingsUi()
        {
            InitializeComponent();
        }

        private void ChromiumWebBrowser1_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            try
            {
                //Construct Html
                string Code = Properties.Resources.SettingsPreset
                    .Replace("{7}",Properties.Resources.SettingsCss)
                    .Replace("{6}",Properties.Resources.SettingsJs)
                    .Replace("{0}", ColorDesigner.CurrentDesign.Background.ToString().Replace("Color [", "rgb(").Replace("=", "").Replace("R", "").Replace("A255,", "").Replace("G", "").Replace("B", "").Replace("]", ")"))
                    .Replace("{1}", ColorDesigner.CurrentDesign.Foreground.ToString().Replace("Color [", "").Replace("]", ""))
                    .Replace("{2}", ColorDesigner.CurrentDesign.Outlines.ToString().Replace("Color [", "rgb(").Replace("=", "").Replace("R", "").Replace("A255,", "").Replace("G", "").Replace("B", "").Replace("]", ")"))
                    .Replace("{3}", Program.s.SearchRequestPrefab)
                    .Replace("{4}", Program.s.Startpage)
                    .Replace("{5}", "{0}");
                //Create Html File with Settings!
                File.WriteAllText("settings.design", Code);
                //Open settings In Settings Browser
                chromiumWebBrowser1.LifeSpanHandler = new SettingHandler();
                chromiumWebBrowser1.LoadHtml(File.ReadAllText("settings.design"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ST = new Thread(new ThreadStart(new Action(() =>
             {
                 while (true)
                 {
                     if (!SettingHandler.alive)
                         this.Invoke(new Action(() =>
                         {
                             this.Close();
                             ST.Abort();
                             SettingHandler.alive = true;
                         }));
                 }
            })));
            ST.Start();
        }
        Thread ST;
        private void ChromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

        }
    }
    public class SettingHandler : ILifeSpanHandler
    {
        public static bool alive = true;
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
        //Handle the Setting Actions
        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            if (targetUrl.StartsWith("ser://"))
            {
                Program.s.SearchRequestPrefab = targetUrl.Remove(0,6);
                DotDat.Save<WebBrowserSettings>("browser.setting", Program.s);
            }
            if (targetUrl.StartsWith("close://"))
            {
                DotDat.Save<WebBrowserSettings>("browser.setting", Program.s);
                SettingHandler.alive = false;
            }
            if (targetUrl.StartsWith("sers://"))
            {
                Program.s.Startpage = targetUrl.Remove(0, 7);
                DotDat.Save<WebBrowserSettings>("browser.setting", Program.s);
            }
            switch (targetUrl)
            {
                case "design://blue":
                    Program.s.Design = ColorDesigner.ColorDesigns.BlueDesign;
                    DotDat.Save<WebBrowserSettings>("browser.setting", Program.s);
                    break;
                case "design://dark":
                    Program.s.Design = ColorDesigner.ColorDesigns.DarkDesign;
                    DotDat.Save<WebBrowserSettings>("browser.setting", Program.s);
                    break;
                case "design://light":
                    Program.s.Design = ColorDesigner.ColorDesigns.LightDesign;
                    DotDat.Save<WebBrowserSettings>("browser.setting", Program.s);
                    break;
            }
            newBrowser = null;
            return true;
        }
    }
}
