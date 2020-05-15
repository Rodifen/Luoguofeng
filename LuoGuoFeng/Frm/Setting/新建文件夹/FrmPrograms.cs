using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System.Xml;
using System.IO;

namespace LuoGuoFeng
{
    public partial class FrmPrograms : MetroForm
    {



        UserHelper userHelper = new UserHelper("");
        public FrmProgram Fathed = new FrmProgram();
        public string fileName;
        private string filePath;
        DataTable dt = new DataTable();
        MenuStrip menu = new MenuStrip();
        bool Change = true;
        #region From Method
        public FrmPrograms(string fa)
        {
            fileName = fa;

            InitializeComponent();
            filePath = Application.StartupPath + "\\data\\" + fileName ;
            if (File.Exists(filePath))
            {
                ProfileHelper.ReadExcel(filePath, dataGridView1);
          //      XMLHelper.ReadXMLdata(filePath, ref dataGridView1);
            }

            metroTabPage1.Text = fa;

        }
        private void FrmPrograms_Load(object sender, EventArgs e)
        {
            //  dataGridView1.StandardTab = true;
        }
        #endregion


        public void ReadList()
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmInput1 frm = new FrmInput1();
            frm.P_F1 = this;
            frm.ShowDialog();

        }

        public void NewModel(string name)
        {
            List<string> listmodel = new List<string>();
            listmodel.Add(name);

            metroTabPage1.Text = name;

        }


        #region ConTextMenu
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(new string[11] { dataGridView1.Rows.Count.ToString(), "禁用", "0", "0", "0", "0", "0", "0", "0", "0", "0" });

        }
        #endregion

        private void FrmPrograms_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Save", "Do you wan't Save File", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes)
            {
                Models model = new Models();
                if (metroTabPage1.Text != "")
                {
                    model.FileName = metroTabPage1.Text;
                    SaveModel(model);
                }
                
            }
            if (res == DialogResult.No)
            {

            }
            if (res == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            Fathed.Getlist();





        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("你确定要删除参数吗?", "提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int a = dataGridView1.CurrentCellAddress.Y;
                dataGridView1.Rows.RemoveAt(a);
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells[0].Value = i;
                }
            }
        }

        private void getPosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] data = new string[3];
            Global.frmMain.SendPosion(ref data);
           
            int a = dataGridView1.CurrentCellAddress.Y;
              dataGridView1.Rows[a].Cells[2].Value = data[0];
              dataGridView1.Rows[a].Cells[3].Value = data[1];
              dataGridView1.Rows[a].Cells[4].Value = data[2];
            //dataGridView1.Rows.Insert(a, new string[11] { a.ToString(), "禁用",data[0], data[1], data[2], "0", "0", "0", "0", "0", "0" });
        }
   

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.CurrentCellAddress.Y;
            dataGridView1.Rows.Insert(a, new string[11] { a.ToString(), "禁用", "0", "0", "0", "0", "0", "0", "0", "0", "0" });
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = i;
            }

        }
        //  string xml_FilePath = "";//用来记录当前打开文件的路径的
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();//一个打开文件的对话框
         //   openFileDialog1.Filter = "xml文件(*.xml)|*.xml";//设置允许打开的扩展名
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件  
                {
                    ProfileHelper.ReadExcel(openFileDialog1.FileName, dataGridView1);
                    //XMLHelper.ReadXMLdata(openFileDialog1.FileName, ref dataGridView1);
                    metroTabPage1.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName); //openFileDialog1.FileName;
                    
                }
            }
            catch (Exception)
            {
                throw;
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {

            filePath = Application.StartupPath + "\\data\\" + metroTabPage1.Text;

            ProfileHelper.WriteExcel(dataGridView1, filePath);
            // XMLHelper.SaveXMLdata(filePath, dataGridView1);
            Change = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveModel(Models model)
        {
            if (Global.listModel == null)
            {
                Global.listModel = new List<Models>();
            }
            ModelsHelper modelhple = new ModelsHelper("pro.pt");
            var res = modelhple.AddModel("pro.pt", Global.listModel, model);

            if (res)
            {

            }
            else
            {
                //    MessageBox.Show("文件保存失败.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Models models = new Models();
            models.FileName = metroTabPage1.Text;
            ModelsHelper moder = new ModelsHelper("");
           var res =  moder.DeleteModel("pro.pt", Global.listModel, models);
           if (!res)
           {
               MessageBox.Show("fali");
           }
           else
           {
               metroTabPage1.Text = "";
               dataGridView1.Rows.Clear(); ;
           }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Change = true;
        }
    }
}
