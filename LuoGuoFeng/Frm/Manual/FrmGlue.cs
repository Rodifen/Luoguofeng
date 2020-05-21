using LuoGuoFeng.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoGuoFeng
{
    public partial class FrmGlue : Form
    {
        public FrmGlue()
        {
            InitializeComponent();
            // CheckForIllegalCrossThreadCalls = false;
            label1.Text = ModelsHelper.NowModels;

            if (label1.Text == "齿轮泵")
            {

            }
            else
            {
                label10.Enabled = false;
                numericUpDown7.Enabled = false;
            }
            //

        }


        private void btnDispensing_Click(object sender, EventArgs e)
        {
            //  MotionHelper.Dispensing();
            var quality = (double)numericUpDown7.Value;
            var time = (double)numericUpDown9.Value;
            Global.Pumpdata.Calculation(quality, time, Global.A.Position);
            var task = Task.Run(() =>
            {
                if (label1.Text == "齿轮泵")
                {
                    MotionHelper.Dispensing(Global.Pumpdata);
                   
                }
                else
                {
                    MotionHelper.Dispensing(time);
                }

                //  MotionHelper.PumpMotion();
            });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var quality = (double)numericUpDown7.Value;
            var time = (double)numericUpDown9.Value;

            var task = Task.Run(() =>
            {
                MotionHelper.ReDispensing();
                //MotionHelper.PumpMotion(quality, time);
            });
         
        }

        private void Ap_button_Click(object sender, EventArgs e)
        {
            C_Pmove cp = new C_Pmove();
            cp.Bt = Ap_button;
            cp.TAxis = Global.A;
            cp.Dir = 1;
            Thread move = new Thread(new ParameterizedThreadStart(Pmove));
            move.Start(cp);
           // Yp_button.BackColor = Color.LawnGreen;
        }

        private void As_button_Click(object sender, EventArgs e)
        {
            C_Pmove cp = new C_Pmove();
            cp.Bt = As_button;
            cp.TAxis = Global.A;
            cp.Dir = 0;
            Thread move = new Thread(new ParameterizedThreadStart(Pmove));
            move.Start(cp);
        }

        private void Bp_button_Click(object sender, EventArgs e)
        {
            C_Pmove cp = new C_Pmove();
            cp.Bt = Bp_button;
            cp.TAxis = Global.B;
            cp.Dir = 0;
            Thread move = new Thread(new ParameterizedThreadStart(Pmove));
            move.Start(cp);
        }

        private void Bs_button_Click(object sender, EventArgs e)
        {
            C_Pmove cp = new C_Pmove();
            cp.Bt = Bs_button;
            cp.TAxis = Global.B;
            cp.Dir = 1;
            Thread move = new Thread(new ParameterizedThreadStart(Pmove));
            move.Start(cp);
        }

        private void Pmove(object obj)
        {
           
                //缺省   速度和距离
                C_Pmove cp = obj as C_Pmove;
                decimal len = Math.Abs(len_numericUpDown.Value);
                double dec = Convert.ToDouble(numericUpDown4.Value);
                double to = Convert.ToDouble(len);
           
                if (cp.Dir == 1)
                {
                    to = -to;
                }
                cp.TAxis.Pmove(to, Convert.ToDouble(speed_numericUpDown1.Value), dec, 0);
                while (cp.TAxis.IsRun)
                    Application.DoEvents();
        }


        private void A_OGR_Click(object sender, EventArgs e)
        {
            Global.A.ORG();
        }

        private void B_OGR_Click(object sender, EventArgs e)
        {
            Global.A.ORG();
        }

        private void A_Enable_Click(object sender, EventArgs e)
        {
            if (A_Enable.BackColor == Color.Transparent)
            {
                Global.A.Enable();
                A_Enable.BackColor = Color.Green;
            }
            else
            {
                Global.A.disEnable();
                A_Enable.BackColor = Color.Transparent;
            }
        }

        private void B_Enable_Click(object sender, EventArgs e)
        {
            if (B_Enable.BackColor == Color.Transparent)
            {
                Global.X.Enable();
               B_Enable.BackColor = Color.Green;
            }
            else
            {
                Global.B.disEnable();
               B_Enable.BackColor = Color.Transparent;
            };
        }

        private void AllEna_Click(object sender, EventArgs e)
        {
            if (AllEna.BackColor == Color.Transparent)
            {
                Global.A.Enable();
                Global.B.Enable();
                AllEna.BackColor = Color.Green;
            }
            else
            {
                Global.A.disEnable();
                Global.B.disEnable();
                AllEna.BackColor = Color.Transparent;
            }
        }

        private void FrmGlue_Load(object sender, EventArgs e)
        {

        }
    }
}
