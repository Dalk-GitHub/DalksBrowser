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
                //Create Html File with Settings!
                File.WriteAllText("settings.design", @"
<!doctype html>
<html>
<head>
<style>
:root {
   --bgcol:" + ColorDesigner.CurrentDesign.Background.ToString().Replace("Color [", "rgb(").Replace("=", "").Replace("R", "").Replace("A255,", "").Replace("G", "").Replace("B", "").Replace("]", ")") +
        ";\n   --fgcol:" + ColorDesigner.CurrentDesign.Foreground.ToString().Replace("Color [", "").Replace("]", "")/*.Replace("Color [","rgb(").Replace("=","").Replace("R","").Replace("A255,","").Replace("G","").Replace("B","").Replace("]",")")*/ +
        ";\n   --olcol:" + ColorDesigner.CurrentDesign.Outlines.ToString().Replace("Color [", "rgb(").Replace("=", "").Replace("R", "").Replace("A255,", "").Replace("G", "").Replace("B", "").Replace("]", ")")
        + @";
}
body{
    background-color: var(--bgcol);
    color: var(--fgcol);
    font-family:Arial;
}
button{
    width:100%;
    border: 3px solid var(--olcol);
    border-radius: 10px;
    background-color: var(--bgcol);
    color: var(--fgcol);
    right:0;
}
input{
    width:99%;
    left:0;
    border: 3px solid var(--olcol);
    border-radius: 10px;
    background-color: var(--bgcol);
    color: var(--fgcol);
}
</style>
</head>
<body>
<!--Execute window.open() to set the values-->
<script>
function designa(){
    window.open('design://blue');
}
function designb(){
    window.open('design://dark');
}
function designc(){
    window.open('design://light');
}
function setser(){
    window.open('ser://' + document.getElementById('ser').value);
}
function setsers(){
    window.open('sers://' + document.getElementById('sers').value);
}
function clo(){
    window.open('close://');
}
</script><center>
    <h1>Design</h1>
    <button onclick='designa()'>Blue Design</button>
<p />
<button onclick='designb()'>Dark Design</button>
<p />
<button onclick='designc()'>Light Design</button>
<h1>Environment</h1>
<input type='text' id='ser' value='" + Program.s.SearchRequestPrefab+@"' />
<p />
<button onclick='setser()'>Set Search Url</button>
<p />
<input type='text' id='sers' value='" + Program.s.Startpage+@"' />
<p />
<button onclick='setsers()'>Set Startpage</button>
<p>Note: {0} gets replaced with text string to search!</p>
<p>Note: Restart the browser that changes work!</p>

<p />
<button onclick='clo()' style='width:100%'>Close</button>
</center></body>
</html>
");
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
