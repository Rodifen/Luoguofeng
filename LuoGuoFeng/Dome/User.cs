using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace LuoGuoFeng
{
    [Serializable]
    public  class User
    {
       public int Index { set; get; }
       public string UserName { set; get; }
       public String Password { set; get; }
      // public Authorityc
       public  Authority Level { set; get; }

    }

    public enum Authority
    {
        Admin,
        Eng,
        Op, 
        Empty,
    }
    //接口 +反射

    public class UserHelper
    {
        private string filePath = string.Empty;
        public UserHelper(string Path)
        {
            filePath = Path;
        }

        /// <summary>
        /// 序列化到文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listUser"></param>
        /// <returns></returns>
        public bool SerializedUser(string path,List<User> listUser)
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
        public List<User> DeSerializedUser(string path)
        {
            BinaryFormatter format = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    object o = format.Deserialize(fs);
                    return o as List<User>;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 是有超级用户
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listUser"></param>
        public void CheckSupperUser(string path,List<User> listUser)
        {
            if (!File.Exists(path))
            {
                User user = new User()
                { Index = 0, UserName = "Admin", Password = "Admin", Level = Authority.Admin };
                listUser.Add(user);
                SerializedUser(path, listUser);

            }
        }


        /// <summary>
        /// 检测重复
        /// </summary>
        /// <param name="listUser"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckContainUser(List<User> listUser, String userName)
        {
            var user = from item in listUser
                       where item.UserName == userName
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
        public bool AddUser(string path, List<User> listUser,User user)
        {
            if (user == null) return false;

            if (CheckContainUser(listUser, user.UserName)) return false;
            listUser.Add(user);
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
        public bool DeleteUser(string path, List<User> listUser, string userName)
        {
            if (listUser == null) return false;
            int index = 0;
            foreach (var item in listUser)
            {
                if (item.UserName == userName)
                {
                    listUser.RemoveAt(index);
                    SerializedUser(path, listUser);
                    return true;
                }
            }
            return false;

        }


        public bool EditUser(string path, List<User> listUser, User user)
        {
            if (listUser == null)
            {
                return false;
            }
            foreach (var item in listUser)
            {
                if (item.UserName == user.UserName)
                {
                    item.Password = user.Password;
                    item.Level = user.Level;
                    SerializedUser(path,listUser);
                    return true;
                }
            }

            return false;
        }


        public User CheckUserLoing(string path,string userName,String password)
        {
            //path = Application.StartupPath+"\\"+ path;
            if (!File.Exists(path)) return null;
            List<User> list = DeSerializedUser(path);
            var res = from item in list
                      where item.UserName == userName & item.Password == password
                      select item;
            if (res.Count() == 0) return null;
            User user = new User();
            foreach(var item in res)
            {
                user.UserName = item.UserName;
                user.Password = item.Password;
                user.Level = item.Level;
            }
            return user;   
        }

    }











}
