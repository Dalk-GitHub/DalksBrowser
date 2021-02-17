using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromium
{
    public partial class DownloadBox : Form
    {
        private DwlInf Infos { get; set; }
        public DownloadBox(DwlInf inf)
        {
            Infos = inf;
            InitializeComponent();
        }

        private void DownloadBox_Load(object sender, EventArgs e)
        {
            this.ToRoundedCorners(15);
            label1.PaintOutlines(ColorDesigner.CurrentDesign.Outlines,1,this,15);
            label2.PaintOutlines(ColorDesigner.CurrentDesign.Outlines,1,this,15);
            //label5.Text = "Speed: " + Infos.Speed.ToString();
            label5.Text = "Url: " + Infos.Url;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
