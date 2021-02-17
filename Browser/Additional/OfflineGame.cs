using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromium.Additional
{
    public partial class OfflineGame : Form
    {
        public OfflineGame()
        {
            InitializeComponent();
        }
        private void OfflineGame_Load(object sender, EventArgs e)
        {
            
        }

        private void OfflineGame_Paint(object sender, PaintEventArgs e)
        {
            Dictionary<Point, Control> ctls = new Dictionary<Point, Control>();
            //Paint random colors in panels
            Random r = new Random();
            for (int x = 0; x < this.Width; x += 10)
                for (int y = 0; y < this.Height; y += 10)
                {
                    var rdcol = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                    var gr = e.Graphics;
                    gr.DrawRectangle(new Pen(rdcol, 10F), new Rectangle(x, y, 10, 10));
                }
                this.MouseMove+= new MouseEventHandler((s1, e1) =>
                {
                    try
                    {
                        var gr = this.CreateGraphics();
                        gr.DrawEllipse(new Pen(ColorDesigner.CurrentDesign.Foreground, 8), new RectangleF(e1.X - 4 ,e1.Y - 4, 8,8));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                });
        }

        private void Redo(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
