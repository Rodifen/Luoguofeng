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
    public partial class FrmTech : Form
    {
        public FrmTech()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Subscriber subscriber = new Subscriber("", Global.publisher);
            subscriber.func += RecieveData;
        }

        private void FrmTech_Load(object sender, EventArgs e)
        {

        }


        #region 定长运动


        private void Yp_button_Click(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                C_Pmove cp = new C_Pmove();
                cp.Bt = Yp_button;
                cp.TAxis = Global.Y;
                cp.Dir = 0;
                Thread move = new Thread(new ParameterizedThreadStart(Pmove));
                move.Start(cp);
                Yp_button.BackColor = Color.LawnGreen;
            }
          
        }

        private void Ys_button_Click(object sender, EventArgs e)
        {
            C_Pmove cp = new C_Pmove();
            cp.Bt = Ys_button;
            cp.TAxis = Global.Y;
            cp.Dir = 1;
            Thread move = new Thread(new ParameterizedThreadStart(Pmove));
            move.Start(cp);
        }

        private void Xp_button_Click(object sender, EventArgs e)
        {
            C_Pmove cp = new C_Pmove();
            cp.Bt = Xs_button;
            cp.TAxis = Global.X;
            cp.Dir = 0;
            Thread move = new Thread(new ParameterizedThreadStart(Pmove));
            move.Start(cp);
           // Pmove(cp);

        }

        private void Xs_button_Click(object sender, EventArgs e)
        {
            C_Pmove cp = new C_Pmove();
            cp.Bt = Xs_button;
            cp.TAxis = Global.X;
            cp.Dir = 1;
            Thread move = new Thread(new ParameterizedThreadStart(Pmove));
            move.Start(cp);
        }

        private void Zs_button_Click(object sender, EventArgs e)
        {
            C_Pmove cp = new C_Pmove();
            cp.Bt = Zs_button;
            cp.TAxis = Global.Z;
            cp.Dir = 1;
            Thread move = new Thread(new ParameterizedThreadStart(Pmove));
            move.Start(cp);
        }

        private void Zp_button_Click(object sender, EventArgs e)
        {
            C_Pmove cp = new C_Pmove();
            cp.Bt = Zp_button;
            cp.TAxis = Global.Z;
            Thread move = new Thread(new ParameterizedThreadStart(Pmove));
            move.Start(cp);
        }
        private void Pmove(object obj)
        {
            if (checkBox6.Checked == true)
            {
                //缺省   速度和距离
                C_Pmove cp = obj as C_Pmove;
                decimal len = Math.Abs(len_numericUpDown.Value);
                double dec = Convert.ToDouble(numericUpDown4.Value);
                double to = Convert.ToDouble(len);
                cp.Bt.Enabled = false;
                if (cp.Dir == 1)
                {
                    to = -to;
                }
                cp.TAxis.Pmove(to, Convert.ToDouble(speed_numericUpDown1.Value), dec, 0);
                //while (cp.TAxis.IsRun)
                //    Application.DoEvents();

                cp.Bt.Enabled = true;
            }
        }



        #endregion

        #region 定速运动
        private void Yp_button_MouseDown(object sender, MouseEventArgs e)
        {
            Vmove(Global.Y, 0);
        }

        private void Yp_button_MouseUp(object sender, MouseEventArgs e)
        {
            VStop(Global.Y);
        }

        private void Ys_button_MouseDown(object sender, MouseEventArgs e)
        {
            Vmove(Global.Y, 1);
        }

        private void Ys_button_MouseUp(object sender, MouseEventArgs e)
        {
            VStop(Global.Y);
        }

        private void Xp_button_MouseDown(object sender, MouseEventArgs e)
        {
            Vmove(Global.X, 0);
        }

        private void Xp_button_MouseUp(object sender, MouseEventArgs e)
        {
            VStop(Global.X);
        }

        private void Xs_button_MouseDown(object sender, MouseEventArgs e)
        {
            Vmove(Global.X, 1);
        }

        private void Xs_button_MouseUp(object sender, MouseEventArgs e)
        {
            VStop(Global.X);
        }

        private void Zp_button_MouseDown(object sender, MouseEventArgs e)
        {
            Vmove(Global.Z, 0);
        }

        private void Zp_button_MouseUp(object sender, MouseEventArgs e)
        {
            VStop(Global.Z);
        }

        private void Zs_button_MouseDown(object sender, MouseEventArgs e)
        {
            Vmove(Global.Z, 1);
        }

        private void Zs_button_MouseUp(object sender, MouseEventArgs e)
        {
            VStop(Global.Z);
        }

        private void Vmove(Axis axis, ushort dir)
        {
            if (checkBox6.Checked == false)
            {
                axis.Vmove(dir, Convert.ToDouble(speed_numericUpDown1.Value), 0);

            }
        }
        private void VStop(Axis axis)
        {
            //检查是否定长运动
            //if (checkBox6.Checked == false)
            //{
                axis.Pstop();

            
        }

        #endregion

        #region  回零


        private void X_ORG_Click(object sender, EventArgs e)
        {
            Global.X.ORG();
        }

        private void Y_ORG_Click(object sender, EventArgs e)
        {
            Global.Y.ORG();
        }

        private void Z_ORG_Click(object sender, EventArgs e)
        {
            Global.Z.ORG();
        }



        #endregion

        #region 使能

        
        private void X_Enable_Click(object sender, EventArgs e)
        {
            if (X_Enable.BackColor == Color.Transparent)
            {
                Global.X.Enable();
                X_Enable.BackColor = Color.Green;
            }
            else
            {
                Global.X.disEnable();
                X_Enable.BackColor = Color.Transparent;
            }

        }

        private void Y_Enable_Click(object sender, EventArgs e)
        {
            if (X_Enable.BackColor == Color.Transparent)
            {
                Global.X.Enable();
                X_Enable.BackColor = Color.Green;
            }
            else
            {
                Global.X.disEnable();
                X_Enable.BackColor = Color.Transparent;
            }

        }

        private void Z_Enable_Click(object sender, EventArgs e)
        {
            if (X_Enable.BackColor == Color.Transparent)
            {
                Global.X.Enable();
                X_Enable.BackColor = Color.Green;
            }
            else
            {
                Global.X.disEnable();
                X_Enable.BackColor = Color.Transparent;
            }

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Transparent)
            {

                Global.X.Enable();
                Global.Y.Enable();
                Global.Z.Enable();
                Global.A.Enable();
                Global.B.Enable();
                button1.BackColor = Color.Green;
            }
            else
            {
                Global.X.disEnable();
                Global.Y.disEnable();
                Global.Z.disEnable();
                Global.A.disEnable();
                Global.B.disEnable();
                button1.BackColor = Color.Transparent;
            }
        }
        #endregion

        #region ReciveData
        public void RecieveData(SendParameter sendParameter)
        {
            BtnBreakColor(Xp_button, sendParameter.AxisSensorX[0]);
            BtnBreakColor(Xs_button, sendParameter.AxisSensorX[1]);
            BtnBreakColor(Yp_button, sendParameter.AxisSensorY[0]);
            BtnBreakColor(Ys_button, sendParameter.AxisSensorY[1]);
            BtnBreakColor(Zp_button, sendParameter.AxisSensorZ[0]);
            BtnBreakColor(Zs_button, sendParameter.AxisSensorZ[1]);

        }


        private void BtnBreakColor(Button button1,bool  vs1)
        {
            if (button1.InvokeRequired)
            {
                button1.BeginInvoke(new Action(() =>
                {
                    if (vs1)
                    {
                      button1.BackColor = Color.Gainsboro;
                    }
                    else
                    {
                        button1.BackColor = Color.Gainsboro;
                    }

                }
                    ));

            }
        }
        #endregion

    }
}
