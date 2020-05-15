using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace LuoGuoFeng.Frm
{

    public delegate void SendLoginIN(User user);
    public partial class User_Login : MetroForm
{
      public   SendLoginIN sendLogin;
        public User_Login()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserHelper help = new UserHelper("");
            var res = help.CheckUserLoing("user.pt", TxtUser.Text,txtPassword.Text);
            if (res == null) { MessageBox.Show("登录失败，用户名或密码不正确"); return; }
            sendLogin(res);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserHelper help = new UserHelper("");
            var res = help.CheckUserLoing("user.pt", TxtUser.Text, txtPassword.Text);
            if (res == null) { MessageBox.Show("登录失败，用户名或密码不正确"); return; }
            UserManage frm = new UserManage();
            frm.Show();

        }






    }
}
