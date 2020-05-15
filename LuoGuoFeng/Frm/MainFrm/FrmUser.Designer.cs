namespace LuoGuoFeng.Frm
{
    partial class User_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnLoing = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtUser = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(182, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 7;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = global::LuoGuoFeng.Properties.Resources.修改;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(467, 508);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(145, 50);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "  Edit User";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLoing
            // 
            this.btnLoing.BackColor = System.Drawing.Color.White;
            this.btnLoing.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.btnLoing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoing.Image = global::LuoGuoFeng.Properties.Resources.登入;
            this.btnLoing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoing.Location = new System.Drawing.Point(173, 508);
            this.btnLoing.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoing.Name = "btnLoing";
            this.btnLoing.Size = new System.Drawing.Size(145, 50);
            this.btnLoing.TabIndex = 3;
            this.btnLoing.Text = "Loing";
            this.btnLoing.UseVisualStyleBackColor = false;
            this.btnLoing.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LuoGuoFeng.Properties.Resources.用户256;
            this.pictureBox1.Location = new System.Drawing.Point(226, 64);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 268);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // TxtUser
            // 
            // 
            // 
            // 
            this.TxtUser.CustomButton.Image = null;
            this.TxtUser.CustomButton.Location = new System.Drawing.Point(157, 1);
            this.TxtUser.CustomButton.Name = "";
            this.TxtUser.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.TxtUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtUser.CustomButton.TabIndex = 1;
            this.TxtUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtUser.CustomButton.UseSelectable = true;
            this.TxtUser.CustomButton.Visible = false;
            this.TxtUser.Lines = new string[0];
            this.TxtUser.Location = new System.Drawing.Point(291, 371);
            this.TxtUser.MaxLength = 32767;
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.PasswordChar = '\0';
            this.TxtUser.PromptText = "User";
            this.TxtUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtUser.SelectedText = "";
            this.TxtUser.SelectionLength = 0;
            this.TxtUser.SelectionStart = 0;
            this.TxtUser.ShortcutsEnabled = true;
            this.TxtUser.Size = new System.Drawing.Size(187, 31);
            this.TxtUser.TabIndex = 1;
            this.TxtUser.UseSelectable = true;
            this.TxtUser.WaterMark = "User";
            this.TxtUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(157, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(291, 431);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PromptText = "PassWord";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(187, 31);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.WaterMark = "PassWord";
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // User_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 593);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.TxtUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnLoing);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "User_Login";
            this.Text = "User Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private MetroFramework.Controls.MetroTextBox TxtUser;
        private MetroFramework.Controls.MetroTextBox txtPassword;
    }
}