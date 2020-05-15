using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;

namespace LuoGuoFeng.Frm
{
    public partial class UserManage :MetroForm
    {

        UserHelper userHelper = new UserHelper("");
        List<User> listUser = new List<User>();

        public UserManage()
        {
            InitializeComponent();
            if (File.Exists("user.pt"))
            {
                listUser = userHelper.DeSerializedUser("user.pt");
                ShowUserData(listUser);
            }
        }
        private void ShowUserData(List <User> list)
        {
            List<User> upList = new List<User>();
            for (int i = 0; i < list.Count; i++)
            {
                if (i>0)
                {
                    upList.Add(list[i]);
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = upList;
        }


        private User GetUser(List<User> listUser)
        {
            if (textuser.Text == string.Empty | textPassword.Text == string.Empty)
            {
                return null;
            }
            User user = new User();
            user.Index = listUser[listUser.Count - 1].Index + 1;
            user.UserName = textuser.Text;
            user.Password = textPassword.Text;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    user.Level = Authority.Admin;
                    break;
                case 1:
                    user.Level = Authority.Eng;
                    break;
                case 2:
                    user.Level = Authority.Op;
                    break;
                default:
                    break;
            }
            return user;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = GetUser(listUser);
            if (user ==null)
            {
                MessageBox.Show("输入内容错误");
            }
            var res = userHelper.AddUser("user.pt", listUser, user);
            if (res)
            {
                MessageBox.Show("添加成功");
                ShowUserData(listUser);
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            User user = new User();
            user = GetUser(listUser);
          var res =  userHelper.EditUser("user.pt", listUser,user);
            if (res)
            {
                MessageBox.Show("修改成功");
                ShowUserData(listUser);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void btnDetale_Click(object sender, EventArgs e)
        {
            if (textuser.Text == string.Empty)
            {
                MessageBox.Show("用户名不真确");

            }
             var res =  userHelper.DeleteUser("user.pt", listUser, textuser.Text);
            if (res)
            {
                MessageBox.Show("删除成功");
                ShowUserData(listUser);
            }
            else
            {
                MessageBox.Show("删除失败");
            }

        }

        private void SetUser()
        {
            DataGridViewSelectedRowCollection rowCollection= dataGridView1.SelectedRows;
            if (rowCollection.Count == 0)
            {
                return;
            }
            DataGridViewRow row = rowCollection[0];
            textuser.Text = row.Cells[1].Value.ToString();
            textPassword.Text = row.Cells[2].Value.ToString();
            switch (row.Cells[3].Value.ToString())
            {
                case "Admin":
                    comboBox1.SelectedIndex = 0;
                    break;
                case "Eng":
                    comboBox1.SelectedIndex = 1;
                    break;
                case "Op":
                    comboBox1.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SetUser();
        }

        private void UserManage_Load(object sender, EventArgs e)
        {

        }
    }
}
