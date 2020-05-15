using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoGuoFeng
{
    public partial class FrmAxisData : Form
    {
        public FrmAxisData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form test = Application.OpenForms["Axis_par"];
            if ((test == null) || (test.IsDisposed))
            {
                Axis_par men = new Axis_par();
                men.Owner = this;
                men.Show();
            }
            else
            {
                test.Activate();
            }
        }
    }
}
