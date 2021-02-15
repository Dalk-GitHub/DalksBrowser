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
    public partial class JSAlert : Form
    {
        public JSAlert(string msg)
        {
            InitializeComponent();
            this.ToRoundedCorners(25);
            WMessage.Text = msg;
            Data.MainForm.Invoke(new Action(() =>
            {
                this.ShowDialog();
            }));
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
