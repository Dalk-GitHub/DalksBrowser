using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromium
{
    public static class Extension
    {
        public static Control PaintOutlines(this Control c,Color color,int size,Form l,int corner = 0)
        {
            Panel ol = new Panel
            {
                Top = c.Top - size,
                Left = c.Left - size,
                Width = c.Width + size + size,
                Height = c.Height + size + size,
                BackColor = color,
                Anchor = c.Anchor
            };
            ol.ToRoundedCorners(corner);
            c.ToRoundedCorners(corner);
            l.Controls.Add(ol);

            return c;
        }
        /// <summary>
        /// Get InzPtr for Rounded Corners
        /// </summary>
        /// <param name="nLeftRect"></param>
        /// <param name="nTopRect"></param>
        /// <param name="nRightRect"></param>
        /// <param name="nBottomRect"></param>
        /// <param name="nWidthEllipse"></param>
        /// <param name="nHeightEllipse"></param>
        /// <returns></returns>
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        /// <summary>
        /// Extension method for control to create rounded corners
        /// </summary>
        /// <param name="c"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Control ToRoundedCorners(this Control c, int i)
        {
            c.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, c.Width, c.Height, i, i));
            c.Resize += new EventHandler((sender, e) => { c.ToRoundedCorners(i); });
            return c;
        }
    }
}
