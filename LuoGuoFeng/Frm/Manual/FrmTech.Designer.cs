namespace LuoGuoFeng
{
    partial class FrmTech
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
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.len_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.speed_numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Z_Enable = new System.Windows.Forms.Button();
            this.Z_ORG = new System.Windows.Forms.Button();
            this.Y_ORG = new System.Windows.Forms.Button();
            this.X_ORG = new System.Windows.Forms.Button();
            this.Zs_button = new System.Windows.Forms.Button();
            this.Zp_button = new System.Windows.Forms.Button();
            this.Xp_button = new System.Windows.Forms.Button();
            this.Xs_button = new System.Windows.Forms.Button();
            this.Ys_button = new System.Windows.Forms.Button();
            this.Yp_button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Y_Enable = new System.Windows.Forms.Button();
            this.X_Enable = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.len_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(144, 163);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(83, 33);
            this.checkBox6.TabIndex = 75;
            this.checkBox6.Text = "定长";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // len_numericUpDown
            // 
            this.len_numericUpDown.DecimalPlaces = 3;
            this.len_numericUpDown.Location = new System.Drawing.Point(144, 117);
            this.len_numericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.len_numericUpDown.Name = "len_numericUpDown";
            this.len_numericUpDown.Size = new System.Drawing.Size(173, 34);
            this.len_numericUpDown.TabIndex = 74;
            this.len_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 3;
            this.numericUpDown4.Location = new System.Drawing.Point(144, 71);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(173, 34);
            this.numericUpDown4.TabIndex = 73;
            this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // speed_numericUpDown1
            // 
            this.speed_numericUpDown1.DecimalPlaces = 2;
            this.speed_numericUpDown1.Location = new System.Drawing.Point(144, 25);
            this.speed_numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.speed_numericUpDown1.Name = "speed_numericUpDown1";
            this.speed_numericUpDown1.Size = new System.Drawing.Size(173, 34);
            this.speed_numericUpDown1.TabIndex = 72;
            this.speed_numericUpDown1.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // Z_Enable
            // 
            this.Z_Enable.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Z_Enable.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Z_Enable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Z_Enable.Location = new System.Drawing.Point(710, 36);
            this.Z_Enable.Name = "Z_Enable";
            this.Z_Enable.Size = new System.Drawing.Size(112, 35);
            this.Z_Enable.TabIndex = 70;
            this.Z_Enable.Text = "Z轴使能";
            this.Z_Enable.UseVisualStyleBackColor = false;
            this.Z_Enable.Click += new System.EventHandler(this.Z_Enable_Click);
            // 
            // Z_ORG
            // 
            this.Z_ORG.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Z_ORG.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Z_ORG.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Z_ORG.Location = new System.Drawing.Point(480, 436);
            this.Z_ORG.Name = "Z_ORG";
            this.Z_ORG.Size = new System.Drawing.Size(91, 50);
            this.Z_ORG.TabIndex = 69;
            this.Z_ORG.Text = "Z 回零";
            this.Z_ORG.UseVisualStyleBackColor = false;
            this.Z_ORG.Click += new System.EventHandler(this.Z_ORG_Click);
            // 
            // Y_ORG
            // 
            this.Y_ORG.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Y_ORG.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Y_ORG.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Y_ORG.Location = new System.Drawing.Point(342, 437);
            this.Y_ORG.Name = "Y_ORG";
            this.Y_ORG.Size = new System.Drawing.Size(87, 50);
            this.Y_ORG.TabIndex = 68;
            this.Y_ORG.Text = "Y 回零";
            this.Y_ORG.UseVisualStyleBackColor = false;
            this.Y_ORG.Click += new System.EventHandler(this.Y_ORG_Click);
            // 
            // X_ORG
            // 
            this.X_ORG.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.X_ORG.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.X_ORG.ForeColor = System.Drawing.SystemColors.ControlText;
            this.X_ORG.Location = new System.Drawing.Point(217, 437);
            this.X_ORG.Name = "X_ORG";
            this.X_ORG.Size = new System.Drawing.Size(91, 50);
            this.X_ORG.TabIndex = 71;
            this.X_ORG.Text = "X 回零";
            this.X_ORG.UseVisualStyleBackColor = false;
            this.X_ORG.Click += new System.EventHandler(this.X_ORG_Click);
            // 
            // Zs_button
            // 
            this.Zs_button.BackColor = System.Drawing.Color.Gainsboro;
            this.Zs_button.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Zs_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Zs_button.Location = new System.Drawing.Point(525, 216);
            this.Zs_button.Name = "Zs_button";
            this.Zs_button.Size = new System.Drawing.Size(91, 50);
            this.Zs_button.TabIndex = 67;
            this.Zs_button.Text = "Z-";
            this.Zs_button.UseVisualStyleBackColor = false;
            this.Zs_button.Click += new System.EventHandler(this.Zs_button_Click);
            // 
            // Zp_button
            // 
            this.Zp_button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Zp_button.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Zp_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Zp_button.Location = new System.Drawing.Point(525, 311);
            this.Zp_button.Name = "Zp_button";
            this.Zp_button.Size = new System.Drawing.Size(91, 50);
            this.Zp_button.TabIndex = 66;
            this.Zp_button.Text = "Z+";
            this.Zp_button.UseVisualStyleBackColor = false;
            this.Zp_button.Click += new System.EventHandler(this.Zp_button_Click);
            this.Zp_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zp_button_MouseDown);
            this.Zp_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Zp_button_MouseUp);
            // 
            // Xp_button
            // 
            this.Xp_button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Xp_button.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Xp_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Xp_button.Location = new System.Drawing.Point(420, 264);
            this.Xp_button.Name = "Xp_button";
            this.Xp_button.Size = new System.Drawing.Size(91, 50);
            this.Xp_button.TabIndex = 65;
            this.Xp_button.Text = "X+";
            this.Xp_button.UseVisualStyleBackColor = false;
            this.Xp_button.Click += new System.EventHandler(this.Xp_button_Click);
            this.Xp_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Xp_button_MouseDown);
            this.Xp_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Xp_button_MouseUp);
            // 
            // Xs_button
            // 
            this.Xs_button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Xs_button.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Xs_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Xs_button.Location = new System.Drawing.Point(203, 264);
            this.Xs_button.Name = "Xs_button";
            this.Xs_button.Size = new System.Drawing.Size(91, 50);
            this.Xs_button.TabIndex = 64;
            this.Xs_button.Text = "X-";
            this.Xs_button.UseVisualStyleBackColor = false;
            this.Xs_button.Click += new System.EventHandler(this.Xs_button_Click);
            this.Xs_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Xs_button_MouseDown);
            this.Xs_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Xs_button_MouseUp);
            // 
            // Ys_button
            // 
            this.Ys_button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Ys_button.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Ys_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Ys_button.Location = new System.Drawing.Point(309, 311);
            this.Ys_button.Name = "Ys_button";
            this.Ys_button.Size = new System.Drawing.Size(91, 50);
            this.Ys_button.TabIndex = 63;
            this.Ys_button.Text = "Y-";
            this.Ys_button.UseVisualStyleBackColor = false;
            this.Ys_button.Click += new System.EventHandler(this.Ys_button_Click);
            this.Ys_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ys_button_MouseDown);
            this.Ys_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Ys_button_MouseUp);
            // 
            // Yp_button
            // 
            this.Yp_button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Yp_button.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Yp_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Yp_button.Location = new System.Drawing.Point(309, 216);
            this.Yp_button.Name = "Yp_button";
            this.Yp_button.Size = new System.Drawing.Size(91, 50);
            this.Yp_button.TabIndex = 62;
            this.Yp_button.Text = "Y+";
            this.Yp_button.UseVisualStyleBackColor = false;
            this.Yp_button.Click += new System.EventHandler(this.Yp_button_Click);
            this.Yp_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Yp_button_MouseDown);
            this.Yp_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Yp_button_MouseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(57, 76);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 29);
            this.label8.TabIndex = 60;
            this.label8.Text = "加速度";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(57, 28);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 29);
            this.label20.TabIndex = 61;
            this.label20.Text = "速度";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(57, 124);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 29);
            this.label18.TabIndex = 59;
            this.label18.Text = "距离";
            // 
            // Y_Enable
            // 
            this.Y_Enable.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Y_Enable.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Y_Enable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Y_Enable.Location = new System.Drawing.Point(557, 36);
            this.Y_Enable.Name = "Y_Enable";
            this.Y_Enable.Size = new System.Drawing.Size(112, 35);
            this.Y_Enable.TabIndex = 70;
            this.Y_Enable.Text = "Y轴使能";
            this.Y_Enable.UseVisualStyleBackColor = false;
            this.Y_Enable.Click += new System.EventHandler(this.Y_Enable_Click);
            // 
            // X_Enable
            // 
            this.X_Enable.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.X_Enable.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.X_Enable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.X_Enable.Location = new System.Drawing.Point(419, 36);
            this.X_Enable.Name = "X_Enable";
            this.X_Enable.Size = new System.Drawing.Size(112, 35);
            this.X_Enable.TabIndex = 70;
            this.X_Enable.Text = "X轴使能";
            this.X_Enable.UseVisualStyleBackColor = false;
            this.X_Enable.Click += new System.EventHandler(this.X_Enable_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(557, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 70;
            this.button1.Text = "All 使能";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmTech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(868, 549);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.len_numericUpDown);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.speed_numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.X_Enable);
            this.Controls.Add(this.Y_Enable);
            this.Controls.Add(this.Z_Enable);
            this.Controls.Add(this.Z_ORG);
            this.Controls.Add(this.Y_ORG);
            this.Controls.Add(this.X_ORG);
            this.Controls.Add(this.Zs_button);
            this.Controls.Add(this.Zp_button);
            this.Controls.Add(this.Xp_button);
            this.Controls.Add(this.Xs_button);
            this.Controls.Add(this.Ys_button);
            this.Controls.Add(this.Yp_button);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmTech";
            this.Text = "FrmTech";
            this.Load += new System.EventHandler(this.FrmTech_Load);
            ((System.ComponentModel.ISupportInitialize)(this.len_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.NumericUpDown len_numericUpDown;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown speed_numericUpDown1;
        private System.Windows.Forms.Button Z_Enable;
        private System.Windows.Forms.Button Z_ORG;
        private System.Windows.Forms.Button Y_ORG;
        private System.Windows.Forms.Button X_ORG;
        private System.Windows.Forms.Button Zs_button;
        private System.Windows.Forms.Button Zp_button;
        private System.Windows.Forms.Button Xp_button;
        private System.Windows.Forms.Button Xs_button;
        private System.Windows.Forms.Button Ys_button;
        private System.Windows.Forms.Button Yp_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button Y_Enable;
        private System.Windows.Forms.Button X_Enable;
        private System.Windows.Forms.Button button1;
    }
}