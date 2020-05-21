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
    public partial class FrmCalibration : Form
    {     
      
        public FrmCalibration()
        {
            InitializeComponent();
            addxyz(dataGridView1);
            addxyz(dataGridView2);

            string CalPath = Application.StartupPath + "\\data\\" + ModelsHelper.NowModels + "-cal.txt";         // string CalPath =$" {Application.StartupPath} //";
            var res = ProfileHelper.ReadCal(CalPath, ref dataGridView1, ref dataGridView2);
            if (!res)
            {
                // Global.frmMain.PushMess($"{CalPath} not find");
            }
        }
        #region TopButton
        private void btnSave_Click(object sender, EventArgs e)
        {
            string CalPath = Application.StartupPath + "\\data\\" + ModelsHelper.NowModels + "-cal.txt";         // string CalPath =$" {Application.StartupPath} //";
            var s = ProfileHelper.WriteCal(dataGridView1, dataGridView2, CalPath); ;
        }



        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();//首先根据打开文件对话框，选择excel表格
      //      fd.Filter = "|*--Cal.txt";//打开文件对话框筛选器
            string strPath;//文件完整的路径名
            if (fd.ShowDialog() == DialogResult.OK)
            {
                strPath = fd.FileName;
                ProfileHelper.ReadCal(strPath,ref dataGridView1, ref dataGridView2);
            }
        }

        #endregion

        private void addxyz(DataGridView DGV)
        {
            DGV.Rows.Add(3);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Action ac = new Action(Caliration);
            ac.BeginInvoke(null,null);
            
;        }

        private void Caliration()
        {
            int IthreadID = 0;
            int WthreadID = 0;
            ThreadPool.GetAvailableThreads(out WthreadID,out IthreadID);
          //  Global.frmMain.PushMess("{IthreadID}----{WthreadID}");
        }


    }
}
