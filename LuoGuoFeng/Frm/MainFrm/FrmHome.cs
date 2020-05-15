using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoGuoFeng.Frm
{
    public partial class FrmHome : Form
    {


        CancellationTokenSource tokenSource;
        CancellationToken token;
        ManualResetEvent resetEvent;
    //    Task task;
      //  bool Runstu = false;
        Thread Auto1Thread;    //自动线程
        int AutoID;         //自动运行线程ID
        int Setup = 0;
        ushort CarStatus = 0;
        string NowModel;

        

        public FrmHome()
        {
          InitializeComponent();  
          tokenSource = new CancellationTokenSource();
          token = tokenSource.Token;    
         resetEvent = new ManualResetEvent(true);
          
        }

        private void btnLoing_Click(object sender, EventArgs e)
        {

        }

        private void ucBtnExt21_BtnClick(object sender, EventArgs e)
        {

        }




        private void PushMesss(string mess)
        {
            if (rich_Mess.InvokeRequired)
            {

                rich_Mess.BeginInvoke(new Action(() =>
                { 
                    rich_Mess.AppendText(DateTime.Now.ToString("HH:mm:ss : ") + mess+"\r\n");
                    rich_Mess.ScrollToCaret();
                   // rich_Mess.AppendText(DateTime.Now + " - 1\r\n");
                }));
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Auto();
        }

       
        public  void Auto()
        {

            if (Auto1Thread != null)
            {
                if (Auto1Thread.IsAlive)
                {
                    DialogResult dr = MessageBox.Show("轴繁忙！，是否暂停", "提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Auto1Thread.Abort();
                        button1.Image = Properties.Resources.暂停;
                    }
                }
                else
                {

                    button1.Image =   Properties.Resources.暂停__1_;
                    Auto1Thread = new Thread(auto);
                    AutoID = Auto1Thread.ManagedThreadId;
                    Auto1Thread.Start();
                }
            }
            else
            {
                button1.Image = Properties.Resources.暂停__1_;
                Auto1Thread = new Thread(auto);
                AutoID = Auto1Thread.ManagedThreadId;
                Auto1Thread.Start();
            }
        }



        public void auto()
        {
            NowModel = PumpFile.Default.Nowmodel;
            string[,] array = new string[100, 20];
            string file = Application.StartupPath + "\\data\\" + NowModel;
            if (!File.Exists(file))
            {
                PushMesss("文件不存在File not Find");
                 return;
             }
            int Rows = 0;
           // DataGridView DGV = new DataGridView();
            ProfileHelper.ReadExcel1(file,ref array,ref Rows);
           // array =ProfileHelper. GetTable(DGV);
     //       int a = DGV.Rows.Count;
              
            bool first = true;

            //自动时
            if (ucSwitch7.Checked)
            {
                while (!ucSwitch2.Checked || first)    //根据条件进行循环
                {
                    for (int i = 0; i < Rows-1; i++)
                    {
                        if (array[i, 1] == "Arc_Target")
                        {
                            continue;
                        }
                        if (array[i, 1] == "Arc_Mid")
                        {
                            PushMesss(i + " line" + array[i, 1] + " " + array[i, 2] + " " + array[i, 3] + " " + array[i, 4] );
                            int y = i+1;
                            PushMesss(y.ToString() + " line " + array[y, 1] + " " + array[i + 1, 2] + " " + array[i + 1, 3] + " " + array[i + 1, 4]);

                        }
                        else
                        {
                            PushMesss(i + " line " + array[i, 1] + " " + array[i, 2] + " " + array[i, 3] + " " + array[i, 4]);
                        }
                        Thread.Sleep(100);
                     
                        Global.Cdefault data1 = new Global.Cdefault();
                        data1.setup = i;
                        data1.table = array;
                        data1.tryRun = !ucSwitch1.Checked;
                        MotionHelper.MotionFun(data1);
                        first = false;
                        // ActionThread.Abort();
                    }
                    button1.Image = global::LuoGuoFeng.Properties.Resources.暂停;
                }
            }
            else                 //单步
            {  
              // 
                Setup = Convert.ToInt32(numericUpDown1.Value);
                PushMesss((Setup) + " line " + array[Setup, 1] + " " + array[Setup, 2] + " " + array[Setup, 3] + " " + array[Setup, 4]);
                Global.Cdefault data1 = new Global.Cdefault();
                data1.setup = Setup;
                data1.table = array;
                data1.tryRun = !ucSwitch1.Checked;
                MotionHelper.MotionFun(data1);
                if (Setup < Rows-2)
                      Setup++;
                else
                      Setup = 0;
               ucTextBoxexMess(Setup);
               button1.Image = global::LuoGuoFeng.Properties.Resources.暂停;
               
            }
        }
        private void ucTextBoxexMess(decimal str)
        {

            if (numericUpDown1.InvokeRequired)
            {
                numericUpDown1.BeginInvoke(new Action(() =>
                {
                    numericUpDown1.Value = str;
                }
                   ));
            }
        }
        private void ucSwitch2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Auto1Thread != null)
            {
                if (Auto1Thread.IsAlive)
                {
                    DialogResult dr = MessageBox.Show("轴繁忙！，是否停止 复位", "提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Auto1Thread.Abort();
              //          button1.Image = Properties.Resources.暂停;
                    }
                }
                else
                {
               //     button1.Image = Properties.Resources.暂停__1_;
                    Auto1Thread = new Thread(MotionHelper.Reset);
                    AutoID = Auto1Thread.ManagedThreadId;
                    Auto1Thread.Start();
                }
            }
            else
            {
          //      button1.Image = global::LuoGuoFeng.Properties.Resources.暂停__1_;
                Auto1Thread = new Thread(MotionHelper.Reset);
                AutoID = Auto1Thread.ManagedThreadId;
                Auto1Thread.Start();
            }
        }










    }
}
