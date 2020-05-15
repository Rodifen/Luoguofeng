using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoGuoFeng
{
    class Profile
    {
    }




    class ProfileHelper
    {

       public static void WriteExcel(DataGridView myDGV, string currpath)
        {
            try
            {
                string savetxt = null;
                string[,] array = new string[100, 100];
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    //  worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                    array[0, i + 1] = myDGV.Columns[i].HeaderText;
                    savetxt += myDGV.Columns[i].HeaderText + "\t";
                }
                savetxt += "\r\n";
                //写入数值
                for (int r = 0; r < myDGV.Rows.Count; r++)
                {
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        if (myDGV.Rows[r].Cells[i].Value.ToString() != null)
                        {
                            array[r + 1, i] = myDGV.Rows[r].Cells[i].Value.ToString();
                            savetxt += myDGV.Rows[r].Cells[i].Value.ToString() + "\t";
                        }
                    }
                    savetxt += "\r\n";
                }



                //string currpath = MyGlobal.BasePath + @"\" + MyGlobal.currModel + "--pro.txt";
                //FileMode.Append为不覆盖文件效果.create为覆盖
                FileStream fs = new FileStream(currpath, FileMode.Create);
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(savetxt);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
                MessageBox.Show("保存成功至" + currpath, "MessageBox");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public static bool ReadExcel(string path, DataGridView DGV)
        {
            try
            {

                //读出文本
                string[] resual = new string[500];
                StreamReader sr = new StreamReader(path, Encoding.Default);
                String line;
                int ln = 0;
                while ((line = sr.ReadLine()) != null)
                    resual[ln++] += line.ToString();
                sr.Close();



                string[,] array = new string[200, 20];


                //分割字符
                string[] spstr = new string[100];
                for (int i = 1; i < ln; i++)
                {
                    spstr = resual[i].Split('\t');
                    for (int j = 0; j < spstr.Length - 1; j++)
                        array[i - 1, j] = spstr[j];
                }
                DGV.Rows.Clear();
                for (int i = 0; i < ln - 1; i++)
                {
                    DGV.Rows.Add();
                    for (int cell = 0; cell < DGV.Rows[i].Cells.Count; cell++)
                    {
                        DGV.Rows[i].Cells[cell].Value = array[i, cell];
                    }
                    //DGV.Rows[i].Cells[1].Value = array[i, 1];
                     //............
                    //DGV.Rows[i].Cells[10].Value = array[i, 10];
                }
                return true;
                //MessageBox.Show(resual.ToString());
            }
            catch (Exception ex)
            {
                //Global.frmMain.mess
                return false;
           //     messagerichTextBox.AppendText(ex.Message);
            }

        }

        public static bool ReadExcel1(string path,ref string[,] array,ref int ln)
        {
            try
            {

                //读出文本
                string[] resual = new string[5000];
                StreamReader sr = new StreamReader(path, Encoding.Default);
                String line;
               // int ln = 0;
                while ((line = sr.ReadLine()) != null)
                    resual[ln++] += line.ToString();
                sr.Close();
                array = new string[200, 20];

                //分割字符
                string[] spstr = new string[100];
                for (int i = 1; i < ln; i++)
                {
                    spstr = resual[i].Split('\t');
                    for (int j = 0; j < spstr.Length - 1; j++)
                        array[i - 1, j] = spstr[j];
                }
          
                return true;
                //MessageBox.Show(resual.ToString());
            }
            catch (Exception ex)
            {
                //Global.frmMain.mess
                return false;
           //     messagerichTextBox.AppendText(ex.Message);
            }

        }

        public static string[,] GetTable(DataGridView myDGV)
        {
            string savetxt = null;
            string[,] array = new string[100, 20];
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount - 1; i++)
                {
                    if (myDGV.Rows[r].Cells[i].Value.ToString() != null)
                    {
                        array[r, i] = myDGV.Rows[r].Cells[i].Value.ToString();
                        savetxt += myDGV.Rows[r].Cells[i].Value.ToString() + "\t";
                    }
                }
                savetxt += "\r\n";
            }

            savetxt.GetType();
            return array;
        }



       public static  bool WriteCal(DataGridView myDGV, DataGridView myDGV1, string currpath)
        {
            try
            {
                string savetxt = null;
                string[,] array = new string[100, 100];
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    //  worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                    array[0, i + 1] = myDGV.Columns[i].HeaderText;
                    savetxt += myDGV.Columns[i].HeaderText + "\t";
                }
                savetxt += "\r\n";
                //写入数值
                for (int r = 0; r < myDGV.Rows.Count; r++)
                {
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        if (myDGV.Rows[r].Cells[i].Value != null)
                        {
                            array[r + 1, i] = myDGV.Rows[r].Cells[i].Value.ToString();
                            savetxt += myDGV.Rows[r].Cells[i].Value.ToString() + "\t";
                        }
                        else
                        {
                            array[r + 1, i] = "0";
                            savetxt += "0" + "\t";
                        }
                    }
                    savetxt += "\r\n";
                }
                //保存第二格校准规格
                for (int i = 0; i < myDGV1.ColumnCount; i++)
                {
                    //  worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                    array[0, i + 1] = myDGV1.Columns[i].HeaderText;
                    savetxt += myDGV1.Columns[i].HeaderText + "\t";
                }
                savetxt += "\r\n";
                for (int r = 0; r < myDGV1.Rows.Count; r++)
                {
                    for (int i = 0; i < myDGV1.ColumnCount; i++)
                    {
                        if (myDGV1.Rows[r].Cells[i].Value != null)
                        {
                            array[r + 1, i] = myDGV1.Rows[r].Cells[i].Value.ToString();
                            savetxt += myDGV1.Rows[r].Cells[i].Value.ToString() + "\t";
                        }
                        else
                        {
                            array[r + 1, i] = "0";
                            savetxt += "0"+ "\t";

                        }
                    }
                    savetxt += "\r\n";
                }

                //FileMode.Append为不覆盖文件效果.create为覆盖
                FileStream fs = new FileStream(currpath, FileMode.Create);
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(savetxt);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
                MessageBox.Show("保存成功至" + currpath, "MessageBox");
                return true;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static bool ReadCal(string path,ref DataGridView dgv,ref DataGridView dgv1)
        {
       
            try
            {
                //读出文本
                string[] resual = new string[500];
                StreamReader sr = new StreamReader(path, Encoding.Default);
                String line;
                int ln = 0;
                while ((line = sr.ReadLine()) != null)
                    resual[ln++] += line.ToString();
                sr.Close();
                string[,] array = new string[200, 20];


                //分割字符
                string[] spstr = new string[100];
                for (int i = 0; i < ln; i++)
                {
                    spstr = resual[i].Split('\t');
                    for (int j = 0; j < spstr.Length - 1; j++)
                        array[i, j] = spstr[j];
                }

                for (int i = 0; i < 3; i++)
                {

                    dgv.Rows[i].Cells[0].Value = array[i + 1, 0];
                    dgv.Rows[i].Cells[1].Value = array[i + 1, 1];
                    dgv.Rows[i].Cells[2].Value = array[i + 1, 2];
                    dgv.Rows[i].Cells[3].Value = array[i + 1, 3];
                    dgv.Rows[i].Cells[4].Value = array[i + 1, 4];
                    dgv.Rows[i].Cells[5].Value = array[i + 1, 5];

                }


                dgv1.Rows[0].Cells[0].Value = "X";
                dgv1.Rows[1].Cells[0].Value = "Y";
                dgv1.Rows[2].Cells[0].Value = "Z";
                dgv1.Rows[0].Cells[1].Value = array[5, 1];
                dgv1.Rows[0].Cells[2].Value = array[5, 2];
                dgv1.Rows[1].Cells[1].Value = array[6, 1];
                dgv1.Rows[1].Cells[2].Value = array[6, 2];
                dgv1.Rows[2].Cells[1].Value = array[7, 1];
                dgv1.Rows[2].Cells[2].Value = array[7, 2];
                Global.frmMain.PushMess("Read Cal success");
                return true;

            }
            catch (Exception ex)
            {
              
                Global.frmMain.PushMess(ex.ToString());
                return false;
            }


        }


    }
}
