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
        /// <summary>
        /// Browsers Design
        /// </summary>
        public ColorDesigner.CombinedColor Design = ColorDesigner.ColorDesigns.DarkDesign;
        /// <summary>
        /// The Url used to search
        /// </summary>
        public string SearchRequestPrefab = "https://www.google.com/search?client=dalkbrowser&q={0}";
        /// <summary>
        /// Default site for new Tabs
        /// </summary>
        public string Startpage = "https://www.google.com";
        /// <summary>
        /// Initialize the Settings
        /// </summary>
        public void Init()
        {
            ColorDesigner.CurrentDesign = Design;
        }
    }
}
