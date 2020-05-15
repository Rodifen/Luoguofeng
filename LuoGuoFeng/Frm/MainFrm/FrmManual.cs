using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoGuoFeng.Frm
{
    public partial class FrmManual : Form
    {
        public FrmManual()
        {
            InitializeComponent();
            openForm(new IO());
        }


        #region Button Event
        
        
        private void btnIO_Click(object sender, EventArgs e)
        {
            IO frm = new IO();
         
            openForm(frm);
            ShowBar(btnIO);
        }
        private void btnAxis_Click(object sender, EventArgs e)
        {
            openForm(new FrmTech());
            ShowBar(btnAxis);
        }

        private void btnGlue_Click(object sender, EventArgs e)
        {

            openForm(new FrmGlue()); 
            ShowBar(btnGlue);
        }

        private void btncalibration_Click(object sender, EventArgs e)
        {
            openForm(new FrmCalibration());
            ShowBar(btncalibration);
        }

        private void btnDrive_Click(object sender, EventArgs e)
        {
            openForm(new FrmDevice());
            ShowBar(btnDrive);
        }


        private void openForm(Form frm)
        {
          
            frm.TopLevel = false;
            frm.TopMost = false;
            this.panel_Main.Controls.Clear();
            this.panel_Main.Controls.Add(frm);
            frm.Show();

        }
        private void ShowBar(Button btn)
        {
            this.panelBar.Location = new Point(btn.Location.X, btn.Location.Y - 10);
        }
        #endregion

    }
}
