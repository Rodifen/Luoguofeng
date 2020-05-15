using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LuoGuoFeng
{
    public partial class FrmSet : Form
    {
        public FrmSet()
        {
            InitializeComponent();
            showBar(btnProgram);
            openForm(new FrmProgram());
        }

        

        private void openForm(Form frm)
        {

            frm.TopLevel = false;
            frm.TopMost = false;
            this.panel_Main.Controls.Clear();
            this.panel_Main.Controls.Add(frm);
            frm.Show();

        }

        private void showBar(Button btn)
        {
            this.label1.Location = new Point(btn.Location.X +180, btn.Location.Y+10);
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            showBar(btnProgram);
            openForm(new FrmProgram());
        }

        private void btn_axis_Click(object sender, EventArgs e)
        {
            showBar(btn_axis);
            openForm(new FrmAxisData());
        }

        private void btnSys_Click(object sender, EventArgs e)
        {
            showBar(btnSys);
            openForm(new FrmSystemSet());
        }

        private void btnMCM_Click(object sender, EventArgs e)
        {
            showBar(btnMCM);
            openForm(new FrmMCM());
        }



    }
}
