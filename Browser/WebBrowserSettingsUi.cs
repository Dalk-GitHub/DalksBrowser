﻿using CefSharp;
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
</style>
</head>
<body>
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
</script><center>
    <h1>Design</h1>
    <button onclick='designa()'>Blue Design</button>
<p />
<button onclick='designb()'>Dark Design</button>
<p />
<button onclick='designc()'>Light Design</button>
<p>Note: Restart the browser that changes work!</p>
</center></body>
</html>
");
                chromiumWebBrowser1.LifeSpanHandler = new SettingHandler();
                chromiumWebBrowser1.LoadHtml(File.ReadAllText("settings.design"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ChromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

        }
    }
    public class SettingHandler : ILifeSpanHandler
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
