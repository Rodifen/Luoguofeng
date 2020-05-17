using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuoGuoFeng.Frm;
using MetroFramework.Forms;

namespace LuoGuoFeng
{
    public partial class FrmMain : MetroForm
    {

        #region variable

        UserHelper userHelper = new UserHelper("");
        List<User> listUser = new List<User>();


        FrmManual frmManual = new FrmManual();
        Frm_Log frm_Log = new Frm_Log();
        FrmHome frmHome = new FrmHome();
        FrmSet frmSet = new FrmSet();
        FrmGlobal_Parameters frmGlobal_Parameters = new FrmGlobal_Parameters();



        #endregion


        #region Frm Funtion or Method

        public FrmMain()
        {
            InitializeComponent();
            userHelper.CheckSupperUser("user.pt", listUser);
            openForm(new FrmHome());
            showBar(btnHome);
            Global.frmMain = this;
          var resual =   Global.Ccard1.CarInitial();
            if (resual)
            {
                Global.Ccard1.exies = true;
                rich_Mess.AppendText(DateTime.Now.ToString("HH:mm:ss :") + "read Card success");

                Global.Pumpdata.Read();
                ReadCardData(100);
                Global.X.read();
                Global.Y.read();
                Global.Z.read();
                Global.A.read();
                Global.B.read();
            }
            else
            {
                Global.Ccard1.exies = false;
                rich_Mess.AppendText(DateTime.Now.ToString("HH:mm:ss :") + "read Card 、Error");
            }
        }
        public void PushMess(string mess)
        {
            if (rich_Mess.InvokeRequired)
            {

                rich_Mess.BeginInvoke(new Action(() =>
                {
                    rich_Mess.AppendText(DateTime.Now.ToString("HH:mm:ss : ") + mess + "\r\n");
                    rich_Mess.ScrollToCaret();
                    // rich_Mess.AppendText(DateTime.Now + " - 1\r\n");
                }));
            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region OpenFrom or ShowBar
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
            this.panelBar.Location = new Point(btn.Location.X - 30, btn.Location.Y);
        }
        #endregion

        #region Button Click
        private void btnUser_Click(object sender, EventArgs e)
        {
            if (CurrentInfo.authority == Authority.Empty)
            {
                User_Login frm = new User_Login();
                frm.sendLogin += Login;
                frm.ShowDialog();
            }
            else
            {
                LogOut();
            }

        }

     
        private void btnManual_Click(object sender, EventArgs e)
        {
            
                openForm(frmManual);
                showBar(btnManual);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            openForm(frm_Log);
            showBar(btnLog);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            openForm(frmSet);
            showBar(btnSet);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openForm(frmHome);
            showBar(btnHome);
        }

        private void btnParameter_Click(object sender, EventArgs e)
        {
            openForm(frmGlobal_Parameters);
            showBar(btnParameter);
        }

        #endregion

        #region Lonin　Info


        public void Login(User user)
        {
            //  btnUser.Text = "";
            btnUser.Text = user.UserName;
            CurrentInfo.authority = user.Level;
            CurrentInfo.LoginOut = false;
            switch (user.Level)
            {
                case Authority.Admin:
                    AdminiAuthority();
                    break;
                case Authority.Eng:
                    EngAuthority();
                    break;
                case Authority.Op:
                    OpAuthority();
                    break;
                default:
                    break;
            }
            label2.Text = user.Level.ToString();
            UserTimeOut(30);
        }
        public void LogOut()
        {
            CurrentInfo.authority = Authority.Empty;
            btnUser.Invoke(new Action(() =>
            btnUser.Text = "  No User"
            ));

            CurrentInfo.LoginOut = true;
        }
        #endregion

        #region CheckTimeOut
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point pt);

        public void UserTimeOut(int secTime)
        {
            Point soucePoint1, currentPoint;
            Task task = Task.Run(() =>
            {
                for (int i = 0; i < secTime; i++)
                {
                    //   GetCursorPos(out Point sourcePoint);
                    GetCursorPos(out soucePoint1);
                    System.Threading.Thread.Sleep(1000);
                    GetCursorPos(out currentPoint);
                    if (soucePoint1.X != currentPoint.X | soucePoint1.X != currentPoint.X)
                    {
                        i = 0;
                    }
                    if (CurrentInfo.LoginOut) break;
                }
                LogOut();

            }
            );
        }
        #endregion

        #region Check aauthority
        private bool CheckAdmin()
        {
            if (CurrentInfo.authority == Authority.Admin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckAdminOrEng()
        {
            if (CurrentInfo.authority == Authority.Admin | CurrentInfo.authority == Authority.Eng)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void AdminiAuthority()
        {
            btnManual.Enabled = true;
            btnLog.Enabled = true;
            btnSet.Enabled = true;
        }
        private void EngAuthority()
        {
            btnManual.Enabled = true;
            btnLog.Enabled = true;
            btnSet.Enabled = true;
        }
        private void OpAuthority()
        {
            btnManual.Enabled = false;
            btnLog.Enabled = false;
            btnSet.Enabled = false;
        }


        #endregion

        #region Time
           #endregion

        #region Monitor Card  
        public void ReadCardData(int secTime)
        {
            Global.publisher.action += MonitorCard;
            Global.Sub1.func += RevCurrentPos;

            Task task = Task.Run(() =>
            {
                while (true)
                {

                    Global.publisher.DoSomething();
                    //
                }
            }
            );
        }

        public SendParameter MonitorCard()
        {
            SendParameter data = new SendParameter();
            Random random = new Random();
            ushort[] bit = new ushort[8];
            data.AxisPosition = new double[5];
            data.AxisStatu  = new ushort[5];
            data.AxisPosition = new double[5];
            bool[] sing = new bool[3];
            data.AxisSensorX = new bool[3];
            data.AxisSensorY = new bool[3];
            data.AxisSensorZ = new bool[3];
            data.AxisSensorA = new bool[3];
            data.AxisSensorB = new bool[3];
            try
            {
                //输入
                Global.Ccard1.InputerMethod(ref bit);
                data.inputdata = bit;

                 //当前位置
                data.AxisPosition[0] = Global.X.GetPosition();
                data.AxisPosition[1] = Global.Y.GetPosition();
                data.AxisPosition[2] = Global.Z.GetPosition();
                data.AxisPosition[3] = Global.A.GetPosition();
                data.AxisPosition[4] = Global.B.GetPosition();

                //轴状态
                data.AxisStatu[0] = Global.X.GetAxisStatus();
                data.AxisStatu[1] = Global.Y.GetAxisStatus();
                data.AxisStatu[2] = Global.Z.GetAxisStatus();
                data.AxisStatu[3] = Global.A.GetAxisStatus();
                data.AxisStatu[4] = Global.B.GetAxisStatus();

                //卡状态
                data.CardStatu = Global.Ccard1.GetErrorCode();

                //马达感应器

                Global.X.Getsing(ref  sing);
                data.AxisSensorX = sing;
                Global.Y.Getsing(ref  sing);
                data.AxisSensorY = sing;
                Global.Z.Getsing(ref  sing);
                data.AxisSensorZ = sing;
                Global.A.Getsing(ref  sing);
                data.AxisSensorA = sing;
                Global.B.Getsing(ref  sing);
                data.AxisSensorB = sing;

                Thread.Sleep(100);
                return data;
                 

            }
            catch (Exception ex)
            {
               
                return null;
            }


        }
        #endregion

        #region RevCurrentPos  Setting RevCurrentPos
        public void RevCurrentPos(SendParameter sendPara)
        {
            #region SetPos

           
            if (Xcur_textBox.InvokeRequired)
            {
                Xcur_textBox.BeginInvoke(new Action(() =>
                {
                    Xcur_textBox.Text = sendPara.AxisPosition[0].ToString("#0.000");
                    SetAxisStutic(Xcur_textBox, sendPara.AxisStatu[0]);
                }
                    ));
            }
            if (Ycur_textBox.InvokeRequired)
            {
                Ycur_textBox.BeginInvoke(new Action(() =>
                {
                    Ycur_textBox.Text = sendPara.AxisPosition[1].ToString("#0.000");
                    SetAxisStutic(Ycur_textBox, sendPara.AxisStatu[1]);
                }
                    ));
            }
            if (Zcur_textBox.InvokeRequired)
            {
                Zcur_textBox.BeginInvoke(new Action(() =>
                {
                    Zcur_textBox.Text = sendPara.AxisPosition[2].ToString("#0.000");
                    SetAxisStutic(Zcur_textBox, sendPara.AxisStatu[2]);
                }
                    ));
            }
            if (Acur_textBox.InvokeRequired)
            {
                Acur_textBox.BeginInvoke(new Action(() =>
                {
                    Acur_textBox.Text = sendPara.AxisPosition[3].ToString("#0.000");
                    SetAxisStutic(Acur_textBox, sendPara.AxisStatu[3]);
                }
                    ));
            }
            if (Bcur_textBox.InvokeRequired)
            {
                Bcur_textBox.BeginInvoke(new Action(() =>
                {
                    Bcur_textBox.Text = sendPara.AxisPosition[4].ToString("#0.000");
                    SetAxisStutic(Bcur_textBox, sendPara.AxisStatu[4]);
                }
                    ));
            }

            #endregion


            #region EtherCAT status

  
            if (textBox4.InvokeRequired)
            {
                textBox4.BeginInvoke(new Action(() =>
                {
                    if (sendPara.CardStatu == 0)
                    {
                        textBox4.Text = "EtherCAT总线正常";
                        textBox4.BackColor = Color.Green;
                    }
                    else
                    {
                        textBox4.Text = "EtherCAT总线出错";
                        textBox4.BackColor = Color.Red;
                    }
                }
                    ));
            }
          #endregion
        }

        public void RevMess(SendParameter sendPara)
        {

            if (rich_Mess.InvokeRequired)
            {
                rich_Mess.BeginInvoke(new Action(() =>
                {
                    rich_Mess.Text += sendPara.Mess;
                }
                   ));
            }
        }
        public void RevMess(string sendPara)
        {

            if (rich_Mess.InvokeRequired)
            {
                rich_Mess.BeginInvoke(new Action(() =>
                {
                    rich_Mess.Text += sendPara;
                }
                   ));
            }
        }

        public void SetAxisStutic(TextBox tx,ushort u1)
        {

            switch (u1)// 读取指定轴状态机
            {
                case 0:
                    toolTip1.SetToolTip(tx, "轴处于未启动状态");
                    tx.BackColor = Color.Red;
                    break;
                case 1:
                    toolTip1.SetToolTip(tx, "轴处于启动禁止状态");
                    tx.BackColor = Color.Red;
                    break;
                case 2:
                    toolTip1.SetToolTip(tx, "轴处于准备启动状态");
                    tx.BackColor = Color.Red;
                    break;
                case 3:
                    toolTip1.SetToolTip(tx, "轴处于启动状态");
                    tx.BackColor = Color.Red;
                    break;
                case 4:
                    toolTip1.SetToolTip(tx, "轴处于操作使能状态");
                    tx.BackColor = Color.Green;
                    break;
                case 5:
                    toolTip1.SetToolTip(tx, "轴处于停止状态");
                    tx.BackColor = Color.Red;
                    break;
                case 6:
                    toolTip1.SetToolTip(tx, "轴处于错误触发状态");
                    tx.BackColor = Color.Red;
                    break;
                case 7:
                    toolTip1.SetToolTip(tx, "轴处于错误状态");
                    tx.BackColor = Color.Red;
                    break;
            };
        }
        #endregion

      

    }
}
