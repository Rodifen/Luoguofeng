using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace LuoGuoFeng
{
    public partial class FrmInput1 : MetroForm
    {

        private FrmPrograms p_f1;
        public FrmPrograms P_F1
        {
            get { return p_f1; }
            set { p_f1 = value; }
        }

        public FrmInput1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsFileNameValid(maskedTextBox1.Text))
            {
                p_f1.NewModel(maskedTextBox1.Text);
                this.Close();
         
            }
            else
            {
                MessageBox.Show("Please check the legality of the file. ");
            }
        }

        private bool IsFileNameValid(string name)
        {
            bool isFilename = true;
            string[] errorStr = new string[] { "/", "\\", ":", ",", "*", "?", "\"", "<", ">", "|" };

            if (string.IsNullOrEmpty(name))
            {
                isFilename = false;
            }
            else
            {
                for (int i = 0; i < errorStr.Length; i++)
                {
                    if (name.Contains(errorStr[i]))
                    {
                        isFilename = false;
                        break;
                    }
                }
            }
            return isFilename;
        }




    }
}
