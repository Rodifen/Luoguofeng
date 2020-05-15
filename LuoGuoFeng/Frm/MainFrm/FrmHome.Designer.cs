namespace LuoGuoFeng.Frm
{
    partial class FrmHome
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
            this.ucSwitch7 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch2 = new HZH_Controls.Controls.UCSwitch();
            this.rich_Mess = new System.Windows.Forms.RichTextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ucSwitch1 = new HZH_Controls.Controls.UCSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucSwitch7
            // 
            this.ucSwitch7.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch7.Checked = true;
            this.ucSwitch7.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch7.FalseTextColr = System.Drawing.Color.DeepSkyBlue;
            this.ucSwitch7.Location = new System.Drawing.Point(541, 632);
            this.ucSwitch7.Name = "ucSwitch7";
            this.ucSwitch7.Size = new System.Drawing.Size(123, 62);
            this.ucSwitch7.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch7.TabIndex = 15;
            this.ucSwitch7.Texts = new string[] {
        "连续",
        "单步"};
            this.ucSwitch7.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucSwitch7.TrueTextColr = System.Drawing.Color.Black;
            // 
            // ucSwitch2
            // 
            this.ucSwitch2.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch2.Checked = true;
            this.ucSwitch2.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch2.FalseTextColr = System.Drawing.Color.LightSeaGreen;
            this.ucSwitch2.Location = new System.Drawing.Point(541, 540);
            this.ucSwitch2.Name = "ucSwitch2";
            this.ucSwitch2.Size = new System.Drawing.Size(123, 62);
            this.ucSwitch2.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch2.TabIndex = 30;
            this.ucSwitch2.Texts = new string[] {
        "单次",
        "循环"};
            this.ucSwitch2.TrueColor = System.Drawing.Color.PaleGreen;
            this.ucSwitch2.TrueTextColr = System.Drawing.Color.Black;
            this.ucSwitch2.CheckedChanged += new System.EventHandler(this.ucSwitch2_CheckedChanged);
            // 
            // rich_Mess
            // 
            this.rich_Mess.Location = new System.Drawing.Point(29, 510);
            this.rich_Mess.Name = "rich_Mess";
            this.rich_Mess.Size = new System.Drawing.Size(458, 204);
            this.rich_Mess.TabIndex = 91;
            this.rich_Mess.Text = "";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(34)))), ((int)(((byte)(122)))));
            this.btnReset.FlatAppearance.BorderSize = 5;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Image = global::LuoGuoFeng.Properties.Resources.Reset;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(713, 420);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(126, 62);
            this.btnReset.TabIndex = 92;
            this.btnReset.Text = "Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(34)))), ((int)(((byte)(122)))));
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::LuoGuoFeng.Properties.Resources.暂停;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(713, 620);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 62);
            this.button1.TabIndex = 92;
            this.button1.Text = "Start";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(473, 384);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 34);
            this.numericUpDown1.TabIndex = 94;
            // 
            // ucSwitch1
            // 
            this.ucSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch1.Checked = true;
            this.ucSwitch1.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch1.FalseTextColr = System.Drawing.Color.LightSeaGreen;
            this.ucSwitch1.Location = new System.Drawing.Point(541, 451);
            this.ucSwitch1.Name = "ucSwitch1";
            this.ucSwitch1.Size = new System.Drawing.Size(123, 62);
            this.ucSwitch1.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch1.TabIndex = 30;
            this.ucSwitch1.Texts = new string[] {
        "带料",
        "空跑"};
            this.ucSwitch1.TrueColor = System.Drawing.Color.PaleGreen;
            this.ucSwitch1.TrueTextColr = System.Drawing.Color.Black;
            this.ucSwitch1.CheckedChanged += new System.EventHandler(this.ucSwitch2_CheckedChanged);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(894, 743);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.rich_Mess);
            this.Controls.Add(this.ucSwitch1);
            this.Controls.Add(this.ucSwitch2);
            this.Controls.Add(this.ucSwitch7);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCSwitch ucSwitch7;
        private HZH_Controls.Controls.UCSwitch ucSwitch2;
        private System.Windows.Forms.RichTextBox rich_Mess;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private HZH_Controls.Controls.UCSwitch ucSwitch1;
    }
}