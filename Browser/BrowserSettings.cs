using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chromium
{
    [Serializable]
    public class WebBrowserSettings
    {
        public WebBrowserSettings()
        {

        }
        public ColorDesigner.CombinedColor Design = ColorDesigner.ColorDesigns.DarkDesign;
        public string SearchRequestPrefab = "https://www.google.com/search?client=dalkbrowser&q={0}";
        public string Startpage = "https://www.google.com";
        public void Init()
        {
            ColorDesigner.CurrentDesign = Design;
        }
    }
}
