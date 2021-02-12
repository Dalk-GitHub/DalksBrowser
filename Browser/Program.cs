using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromium
{
    static class Program
    {
        public static WebBrowserSettings s = new WebBrowserSettings();
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists("browser.setting"))
            {
                s = DotDat.Load<WebBrowserSettings>("browser.setting");
                s.Init();
            }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TabManager());
                try
                {
                    Directory.Delete("./fav", true);
                }
                catch (Exception) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            DotDat.Save<WebBrowserSettings>("browser.setting", s);
        }
    }
}
