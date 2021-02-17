using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromium.Tools
{
    public partial class CloseDialog : Form
    {
        public CloseDialog()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CloseDialog_Load(object sender, EventArgs e)
        {
            label1.PaintOutlines(ColorDesigner.CurrentDesign.Outlines, 1, this, 15);
            label2.PaintOutlines(ColorDesigner.CurrentDesign.Outlines, 1, this, 15);
            this.ToRoundedCorners(15);
        }
    }
}
