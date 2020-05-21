using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoGuoFeng
{
    public partial class FrmProgram : Form
    {

        ModelsHelper modelHelper = new ModelsHelper("");
    


        public FrmProgram()
        {
            InitializeComponent();

              Getlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form test = Application.OpenForms["FrmPrograms"];
            if ((test == null) || (test.IsDisposed))
            {
                 string na= string.Empty;
                  int a = dataGridView1.CurrentCellAddress.Y;
                  if (a >= 0)
                  {
                        na = dataGridView1.Rows[a].Cells[0].Value as string;
                  }
              
                FrmPrograms men = new FrmPrograms(na);
                men.Fathed = this;
               
                men.Show();
            }
            else
            {
                test.Activate();
            }
        }

        private void ShowUserData(List<Models> list)
        {
            List<Models> upList = new List<Models>();
            for (int i = 0; i < list.Count; i++)
            {
              
                    upList.Add(list[i]);
                
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = upList;
        }

        private void btnIO_Click(object sender, EventArgs e)
        {
             int a = dataGridView1.CurrentCellAddress.Y;
            string NowModel = dataGridView1.Rows[a].Cells[0].Value as string;
            Global.NowModel = new Models();
            Global.NowModel.FileName  = label2.Text = Global.frmMain.lab_Now_model .Text= NowModel;
           ModelsHelper.NowModels =  NowModel;
         
        }

        public void Getlist()
        {
            label2.Text = Global.NowModel.FileName;
            if (File.Exists("pro.pt"))
            {
                Global.listModel = modelHelper.DeSerializedUser("pro.pt");
                if (Global.listModel != null)
                    ShowUserData(Global.listModel);
            }

        }
        private void FrmProgram_Load(object sender, EventArgs e)
        {

        }




    }
}
