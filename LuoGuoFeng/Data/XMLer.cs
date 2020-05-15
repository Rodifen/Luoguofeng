using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LuoGuoFeng
{
    class XMLer
    {
        DataSet xmlDs = new DataSet();
    }

    class XMLHelper
    {

             

     

        static string xml_FilePath = "";//用来记录当前打开文件的路径的
        public static void ImportData(DataGridView myDGV)
        {

        }

        public  static void ExportData(DataGridView myDGV)
        {

        }
        public static bool ReadXMLdata(string file,ref DataGridView Dgv)
        {
            if (!File.Exists(file))
            {
                return false;
            }
            //file;//记录用户选择的文件路径
            XmlDocument xmlDocument = new XmlDocument();//新建一个XML“编辑器”
            xmlDocument.Load(file);//载入路径这个xml
            try
            {
                XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("class").ChildNodes;//选择class为根结点并得到旗下所有子节点
                Dgv.Rows.Clear();//清空dataGridView1，防止和上次处理的数据混乱
                foreach (XmlNode xmlNode in xmlNodeList)//遍历class的所有节点
                {
                    XmlElement xmlElement = (XmlElement)xmlNode;//对于任何一个元素，其实就是每一个<student>
                    //旗下的子节点<name>和<number>分别放入dataGridView1
                    int index = Dgv.Rows.Add();//在dataGridView1新加一行，并拿到改行的行标
                    for (int i = 0; i < 11; i++)
                    {
                        //dataGridView1.Rows[index].Cells[0].Value = xmlElement.ChildNodes.Item(0).InnerText;//各个单元格分别添加
                        Dgv.Rows[index].Cells[i].Value = xmlElement.ChildNodes.Item(i).InnerText;
                    }
                }


                return true;
            }
            catch
            {
                MessageBox.Show("XML格式不对！");
                return false;
            }
        }

        public static bool SaveXMLdata(string file, DataGridView Dgv)
        {

            XmlDocument xmlDocument = new XmlDocument();//新建一个XML“编辑器”
            if (!File.Exists(file))
            {
                //XmlDocument xmlDocument = new XmlDocument();//新建一个XML“编辑器”
                try
                {
                    //xmlDocument.Load(file);

                    XmlElement xmlElement_class = xmlDocument.CreateElement("class");//创建一个<class>节点
                    //   xmlElement_class.RemoveAll();//删除旗下所有节点
                    int row = Dgv.Rows.Count;//得到总行数    
                    int cell = Dgv.Rows[1].Cells.Count;//得到总列数    
                    for (int i = 0; i < row; i++)//遍历这个dataGridView
                    {
                        XmlElement xmlElement_student = xmlDocument.CreateElement("student");//创建一个<student>节点
                        for (int j = 0; j < cell; j++)
                        {
                            XmlElement xmlElement_number = xmlDocument.CreateElement(Dgv.Columns[j].Name);
                            if (Dgv.Rows[i].Cells[j].Value != null)
                                xmlElement_number.InnerText = Dgv.Rows[i].Cells[j].Value.ToString();
                            else
                                xmlElement_number.InnerText = "0";
                            xmlElement_student.AppendChild(xmlElement_number);
                        }
                        xmlElement_class.AppendChild(xmlElement_student);//将这个<student>节点放到<class>下方
                    }
                    xmlDocument.AppendChild(xmlDocument.CreateXmlDeclaration("1.0", "utf-8", ""));//编写文件头
                    xmlDocument.AppendChild(xmlElement_class);//将这个<class>附到总文件头，而且设置为根结点
                    xmlDocument.Save(file);//保存这个xml文件

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                    throw;
                }

            }

            else
            {
                try
                {

                    xmlDocument.Load(file);
                    XmlNode xmlElement_class = xmlDocument.SelectSingleNode("class");//找到<class>作为根节点
                    xmlElement_class.RemoveAll();//删除旗下所有节点
                    int row = Dgv.Rows.Count;//得到总行数    
                    int cell = Dgv.Rows[1].Cells.Count;//得到总列数    
                    for (int i = 0; i < row; i++)//遍历这个dataGridView
                    {
                        XmlElement xmlElement_student = xmlDocument.CreateElement("student");//创建一个<student>节点
                        for (int j = 0; j < cell; j++)
                        {
                            XmlElement xmlElement_number = xmlDocument.CreateElement(Dgv.Columns[j].Name);
                            if (Dgv.Rows[i].Cells[j].Value != null)
                                xmlElement_number.InnerText = Dgv.Rows[i].Cells[j].Value.ToString();
                            else
                                xmlElement_number.InnerText = "0";
                            xmlElement_student.AppendChild(xmlElement_number);
                        }
                        xmlElement_class.AppendChild(xmlElement_student);//将这个<student>节点放到<class>下方
                    }
                    xmlDocument.Save(file);//保存这个xml


                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                    throw;
                }
            }
        }
        #region 11111111
           //public  static void DataToXLM(DataGridView dataGridView1)
        //{
        //    XmlDocument xmlDocument = new XmlDocument();//新建一个XML“编辑器”
        //    if (xml_FilePath != "")//如果用户已读入xml文件，我们的任务就是修改这个xml文件了
        //    {
        //        xmlDocument.Load(xml_FilePath);
        //        XmlNode xmlElement_class = xmlDocument.SelectSingleNode("class");//找到<class>作为根节点
        //        xmlElement_class.RemoveAll();//删除旗下所有节点
        //        int row = dataGridView1.Rows.Count;//得到总行数    
        //        int cell = dataGridView1.Rows[1].Cells.Count;//得到总列数    
        //        for (int i = 0; i < row - 1; i++)//遍历这个dataGridView
        //        {
        //            XmlElement xmlElement_student = xmlDocument.CreateElement("student");//创建一个<student>节点
        //            XmlElement xmlElement_name = xmlDocument.CreateElement("name");//创建<name>节点
        //            xmlElement_name.InnerText = dataGridView1.Rows[i].Cells[0].Value.ToString();//其文本就是第0个单元格的内容
        //            xmlElement_student.AppendChild(xmlElement_name);//在<student>下面添加一个新的节点<name>
        //            //同理添加<number>
        //            XmlElement xmlElement_number = xmlDocument.CreateElement("number");
        //            xmlElement_number.InnerText = dataGridView1.Rows[i].Cells[1].Value.ToString();
        //            xmlElement_student.AppendChild(xmlElement_number);
        //            xmlElement_class.AppendChild(xmlElement_student);//将这个<student>节点放到<class>下方
        //        }
        //        xmlDocument.Save(xml_FilePath);//保存这个xml
        //    }
        //    else//如果用户未读入xml文件，我们的任务就新建一个xml文件了
        //    {
        //        SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();//打开一个保存对话框
        //        saveFileDialog1.Filter = "xml文件(*.xml)|*.xml";//设置允许打开的扩展名
        //        if (saveFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了一个文件路径
        //        {
        //            XmlElement xmlElement_class = xmlDocument.CreateElement("class");//创建一个<class>节点
        //            int row = dataGridView1.Rows.Count;//得到总行数    
        //            int cell = dataGridView1.Rows[1].Cells.Count;//得到总列数    
        //            for (int i = 0; i < row - 1; i++)//得到总行数并在之内循环    
        //            {
        //                //同上，创建一个个<student>节点，并且附到<class>之下
        //                XmlElement xmlElement_student = xmlDocument.CreateElement("ID");
        //                for (int i1 = 0; i1 < cell; i1++)
        //                {
        //                    XmlElement xmlElement_name = xmlDocument.CreateElement("name");  
        //                    xmlElement_name.InnerText = dataGridView1.Rows[i].Cells[i1].Value.ToString();
        //                    xmlElement_student.AppendChild(xmlElement_name);

        //                }
                     
        //                xmlElement_student.AppendChild(xmlElement_number);
        //                xmlElement_class.AppendChild(xmlElement_student);
        //            }
        //            xmlDocument.AppendChild(xmlDocument.CreateXmlDeclaration("1.0", "utf-8", ""));//编写文件头
        //            xmlDocument.AppendChild(xmlElement_class);//将这个<class>附到总文件头，而且设置为根结点
        //            xmlDocument.Save(saveFileDialog1.FileName);//保存这个xml文件
        //        }
        //        else
        //        {
        //            MessageBox.Show("请保存为XML文件");
        //        }
            
        //     }


        //}
          //public static List<T> FillModelsByDgv<T>(DataGridView dgv, string idColumnName) where T : class ,new()
        //{
        //    //用于返回的结果
        //    List<T> models = new List<T>();
        //    T model = null;
        //    //遍历 DataGridView 所有行
        //    foreach (DataGridViewRow dgr in dgv.Rows)
        //    {
        //        //判断关键列是否是空，空就跳过
        //        if (dgr.Cells[idColumnName].EditedFormattedValue == null || dgr.Cells[idColumnName].EditedFormattedValue.ToString() == "") continue;
        //        //定义个中间obj


        //        //遍历 DataGridView 所有列
        //        foreach (DataGridViewColumn dgc in dgv.Columns)
        //        {

        //            try
        //            {
        //                //判断当前单元格是否无值，无则跳过
        //                if (dgr.Cells[dgc.Name].EditedFormattedValue == null || dgr.Cells[dgc.Name].EditedFormattedValue.ToString() == "")
        //                    continue;
        //                model = new T();
        //                //反射模型的属性
        //                PropertyInfo field = model.GetType().GetProperty(dgc.Name);
        //                //判断当前列类型
        //                switch (dgc.ValueType.ToString())
        //                {
        //                    //给模型的属性赋值
        //                    case "System.Int32": { field.SetValue(model, int.Parse(dgr.Cells[dgc.Name].EditedFormattedValue.ToString()), null); } break;
        //                    case "System.String": { field.SetValue(model, dgr.Cells[dgc.Name].EditedFormattedValue.ToString(), null); } break;
        //                    case "System.Decimal": { field.SetValue(model, Decimal.Parse(dgr.Cells[dgc.Name].EditedFormattedValue.ToString()), null); } break;
        //                    case "System.DateTime": { field.SetValue(model, DateTime.Parse(dgr.Cells[dgc.Name].EditedFormattedValue.ToString()), null); } break;
        //                    case "System.Boolean": { field.SetValue(model, Boolean.Parse(dgr.Cells[dgc.Name].EditedFormattedValue.ToString()), null); } break;
        //                    case "System.Char": { field.SetValue(model, dgr.Cells[dgc.Name].EditedFormattedValue.ToString(), null); } break;
        //                    default: { } break;
        //                }

        //            }
        //            catch { }
        //        }
        //        //将赋值后的模型添加到 结果集中
        //        models.Add(model);

        //    }
        //    return models;
        //}

        #endregion









    }

}
