using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoGuoFeng
{
    public partial class Axis_par : Form
    {


        Data.RWcofing RWcofing = new Data.RWcofing(Global.AxisPar,"pump");
        
        public Axis_par()
        {
            InitializeComponent();
            RWcofing.Thefpath = Global.AxisPar;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Axis_par_Load(object sender, EventArgs e)
        {
     

            Global.X.read();
            Global.Y.read();
            Global.Z.read();
            Global.A.read();
            Global.B.read();
            write();

            ReadPump();
            ReadPumpA();
      //      readIO_name();
        }

        //      X axis    赋值   
        public void   parame()
        {
            try
            {
                Global.X.axis = decimal.ToUInt16(numericUpDown1.Value);
                Global.X.dEquiv = decimal.ToDouble(numericUpDown2.Value);
                Global.X.dStartVel = decimal.ToDouble(numericUpDown3.Value);
                Global.X.dTacc = decimal.ToDouble(numericUpDown4.Value);
                Global.X.dTdec = decimal.ToDouble(numericUpDown5.Value);  //X
                Global.X.dMaxVel = decimal.ToDouble(numericUpDown26.Value);
                Global.X.dS_para= decimal.ToDouble(numericUpDown27.Value);
                if (checkBox1.Checked)
                {
                    Global.X.Dir = 0;
                }
                else
                {
                    Global.X.Dir = 1;
                }


                Global.X.Home_LVel = Convert.ToDouble(textBox1.Text);
                Global.X.Home_HVel = Convert.ToDouble(textBox2.Text);
                Global.X.Home_time = Convert.ToDouble(textBox3.Text);
                Global.X.Home_mode = Convert.ToUInt16(textBox4.Text);
                Global.X.Home_offset = Convert.ToUInt16(textBox5.Text);   //X1

                //YYYYYYYY
                Global.Y.axis = decimal.ToUInt16(numericUpDown6.Value);
                Global.Y.dEquiv = decimal.ToDouble(numericUpDown7.Value);
                Global.Y.dStartVel = decimal.ToDouble(numericUpDown8.Value);
                Global.Y.dTacc = decimal.ToDouble(numericUpDown9.Value);
                Global.Y.dTdec = decimal.ToDouble(numericUpDown10.Value);   //Y
                Global.Y.dMaxVel = decimal.ToDouble(numericUpDown28.Value);
                Global.Y.dS_para = decimal.ToDouble(numericUpDown29.Value);
                if (checkBox3.Checked)
                {
                    Global.Y.Dir = 0;
                }
                else
                {
                    Global.Y.Dir = 1;
                }



                Global.Y.Home_LVel = Convert.ToDouble(textBox6.Text);
                Global.Y.Home_HVel = Convert.ToDouble(textBox7.Text);
                Global.Y.Home_time = Convert.ToDouble(textBox8.Text);
                Global.Y.Home_mode = Convert.ToUInt16(textBox9.Text);
                Global.Y.Home_offset = Convert.ToUInt16(textBox10.Text);    //Y1
                if (checkBox5.Checked)
                {
                    Global.Z.Dir = 0;
                }
                else
                {
                    Global.Z.Dir = 1;
                }


                //ZZZ
                Global.Z.axis = decimal.ToUInt16(numericUpDown11.Value);
                Global.Z.dEquiv = decimal.ToDouble(numericUpDown12.Value);
                Global.Z.dStartVel = decimal.ToDouble(numericUpDown13.Value);
                Global.Z.dTacc = decimal.ToDouble(numericUpDown14.Value);
                Global.Z.dTdec = decimal.ToDouble(numericUpDown15.Value);   //Z
                Global.Z.dMaxVel = decimal.ToDouble(numericUpDown30.Value);
                Global.Z.dS_para = decimal.ToDouble(numericUpDown31.Value); 


                Global.Z.Home_LVel = Convert.ToDouble(textBox11.Text);
                Global.Z.Home_HVel = Convert.ToDouble(textBox12.Text);
                Global.Z.Home_time = Convert.ToDouble(textBox13.Text);
                Global.Z.Home_mode = Convert.ToUInt16(textBox14.Text);
                Global.Z.Home_offset = Convert.ToUInt16(textBox15.Text);  //Z1

                //AAA
                Global.A.axis = decimal.ToUInt16(numericUpDown16.Value);
                Global.A.dEquiv = decimal.ToDouble(numericUpDown17.Value);
                Global.A.dStartVel = decimal.ToDouble(numericUpDown18.Value);
                Global.A.dTacc = decimal.ToDouble(numericUpDown19.Value);
                Global.A.dTdec = decimal.ToDouble(numericUpDown20.Value);   //A

                Global.A.Home_LVel = Convert.ToDouble(textBox16.Text);
                Global.A.Home_HVel = Convert.ToDouble(textBox17.Text);
                Global.A.Home_time = Convert.ToDouble(textBox18.Text);
                Global.A.Home_mode = Convert.ToUInt16(textBox19.Text);
                Global.A.Home_offset = Convert.ToUInt16(textBox20.Text); //A1
                Global.A.dMaxVel = decimal.ToDouble(numericUpDown32.Value);
                Global.A.dS_para = decimal.ToDouble(numericUpDown35.Value); 


                //BBBS
                Global.B.axis = decimal.ToUInt16(numericUpDown21.Value);
                Global.B.dEquiv = decimal.ToDouble(numericUpDown22.Value);
                Global.B.dStartVel = decimal.ToDouble(numericUpDown23.Value);
                Global.B.dTacc = decimal.ToDouble(numericUpDown24.Value);
                Global.B.dTdec = decimal.ToDouble(numericUpDown25.Value);   //B
                Global.B.dMaxVel = decimal.ToDouble(numericUpDown34.Value);
                Global.B.dS_para = decimal.ToDouble(numericUpDown33.Value); 


                Global.B.Home_LVel = Convert.ToDouble(textBox21.Text);
                Global.B.Home_HVel = Convert.ToDouble(textBox22.Text);
                Global.B.Home_time = Convert.ToDouble(textBox23.Text);
                Global.B.Home_mode = Convert.ToUInt16(textBox24.Text);
                Global.B.Home_offset = Convert.ToUInt16(textBox25.Text); //B1
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
            //XXXXXXXXXXXXX
         
        }
        public void write()
        {
            //XXXXXXXXXXXXX
            numericUpDown1.Value = Global.X.axis;
            numericUpDown2.Value  =Convert.ToDecimal(Global.X.dEquiv);
            numericUpDown3.Value=Convert.ToDecimal(Global.X.dStartVel);
            numericUpDown4.Value= Convert.ToDecimal( Global.X.dTacc ) ;
            numericUpDown5.Value =  Convert.ToDecimal(Global.X.dTdec);  //X
            numericUpDown26.Value = Convert.ToDecimal(Global.X.dMaxVel);
            numericUpDown27.Value = Convert.ToDecimal(Global.X.dS_para);

            if (Global.X.Dir == 0)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

            textBox1.Text = Global.X.Home_LVel.ToString();
            textBox2.Text =   Global.X.Home_HVel.ToString();
            textBox3.Text = Global.X.Home_time.ToString();
            textBox4.Text =  Global.X.Home_mode.ToString();
            textBox5.Text = Global.X.Home_offset.ToString();   //X1


            //YYYYYYYY
            numericUpDown6.Value = Global.Y.axis;
            numericUpDown7.Value = Convert.ToDecimal(Global.Y.dEquiv);
            numericUpDown8.Value = Convert.ToDecimal(Global.Y.dStartVel);
            numericUpDown9.Value = Convert.ToDecimal(Global.Y.dTacc);
            numericUpDown10.Value = Convert.ToDecimal(Global.Y.dTdec);  //Y
            numericUpDown28.Value = Convert.ToDecimal(Global.Y.dMaxVel);
            numericUpDown29.Value = Convert.ToDecimal(Global.Y.dS_para);

            if (Global.Y.Dir == 0)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }


            textBox6.Text = Global.Y.Home_LVel.ToString();
            textBox7.Text = Global.Y.Home_HVel.ToString();
            textBox8.Text = Global.Y.Home_time.ToString();
            textBox9.Text = Global.Y.Home_mode.ToString();
            textBox10.Text = Global.Y.Home_offset.ToString();   //Y


            //ZZZ
            numericUpDown11.Value = Global.Z.axis;
            numericUpDown12.Value = Convert.ToDecimal(Global.Z.dEquiv);
            numericUpDown13.Value = Convert.ToDecimal(Global.Z.dStartVel);
            numericUpDown14.Value = Convert.ToDecimal(Global.Z.dTacc);
            numericUpDown15.Value = Convert.ToDecimal(Global.Z.dTdec);  //Z
            numericUpDown30.Value = Convert.ToDecimal(Global.Z.dMaxVel);
            numericUpDown31.Value = Convert.ToDecimal(Global.Z.dS_para);

            if (Global.Z.Dir == 0)
            {
                checkBox5.Checked = true;
              
            }
            else
            {
                checkBox5.Checked = false;
            }


            textBox11.Text = Global.Z.Home_LVel.ToString();
            textBox12.Text = Global.Z.Home_HVel.ToString();
            textBox13.Text = Global.Z.Home_time.ToString();
            textBox14.Text = Global.Z.Home_mode.ToString();
            textBox15.Text = Global.Z.Home_offset.ToString();   //Z

            //AAA
            numericUpDown16.Value = Global.A.axis;
            numericUpDown17.Value = Convert.ToDecimal(Global.A.dEquiv);
            numericUpDown18.Value = Convert.ToDecimal(Global.A.dStartVel);
            numericUpDown19.Value = Convert.ToDecimal(Global.A.dTacc);
            numericUpDown20.Value = Convert.ToDecimal(Global.A.dTdec);  //A
            numericUpDown32.Value = Convert.ToDecimal(Global.A.dMaxVel);
            numericUpDown35.Value = Convert.ToDecimal(Global.A.dS_para);

            textBox16.Text = Global.A.Home_LVel.ToString();
            textBox17.Text = Global.A.Home_HVel.ToString();
            textBox18.Text = Global.A.Home_time.ToString();
            textBox19.Text = Global.A.Home_mode.ToString();
            textBox20.Text = Global.A.Home_offset.ToString();   //A
           


            //BBBB
            numericUpDown21.Value = Convert.ToDecimal(Global.B.axis);
            numericUpDown22.Value = Convert.ToDecimal(Global.B.dEquiv);
            numericUpDown23.Value = Convert.ToDecimal(Global.B.dStartVel);
            numericUpDown24.Value = Convert.ToDecimal(Global.B.dTacc);
            numericUpDown25.Value = Convert.ToDecimal(Global.B.dTdec);  //B
            numericUpDown33.Value = Convert.ToDecimal(Global.B.dMaxVel);
            numericUpDown34.Value = Convert.ToDecimal(Global.B.dS_para);


            textBox21.Text = Global.B.Home_LVel.ToString();
            textBox22.Text = Global.B.Home_HVel.ToString();
            textBox23.Text = Global.B.Home_time.ToString();
            textBox24.Text = Global.B.Home_mode.ToString();
            textBox25.Text = Global.B.Home_offset.ToString();   //B


        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void save_Cal_button_Click(object sender, EventArgs e)
        {
            try
            {
                parame();
                Global.X.write();
                Global.Y.write();
                Global.Z.write();
                Global.A.write();
                Global.B.write();
                SavePump();

                WritePumpA();
                saveIO_name();

                if (Global.Ccard1.exies)
                {
                    Global.X.setORG();
                    Global.Y.setORG();
                    Global.Z.setORG();
                    Global.A.setORG();
                    Global.B.setORG();
                }
              
             
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

         
        }

        private void Open_Cal_Button_Click(object sender, EventArgs e)
        {
            Global.X.read();
            Global.Y.read();
            Global.Z.read();
            Global.A.read();
            Global.B.read();
            write();
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {

        } 
        private void saveIO_name()
        {
            Data.RWcofing cf = new Data.RWcofing(Global.IO_text,"input");
            cf.writeini("0", textBox35.Text);
            cf.writeini("1", textBox36.Text);
            cf.writeini("2", textBox37.Text);
            cf.writeini("3", textBox38.Text);
            cf.writeini("4", textBox39.Text);
            cf.writeini("5", textBox40.Text);
            cf.writeini("6", textBox41.Text);
            cf.writeini("7", textBox42.Text);
            cf.group = "output";
            cf.writeini("0", textBox27.Text);
            cf.writeini("1", textBox28.Text);
            cf.writeini("2", textBox29.Text);
            cf.writeini("3", textBox30.Text);
            cf.writeini("4", textBox31.Text);
            cf.writeini("5", textBox32.Text);
            cf.writeini("6", textBox33.Text);
            cf.writeini("7", textBox34.Text);


        
        }
        private void readIO_name()
        {
            //mypruject.data.Cofing cf = new data.Cofing(Global.IO_text, "input");
            Data.RWcofing cf = new Data.RWcofing(Global.IO_text, "input");
            textBox35.Text = cf.readini("0");
            textBox36.Text = cf.readini("1");
            textBox37.Text = cf.readini("2");
            textBox38.Text = cf.readini("3");
            textBox39.Text = cf.readini("4");
            textBox40.Text = cf.readini("5");
            textBox41.Text = cf.readini("6");
            textBox42.Text = cf.readini("7");
            cf.group = "output";
            textBox27.Text = cf.readini("0");
            textBox28.Text = cf.readini("1");
            textBox29.Text = cf.readini("2");
            textBox30.Text = cf.readini("3");
            textBox31.Text = cf.readini("4");
            textBox32.Text = cf.readini("5");
            textBox33.Text = cf.readini("6");
            textBox34.Text = cf.readini("7");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "CW";
            }
            else
            {
                checkBox1.Text = "CCW";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox3.Text = "CW";
            }
            else
            {
                checkBox3.Text = "CCW";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox5.Text = "CW";
            }
            else
            {
                checkBox5.Text = "CCW";
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = false;
        }



        private void SavePump()
        {
            Global.pubpType = comboBox1.Text;
            Global.A_pumpDensity = Convert.ToDouble(numericUpDown36.Value);
            Global.A_equivalent = Convert.ToDouble(numericUpDown37.Value);
            Global.A_ratio  = Convert.ToDouble(numericUpDown40.Value);

            Global.B_pumpDensity = Convert.ToDouble(numericUpDown38.Value);
            Global.B_equivalent = Convert.ToDouble(numericUpDown39.Value);
            Global.B_ratio = Convert.ToDouble(numericUpDown41.Value);
         


            
}




        public  void ReadPump()
        {

            try
            {
                comboBox1.Text = RWcofing.readini("PumpType");

                numericUpDown36.Value = Convert.ToDecimal(RWcofing.readini("A_pumpDensity"));
                numericUpDown37.Value = Convert.ToDecimal(RWcofing.readini("A_equivalent"));
                numericUpDown38.Value = Convert.ToDecimal(RWcofing.readini("B_pumpDensity"));
                numericUpDown39.Value = Convert.ToDecimal(RWcofing.readini("B_equivalent"));
                numericUpDown40.Value = Convert.ToDecimal(RWcofing.readini("A_ratio"));
                numericUpDown41.Value = Convert.ToDecimal(RWcofing.readini("B_ratio"));



            }
            catch (Exception ex)
            {

            }
        }

        public void ReadPumpA()
        {
            Global.Pumpdata.Read();
            numericUpDown60.Value = (decimal)Global.Pumpdata.MaxStrke;
            numericUpDown61.Value = (decimal)Global.Pumpdata.Pitch;
            numericUpDown62.Value = (decimal)Global.Pumpdata.Reduction_ratio;
            numericUpDown63.Value = (decimal)Global.Pumpdata.Density;
            numericUpDown64.Value = (decimal)Global.Pumpdata.Radius;
             
            //    // Properties.Settings.Default.
            //numericUpDown60.Value = PumpFile.Default.A0;
            //numericUpDown61.Value = PumpFile.Default.A1;
            //numericUpDown62.Value = PumpFile.Default.A2;
            //numericUpDown63.Value = PumpFile.Default.A3;
            //numericUpDown64.Value = PumpFile.Default.A4;
            //comboBox1.Text = PumpFile.Default.PubpType;
        }

        public void   WritePumpA()
        {
            //settings.A_FullStroke = numericUpDown60.Value;
            //settings.A_Pitch = numericUpDown61.Value;
            //settings.A_Reduction = numericUpDown62.Value;
            //settings.A_density = numericUpDown63.Value;
           Global.Pumpdata.MaxStrke = (double)numericUpDown60.Value;
           Global.Pumpdata.Pitch = (double)numericUpDown61.Value;
           Global.Pumpdata.Reduction_ratio = (double)numericUpDown62.Value;
           Global.Pumpdata.Density = (double)numericUpDown63.Value;
           Global.Pumpdata.Radius = (double)numericUpDown64.Value;
            Global.Pumpdata.Write();
           
             //PumpFile.Default.A1 = numericUpDown61.Value;
             //PumpFile.Default.A2 = numericUpDown62.Value;
             //PumpFile.Default.A3 = numericUpDown63.Value;
             //PumpFile.Default.A4 = numericUpDown64.Value;
             //PumpFile.Default.PubpType = comboBox1.Text;
             //PumpFile.Default.Save();
        }






    }
}
