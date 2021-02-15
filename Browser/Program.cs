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
            //load browser settings if they exist
            if (File.Exists("browser.setting"))
            {
                s = DotDat.Load<WebBrowserSettings>("browser.setting");
                s.Init();
            }
            try
            {
                // run app
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Data.MainForm = new TabManager();
                Application.Run(Data.MainForm);
                //delete old favicons after close
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
            // Save browser settings
            DotDat.Save<WebBrowserSettings>("browser.setting", s);
        }
    }
}
