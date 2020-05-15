namespace LuoGuoFeng.Frm
{
    partial class FrmManual
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
            this.panelBar = new System.Windows.Forms.Panel();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.btnGlue = new System.Windows.Forms.Button();
            this.btnDrive = new System.Windows.Forms.Button();
            this.btncalibration = new System.Windows.Forms.Button();
            this.btnAxis = new System.Windows.Forms.Button();
            this.btnIO = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelBar);
            this.panel1.Controls.Add(this.btnGlue);
            this.panel1.Controls.Add(this.btnDrive);
            this.panel1.Controls.Add(this.btncalibration);
            this.panel1.Controls.Add(this.btnAxis);
            this.panel1.Controls.Add(this.btnIO);
            this.panel1.Location = new System.Drawing.Point(88, 583);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 93);
            this.panel1.TabIndex = 1;
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panelBar.Location = new System.Drawing.Point(0, 2);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(137, 10);
            this.panelBar.TabIndex = 1;
            // 
            // panel_Main
            // 
            this.panel_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Main.Location = new System.Drawing.Point(1, 2);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(868, 549);
            this.panel_Main.TabIndex = 2;
            // 
            // btnGlue
            // 
            this.btnGlue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.btnGlue.FlatAppearance.BorderSize = 5;
            this.btnGlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGlue.Image = global::LuoGuoFeng.Properties.Resources.笔;
            this.btnGlue.Location = new System.Drawing.Point(272, 12);
            this.btnGlue.Name = "btnGlue";
            this.btnGlue.Size = new System.Drawing.Size(135, 79);
            this.btnGlue.TabIndex = 0;
            this.btnGlue.UseVisualStyleBackColor = true;
            this.btnGlue.Click += new System.EventHandler(this.btnGlue_Click);
            // 
            // btnDrive
            // 
            this.btnDrive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.btnDrive.FlatAppearance.BorderSize = 5;
            this.btnDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrive.Image = global::LuoGuoFeng.Properties.Resources.设备;
            this.btnDrive.Location = new System.Drawing.Point(542, 12);
            this.btnDrive.Name = "btnDrive";
            this.btnDrive.Size = new System.Drawing.Size(135, 79);
            this.btnDrive.TabIndex = 0;
            this.btnDrive.UseVisualStyleBackColor = true;
            this.btnDrive.Click += new System.EventHandler(this.btnDrive_Click);
            // 
            // btncalibration
            // 
            this.btncalibration.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.btncalibration.FlatAppearance.BorderSize = 5;
            this.btncalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncalibration.Image = global::LuoGuoFeng.Properties.Resources.笔__1_;
            this.btncalibration.Location = new System.Drawing.Point(407, 12);
            this.btncalibration.Name = "btncalibration";
            this.btncalibration.Size = new System.Drawing.Size(135, 79);
            this.btncalibration.TabIndex = 0;
            this.btncalibration.UseVisualStyleBackColor = true;
            this.btncalibration.Click += new System.EventHandler(this.btncalibration_Click);
            // 
            // btnAxis
            // 
            this.btnAxis.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.btnAxis.FlatAppearance.BorderSize = 5;
            this.btnAxis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAxis.Image = global::LuoGuoFeng.Properties.Resources.轴向_48;
            this.btnAxis.Location = new System.Drawing.Point(137, 12);
            this.btnAxis.Name = "btnAxis";
            this.btnAxis.Size = new System.Drawing.Size(135, 79);
            this.btnAxis.TabIndex = 0;
            this.btnAxis.UseVisualStyleBackColor = true;
            this.btnAxis.Click += new System.EventHandler(this.btnAxis_Click);
            // 
            // btnIO
            // 
            this.btnIO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.btnIO.FlatAppearance.BorderSize = 5;
            this.btnIO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIO.Image = global::LuoGuoFeng.Properties.Resources.IO_01;
            this.btnIO.Location = new System.Drawing.Point(2, 12);
            this.btnIO.Name = "btnIO";
            this.btnIO.Size = new System.Drawing.Size(135, 79);
            this.btnIO.TabIndex = 0;
            this.btnIO.UseVisualStyleBackColor = true;
            this.btnIO.Click += new System.EventHandler(this.btnIO_Click);
            // 
            // FrmManual
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
            this.Name = "FrmManual";
            this.Text = "Manual";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIO;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button btnGlue;
        private System.Windows.Forms.Button btncalibration;
        private System.Windows.Forms.Button btnDrive;
        private System.Windows.Forms.Button btnAxis;
        private System.Windows.Forms.Panel panel_Main;


    }
}