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
            /// <summary>
            /// Color for Outlines
            /// </summary>
            public Color Outlines
            {
                get;
                set;
            }
            /// <summary>
            /// Color for foreground
            /// </summary>
            public Color Foreground
            {
                get;
                set;
            }
            /// <summary>
            /// Color for Background
            /// </summary>
            public Color Background
            {
                get;
                set;
            }
            /// <summary>
            /// Image for Close
            /// </summary>
            public Bitmap Close
            {
                get;
                set;
            }
            /// <summary>
            /// Image for Devtools
            /// </summary>
            public Bitmap Devtools
            {
                get;
                set;
            }
            /// <summary>
            /// Image for Newtab
            /// </summary>
            public Bitmap Newtab
            {
                get;
                set;
            }
            /// <summary>
            /// Image for next
            /// </summary>
            public Bitmap Next
            {
                get;
                set;
            }
            /// <summary>
            /// Image for Previous
            /// </summary>
            public Bitmap Previous
            {
                get;
                set;
            }
            /// <summary>
            /// Image for Reload
            /// </summary>
            public Bitmap Reload
            {
                get;
                set;
            }
            /// <summary>
            /// Image for Settings
            /// </summary>
            public Bitmap Settings
            {
                get;
                set;
            }
            /// <summary>
            /// Image for reset
            /// </summary>
            public Bitmap Reset
            {
                get;
                set;
            }
        }
        public class ColorDesigns
        {
            /// <summary>
            /// Browsers dark/default Design
            /// </summary>
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
                Settings = Resources.Settings,
                Reset = Resources.Reset
            };
            /// <summary>
            /// Browsers optional light design
            /// </summary>
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
                Settings = Resources.SettingsDark,
                Reset = Resources.ResetDark
            };
            /// <summary>
            /// Browsers optional blue Design
            /// </summary>
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
                Settings = Resources.Settings,
                Reset = Resources.Reset
            };
        }
        /// <summary>
        /// Currently used Design
        /// </summary>
        public static CombinedColor CurrentDesign = ColorDesigner.ColorDesigns.DarkDesign;
    }
}
