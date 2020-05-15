namespace LuoGuoFeng
{
    partial class FrmSet
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMCM = new System.Windows.Forms.Button();
            this.btn_axis = new System.Windows.Forms.Button();
            this.btnSys = new System.Windows.Forms.Button();
            this.btnProgram = new System.Windows.Forms.Button();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMCM);
            this.panel1.Controls.Add(this.btn_axis);
            this.panel1.Controls.Add(this.btnSys);
            this.panel1.Controls.Add(this.btnProgram);
            this.panel1.Location = new System.Drawing.Point(9, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 672);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = ">>";
            // 
            // btnMCM
            // 
            this.btnMCM.FlatAppearance.BorderSize = 0;
            this.btnMCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMCM.Image = global::LuoGuoFeng.Properties.Resources.扳手;
            this.btnMCM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMCM.Location = new System.Drawing.Point(4, 146);
            this.btnMCM.Name = "btnMCM";
            this.btnMCM.Size = new System.Drawing.Size(174, 44);
            this.btnMCM.TabIndex = 0;
            this.btnMCM.Text = "MCM";
            this.btnMCM.UseVisualStyleBackColor = true;
            this.btnMCM.Click += new System.EventHandler(this.btnMCM_Click);
            // 
            // btn_axis
            // 
            this.btn_axis.FlatAppearance.BorderSize = 0;
            this.btn_axis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_axis.Image = global::LuoGuoFeng.Properties.Resources.轴向;
            this.btn_axis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_axis.Location = new System.Drawing.Point(4, 50);
            this.btn_axis.Name = "btn_axis";
            this.btn_axis.Size = new System.Drawing.Size(174, 44);
            this.btn_axis.TabIndex = 0;
            this.btn_axis.Text = "          Axis Parame";
            this.btn_axis.UseVisualStyleBackColor = true;
            this.btn_axis.Click += new System.EventHandler(this.btn_axis_Click);
            // 
            // btnSys
            // 
            this.btnSys.FlatAppearance.BorderSize = 0;
            this.btnSys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSys.Image = global::LuoGuoFeng.Properties.Resources.电脑__1_;
            this.btnSys.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSys.Location = new System.Drawing.Point(4, 98);
            this.btnSys.Name = "btnSys";
            this.btnSys.Size = new System.Drawing.Size(174, 44);
            this.btnSys.TabIndex = 0;
            this.btnSys.Text = "  System";
            this.btnSys.UseVisualStyleBackColor = true;
            this.btnSys.Click += new System.EventHandler(this.btnSys_Click);
            // 
            // btnProgram
            // 
            this.btnProgram.FlatAppearance.BorderSize = 0;
            this.btnProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgram.Image = global::LuoGuoFeng.Properties.Resources.文件__1_;
            this.btnProgram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgram.Location = new System.Drawing.Point(4, 2);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(174, 44);
            this.btnProgram.TabIndex = 0;
            this.btnProgram.Text = "    Program";
            this.btnProgram.UseVisualStyleBackColor = true;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click);
            // 
            // panel_Main
            // 
            this.panel_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Main.Location = new System.Drawing.Point(247, 25);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(610, 676);
            this.panel_Main.TabIndex = 1;
            // 
            // FrmSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(869, 743);
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmSet";
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.Button btnProgram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMCM;
        private System.Windows.Forms.Button btn_axis;
        private System.Windows.Forms.Button btnSys;
    }
}