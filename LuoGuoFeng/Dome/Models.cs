using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LuoGuoFeng
{

     [Serializable]
    class Models
    {
        public string FileName{set; get; }

  //public string FileNub { set; get; }
    }

    class ModelsHelper
    {


        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


          
        private string filePath = string.Empty;
        public ModelsHelper(string Path)
        {
            filePath = Path;
        }

        /// <summary>
        /// 序列化到文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listUser"></param>
        /// <returns></returns>
        public bool SerializedUser(string path,List<Models> listUser)
        {
            if (listUser == null)
            {
                return false;
            }
            BinaryFormatter format = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                format.Serialize(fs, listUser);
                return true;
            }
        }

        /// <summary>
        /// 反序列化到文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listUser"></param>
        /// <returns></returns>
        public  List<Models> DeSerializedUser(string path)
        {
            BinaryFormatter format = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    object o = format.Deserialize(fs);
                    return o as List<Models>;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        #region MyRegion
        
      
        /// <summary>
        /// 是有超级用户
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listUser"></param>
        //public void CheckSupperUser(string path,List<string> listUser)
        //{
        //    if (!File.Exists(path))
        //    {
        //        User user = new User()
        //        { Index = 0, UserName = "Admin", Password = "Admin", Level = Authority.Admin };
        //        listUser.Add(user);
        //        SerializedUser(path, listUser);

        //    }
        //}
  #endregion

        /// <summary>
        /// 检测重复
        /// </summary>
        /// <param name="listUser"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckContainmodel(List<Models> listUser, String userName)
        {
            var user = from item in listUser
                       where item.FileName == userName
                       select item;
            if (user.Count() > 0)
            { return true;}

            return false;

        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listUser"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddModel(string path, List<Models> listUser,Models model)
        {
            if (model == null | listUser == null) return false;

            if (CheckContainmodel(listUser, model.FileName)) return false;
            listUser.Add(model);
            SerializedUser(path, listUser);
            return true;
         }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listUser"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteModel(string path, List<Models> listUser, Models userName)
        {
            if (listUser == null) return false;
            int index = 0;
            foreach (var item in listUser)
            {
                if (item.FileName== userName.FileName)
                {
                    listUser.RemoveAt(index);
                    SerializedUser(path, listUser);
                    return true;
                }
            }
            return false;

        }



        private static string _NowModel;

        public static string NowModels
        {
            get
            {
                ReadNowModel("now.ini");
                return _NowModel;
            }
            set
            {
                _NowModel = value;
                SaveNowModel("now.ini");
            }
        }
        

        
        

        public  static void ReadNowModel(string filepath)
        {
            StringBuilder temp = new StringBuilder();
            GetPrivateProfileString("model", "", "Now", temp, 255, filepath);
            _NowModel = temp.ToString();
        }

        /// <summary>
        /// 存储ini
        /// </summary>
        /// <param name="group">数据分组</param>
        /// <param name="key">关键字</param>
        /// <param name="value">关键字对应的值</param>
        /// <param name="filepath">ini文件地址</param>
       public   static void SaveNowModel(string filepath)
        {

            WritePrivateProfileString("model", "Now", _NowModel, filepath);
        }



        #region outtime
		 


        //public bool EditUser(string path, List<User> listUser, User user)
        //{
        //    //if (listUser == null)
        //    //{
        //    //    return false;
        //    //}
        //    //foreach (var item in listUser)
        //    //{
        //    //    if (item.UserName == user.UserName)
        //    //    {
        //    //        item.Password = user.Password;
        //    //        item.Level = user.Level;
        //    //        SerializedUser(path,listUser);
        //    //        return true;
        //    //    }
        //    //}

        //    //return false;
        //}


        //public User CheckUserLoing(string path,string userName,String password)
        //{
        //    ////path = Application.StartupPath+"\\"+ path;
        //    //if (!File.Exists(path)) return null;
        //    //List<User> list = DeSerializedUser(path);
        //    //var res = from item in list
        //    //          where item.UserName == userName & item.Password == password
        //    //          select item;
        //    //if (res.Count() == 0) return null;
        //    //User user = new User();
        //    //foreach(var item in res)
        //    //{
        //    //    user.UserName = item.UserName;
        //    //    user.Password = item.Password;
        //    //    user.Level = item.Level;
        //    //}
        //    //return user;   
        //}
        	#endregion
    }


}











