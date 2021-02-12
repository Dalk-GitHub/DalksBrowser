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
            string st = Program.s.SearchRequestPrefab.Replace(@"{0}",url);
            return st;
        }
    }
}
