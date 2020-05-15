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
    public partial class FrmGlobal_Parameters : Form
    {
        public FrmGlobal_Parameters()
        {
            InitializeComponent();
        }






        private void openForm(Form frm)
        {

            frm.TopLevel = false;
            frm.TopMost = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();

        }

        private void btnLoing_Click(object sender, EventArgs e)
        {
            openForm(new FrmFlushing());
        }

        private void btnFlushing_Click(object sender, EventArgs e)
        {
            openForm(new FrmFlushing());
        }

        private void btnPriming_Click(object sender, EventArgs e)
        {
            openForm(new FrmPriming());
        }

        private void btnThaching_Click(object sender, EventArgs e)
        {
            openForm(new Teaching());
        }

        private void btnWeight_Click(object sender, EventArgs e)
        {
            openForm(new FrmWeight());
        }

        private void btnNeedle_Click(object sender, EventArgs e)
        {
            openForm(new FrmNeedle());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            openForm(new Settings());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
