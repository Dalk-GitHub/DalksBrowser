using Chromium.Additional;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chromium
{
    public class Data
    {
        /// <summary>
        /// Buils The search Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string IncorrectUrl(string url)
        {
            string st = Program.s.SearchRequestPrefab.Replace(@"{0}",url);
            return st;
        }
        public static TabManager MainForm { get; set; }
        private static string Strscrfrm()
        {
            return "./screenshots/" + 
                string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}.png",
                DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour,
                DateTime.Now.Minute, DateTime.Now.Second,
                DateTime.Now.Millisecond);
        }
        public static void Screenshot()
        {
            ScreenCapture sc = new ScreenCapture();
            Directory.CreateDirectory("./screenshots");
            sc.CaptureScreen(Data.MainForm.Handle).Save(Strscrfrm());
        }
        public static void Screenshot(IntPtr handle)
        {
            ScreenCapture sc = new ScreenCapture();
            Directory.CreateDirectory("./screenshots");
            sc.CaptureScreen(handle).Save(Strscrfrm());
        }
        public static void Screenshot(Bitmap handle)
        {
            Directory.CreateDirectory("./screenshots");
            handle.Save(Strscrfrm());
        }
    }
}
