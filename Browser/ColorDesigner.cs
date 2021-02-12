using Chromium.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chromium
{
    public class ColorDesigner
    {
        [Serializable]
        public  class CombinedColor
        {
            public CombinedColor()
            {

            }
            public Color Outlines
            {
                get;
                set;
            }
            public Color Foreground
            {
                get;
                set;
            }
            public Color Background
            {
                get;
                set;
            }
            public Bitmap Close
            {
                get;
                set;
            }
            public Bitmap Devtools
            {
                get;
                set;
            }
            public Bitmap Newtab
            {
                get;
                set;
            }
            public Bitmap Next
            {
                get;
                set;
            }
            public Bitmap Previous
            {
                get;
                set;
            }
            public Bitmap Reload
            {
                get;
                set;
            }
            public Bitmap Settings
            {
                get;
                set;
            }
        }
        public class ColorDesigns
        {
            public static CombinedColor DarkDesign = new CombinedColor
            {
                Outlines = Color.FromArgb(50, 50, 50),
                Background = Color.FromArgb(25,25,25),
                Foreground = Color.White,
                Close = Resources.Close,
                Devtools = Resources.Devtools,
                Newtab = Resources.Newtab,
                Next = Resources.Next,
                Previous = Resources.Previous,
                Reload = Resources.Reload,
                Settings = Resources.Settings
            };
            public static CombinedColor LightDesign = new CombinedColor
            {
                Outlines = Color.FromArgb(200,200,200),
                Background = Color.FromArgb(255,255,255),
                Close = Resources.CloseDark,
                Devtools = Resources.DevtoolsDark,
                Newtab = Resources.NewtabDark,
                Next = Resources.NextDark,
                Previous = Resources.PreviousDark,
                Reload = Resources.ReloadDark,
                Foreground = Color.Black,
                Settings = Resources.SettingsDark
            };
            public static CombinedColor BlueDesign = new CombinedColor
            {
                Outlines = Color.FromArgb(166, 188, 255),
                Background = Color.FromArgb(77, 77, 255),
                Close = Resources.Close,
                Devtools = Resources.Devtools,
                Newtab = Resources.Newtab,
                Next = Resources.Next,
                Previous = Resources.Previous,
                Reload = Resources.Reload,
                Foreground = Color.White,
                Settings = Resources.Settings
            };
        }
        public static CombinedColor CurrentDesign = ColorDesigner.ColorDesigns.DarkDesign;
    }
}
