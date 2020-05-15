using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LuoGuoFeng.Data
{
    class RWcofing
    {



        //   public string fpath = Lonin.P_path;
        public string fpath;
        public string group = "Base";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public RWcofing(string Filename, string thegroup)
        {
           // fpath = Global.BasePath + @"\" + Global.currModel + "-config.ini";
            group = thegroup;
        }
        public string Thefpath
        {
            set
            {
                fpath = value;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 读取ini
        /// </summary>
        /// <param name="group">数据分组</param>
        /// <param name="key">关键字</param>
        /// <param name="filepath">init文件地址</param>
        /// <returns>关键字对应的值，没有时含有默认值</returns>
        public  string readini(string key)
        {
            StringBuilder temp = new StringBuilder();
            GetPrivateProfileString(group, key, "", temp, 255, fpath);
            return temp.ToString();
        }

        /// <summary>
        /// 存储ini
        /// </summary>
        /// <param name="group">数据分组</param>
        /// <param name="key">关键字</param>
        /// <param name="value">关键字对应的值</param>
        /// <param name="filepath">ini文件地址</param>
        public void writeini(string key, string value)
        {
            WritePrivateProfileString(group, key, value, fpath);
        }

        //存储 关闭时的用的型号
        public static void closefile(string model)
        {
            WritePrivateProfileString("base", "model", model, Global.modelPath);
        }

        //存储 关闭时的用的型号
        public static string openfile()
        {
            StringBuilder temp = new StringBuilder();
            GetPrivateProfileString("base", "model", "", temp, 255, Global.modelPath);
            return temp.ToString();
        }

        //读取型号列表
        public static List<string> openfiles()
        {
            if (!System.IO.File.Exists(Global.modelPath))//若文件夹不存在则新建文件夹   
            {
                System.IO.File.Create(Global.modelPath); //新建文件夹   
            }
            List<string> models = new List<string>();

            StringBuilder temp = new StringBuilder();
            GetPrivateProfileString("base", "model_num", "", temp, 255, Global.modelPath);

            int num = Convert.ToInt32(temp.ToString());

            for (int i = 0; i < num; i++)
            {

                GetPrivateProfileString("base", "modelS___" + i.ToString(), "", temp, 255, Global.modelPath);

                models.Add(temp.ToString());
            }


            return models;

        }

        //保存型号列表
        public static void closefiles(List<string> model)
        {

            int num = model.Count;
            WritePrivateProfileString("base", "model_num", num.ToString(), Global.modelPath);
            for (int i = 0; i < num; i++)
            {
                WritePrivateProfileString("base", "modelS___" + i.ToString(), model[i], Global.modelPath);
            }
        }
        

  
        //public static void readPbmp()
        //{
        //    try
        //    {
        //        Global.pubpType = readini("PumpType");
        //        Global.A_pumpDensity=Convert.ToDouble(readini("A_pumpDensity"));
        //        Global.A_equivalent =Convert.ToDouble(readini("A_equivalent"));
        //        Global.B_pumpDensity = Convert.ToDouble(readini("B_pumpDensity"));
        //        Global.B_equivalent =Convert.ToDouble(readini("B_equivalent"));
        //        Global.A_ratio =Convert.ToDouble(readini("A_ratio"));
        //        Global.B_ratio = Convert.ToDouble(readini("B_ratio"));
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}


  }


}
