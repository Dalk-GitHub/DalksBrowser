using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chromium
{
    public class Data
    {
        public static string IncorrectUrl(string url)
        {
            string st = "https://www.google.com/search?client=dalkbrowser&q="+url;
            return st;
        }
    }
}
