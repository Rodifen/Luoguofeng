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
    public partial class IO : Form
    {
        public IO()
        {
            InitializeComponent();

            //Global.sendData = null;
            //Global.sendData += RecieveData;
            Subscriber subscriber = new Subscriber("", Global.publisher);
            subscriber.func += RecieveData;
        }

        public void RecieveData(SendParameter sendPara)
        {
            var Bit = sendPara.inputdata;
            #region    //位值转显示
            //启动
            if (Bit[0] == 1)
            {
                lable0.ForeColor = Color.LawnGreen;

            }
            else
            {
                lable0.ForeColor = Color.Black;

            }
            //复位
            if (Bit[1] == 1)
            {
                lable1.ForeColor = Color.LawnGreen;

            }
            else
            {
                lable1.ForeColor = Color.Black;

            }

            //气压
            if (Bit[2] == 1)
            {
                lable2.ForeColor = Color.LawnGreen;

            }
            else
            {
                lable2.ForeColor = Color.Black;

            }

            //门
            if (Bit[3] == 1)
            {
                lable3.ForeColor = Color.LawnGreen;

            }
            else
            {
                lable3.ForeColor = Color.Black;

            }
            //  press down
            if (Bit[4] == 1)
            {
                lable4.ForeColor = Color.LawnGreen;

            }
            else
            {
                lable4.ForeColor = Color.Black;

            }
            //  press up
            if (Bit[5] == 1)
            {
                lable5.ForeColor = Color.LawnGreen;

            }
            else
            {
                lable5.ForeColor = Color.Black;

            }
            //Material-R
            if (Bit[6] == 1)
            {
                lable6.ForeColor = Color.LawnGreen;

            }
            else
            {
                lable6.ForeColor = Color.Black;

            }
            //Material-L
            if (Bit[7] == 1)
            {
                lable7.ForeColor = Color.LawnGreen;

            }
            else
            {
                lable7.ForeColor = Color.Black;

            }
            #endregion

            //if (textBox1.InvokeRequired)
            //{
            //    textBox1.BeginInvoke(new Action(() =>
            //    {
            //        textBox1.Text = sendPara.db.ToString();
            //    }
            //        ));
            //}


        }


        private void Out(Button BT, ushort bit)
        {
            if (BT.BackColor == Color.Transparent)   // 检查按钮颜色 如果白色  则设为
            {
                BT.BackColor = Color.Green;
                Global.Ccard1.OutPuter(bit, 1);
            }
            else
            {
                BT.BackColor = Color.Transparent;
                Global.Ccard1.OutPuter(bit, 0);
            }

        }


        #region OutButton
      
        //private void button100_Click(object sender, EventArgs e)
        //{

        //}

        //private void button101_Click(object sender, EventArgs e)
        //{

        //}

        //private void button102_Click(object sender, EventArgs e)
        //{

        //}

        //private void button103_Click(object sender, EventArgs e)
        //{

        //}

        //private void button104_Click(object sender, EventArgs e)
        //{

        //}

        //private void button105_Click(object sender, EventArgs e)
        //{

        //}

        //private void button106_Click(object sender, EventArgs e)
        //{

        //}

        //private void button107_Click(object sender, EventArgs e)
        //{

        //}
        private void button100_Click(object sender, EventArgs e)
        {
            Out(button100, 0);
        }

        private void button101_Click(object sender, EventArgs e)
        {
            Out(button101, 1);
        }

        private void button102_Click(object sender, EventArgs e)
        {
            Out(button102, 2);
        }

        private void button103_Click(object sender, EventArgs e)
        {
            Out(button103, 3);
        }

        private void button104_Click(object sender, EventArgs e)
        {
            Out(button104, 4);
        }

        private void button105_Click(object sender, EventArgs e)
        {
            Out(button105, 5);
        }

        private void button106_Click(object sender, EventArgs e)
        {
            Out(button106, 6);
        }

        private void button107_Click(object sender, EventArgs e)
        {
            Out(button107, 7);
        }

        #endregion

        private void IO_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("我退出了");
        }




    }
}
