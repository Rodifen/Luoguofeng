using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LuoGuoFeng
{
    class Axis
    {


        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public Axis()
        {

        }

        //静态变量
        public static ushort _CardID;
        public static ushort crd = 0; 

        public string fpath;   // 文件保存路径

        public ushort axis = 0;               //轴号
        public double dEquiv;                //脉冲当量
        public double dStartVel;           //起始速度
        public double dMaxVel;            //运行速度
        public double dTacc;               //加速时间
        public double dTdec;               //减速时间
        public double dStopVel;          //停止速度
        public double dS_para;            //S段时间
        public double dDist;               //目标位置
        public ushort sPosi_mode;    //运动模式0：相对坐标模式，1：绝对坐标模式
        public ushort stop_mode = 0; //制动方式，0：减速停止，1：紧急停止
        public ushort Dir;                    //方向


        //回零参数
        public ushort Home_mode;   //回零模式
        public double Home_LVel;   //回零低速
        public double Home_HVel;   //回零高速
        public double Home_time;   //回零加减速时间
        public double Home_offset; //回零偏移量



        //后台检测 IO SING  轴状态
        private struct Axis_status
        {
            double position;
            bool IsRun;

        };   //轴状态


        double position = 0;
        bool Run = false;

        public double Position
        {
           
            get {
                GetPosition();
                return position; }
        }

        public bool IsRun
        {
            get
            {
                Check_done();
                return Run;
            }
        }

        //构造函数
        public Axis(ushort theaxis, string Tfpath)
        {
            fpath = Tfpath;
            axis = theaxis;
        }

        //构造函数
        /// <summary>
        /// 
        /// </summary>
        /// <param name="car_num">卡号</param>
        /// <param name="axis">轴号</param>
        /// <param name="deq">脉冲当量</param>
        //public Axis(ushort car_num, ushort axis, double deq = 1000)
        //{


        //}
        //回原点运动
        public void setORG()
        {

            LTDMC.dmc_set_equiv(_CardID, axis, dEquiv);  //设置脉冲当量

            LTDMC.dmc_set_profile_unit(_CardID, axis, dStartVel, dMaxVel, dTacc, dTdec, dStopVel);//设置速度参数

            LTDMC.dmc_set_s_profile(_CardID, axis, 0, dS_para);//设置S段速度参数

            LTDMC.dmc_set_dec_stop_time(_CardID, axis, dTdec); //设置减速停止时间
            //配置回零参数
            short returnvalue = LTDMC.nmc_set_home_profile(_CardID, axis, Home_mode,
                                                Home_HVel, Home_LVel, Home_time, Home_time, Home_offset);
        }
        public void ORG()
        {
            LTDMC.nmc_home_move(_CardID, axis);//启动回零  
        }
        public void StopORG()
        {
            LTDMC.dmc_stop(_CardID, axis, 1);
        }

        //JOG  运功  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TdDist"></param>
        /// <param name="speed">Run speed</param>
        /// <param name="TsPosi_mode">0：相对坐标模式，1：绝对坐标模式</param>
        public void Pmove(double TdDist, double speed, double dec, ushort TsPosi_mode)
       
        {
            int code = 0;
            dMaxVel = dStartVel = speed;
            dTacc = dTdec = dec;
            TdDist *= dEquiv;
            dStopVel = 0;
            if (Dir == 0)
                TdDist = -TdDist;
            LTDMC.nmc_set_axis_run_mode(_CardID, axis, 8);
            LTDMC.dmc_set_profile_unit(_CardID, axis, speed, speed, dTacc, dTdec, dStopVel);//设置速度参数

            LTDMC.dmc_set_s_profile(_CardID, axis, 0, dS_para);//设置S段速度参数

            LTDMC.dmc_set_dec_stop_time(_CardID, axis, dTdec); //设置减速停止时间

            code = LTDMC.dmc_pmove_unit(_CardID, axis, TdDist, TsPosi_mode);//定长运动
        }

        public void Vmove(ushort sDir, double speed, ushort TsPosi_mode)
        {
            dStopVel = speed;

            if (Dir == 1)
            {
                if (sDir == 0)
                {
                    sDir = 1;
                }
                else
                {
                    sDir = 0;
                }
            }

            LTDMC.dmc_set_profile_unit(_CardID, axis, dStartVel, dStopVel, dTacc, dTdec, dStopVel);//设置速度参数

            LTDMC.dmc_set_dec_stop_time(_CardID, axis, dTdec); //设置减速停止时间

            LTDMC.dmc_vmove(_CardID, axis, sDir);//连续运动
        }





        //停止运动
        public void Pstop()
        {
            LTDMC.dmc_stop(_CardID, axis, stop_mode);
        }

        //清除当前位置
        public void closePosition()
        {
            LTDMC.dmc_set_position_unit(_CardID, axis, 0); //设置指定轴的当前指令位置值
        }

        //使能
        public void Enable()
        {
            LTDMC.nmc_set_axis_enable(_CardID, axis);// 使能对应轴
        }
        public void disEnable()
        {
            LTDMC.nmc_set_axis_disable(_CardID, axis);// 失能对应轴
        }

        //获取当前位置
        public double GetPosition()
        {
            double dunitPos = 0;
            //LTDMC.dmc_get_position_unit(_CardID, axis, ref dunitPos); //读取指定轴指令位置值

            LTDMC.dmc_get_encoder_unit(_CardID, axis, ref dunitPos);
            // position = dunitPos;

            return position = dunitPos / dEquiv;
            // return dunitPos ;
        }

        public bool Check_done()
        {
            short run;
            //
            run = LTDMC.dmc_check_done(_CardID, axis);
            
          return  Run = run == 1 ? false : true;
        }

        public ushort Check_Enable()
        {
            ushort Axis_State_machine = 0;
            LTDMC.nmc_get_axis_state_machine(_CardID, axis, ref Axis_State_machine);
            return Axis_State_machine;
        }

        public ushort GetAxisStatus()
        {
            ushort Axis_State_machine2 = 0;
            LTDMC.nmc_get_axis_state_machine(_CardID, 2, ref Axis_State_machine2);
            return Axis_State_machine2;
        }
             
        //获取对应感应器信号
        public void Getsing(ref bool[] sing)
        {
            uint IoState = LTDMC.dmc_axis_io_status(_CardID, axis);
            if ((IoState & 2) == 2)//检测正限位信号
            {
                sing[0] = true;
            }
            else
            {
                sing[0] = false;
            }
            if ((IoState & 4) == 4)//检测负限位信号
            {
                sing[1] = true;
            }
            else
            {
                sing[1] = false;
            }
            if ((IoState & 16) == 16)//检测原点信号
            {
                sing[2] = true;
            }
            else
            {
                sing[2] = false;
            }
        }
        public uint Getsing()
        {
            return LTDMC.dmc_axis_io_status(_CardID, axis);
        }

        // 读参数
        public void read()
        {
            try
            {
                //_CardID = 0;
                axis = Convert.ToUInt16(readini("axis"));             //轴号
                dEquiv = Convert.ToDouble(readini("dEquiv"));           //脉冲当量
                dStartVel = Convert.ToDouble(readini("dStartVel"));           //起始速度
                dMaxVel = Convert.ToDouble(readini("dMaxVel"));             //运行速度
                dTacc = Convert.ToDouble(readini("dTacc"));               //加速时间
                dTdec = Convert.ToDouble(readini("dTdec"));           //减速时间
                dStopVel = Convert.ToDouble(readini("dStopVel"));        //停止速度
                dS_para = Convert.ToDouble(readini("dS_para"));        //S段时间
                dDist = Convert.ToDouble(readini("dDist"));          //目标位置
                sPosi_mode = Convert.ToUInt16(readini("sPosi_mode")); //运动模式0：相对坐标模式，1：绝对坐标模式
                stop_mode = Convert.ToUInt16(readini("stop_mode")); //制动方式，0：减速停止，1：紧急停止
                Dir = Convert.ToUInt16(readini("Dir"));

                //回零参数
                Home_mode = Convert.ToUInt16(readini("Home_mode"));   //回零模式
                Home_LVel = Convert.ToDouble(readini("Home_LVel"));   //回零低速
                Home_HVel = Convert.ToDouble(readini("Home_HVel"));   //回零高速
                Home_time = Convert.ToDouble(readini("Home_time"));   //回零加减速时间
                Home_offset = Convert.ToDouble(readini("Home_offset")); //回零偏移量
                setORG();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR"+ ex.Message);
                
            }
          
        }

  
        //写参数
        public void write()
        {
            writeini("axis", axis.ToString());
            writeini("dEquiv", dEquiv.ToString());
            writeini("dStartVel", dStartVel.ToString());
            writeini("dMaxVel ", dMaxVel.ToString());
            writeini("dTacc", dTacc.ToString());
            writeini("dTdec", dTdec.ToString());
            writeini("dStopVel", dStopVel.ToString());
            writeini("dS_para", dS_para.ToString());
            writeini("dDist", dDist.ToString());
            writeini("sPosi_mode", sPosi_mode.ToString());
            writeini("stop_mode", stop_mode.ToString());
            writeini("Dir", Dir.ToString());

            //回零参数
            writeini("Home_mode", Home_mode.ToString());
            writeini("Home_LVel", Home_LVel.ToString());
            writeini("Home_HVel", Home_HVel.ToString());
            writeini("Home_time", Home_time.ToString());
            writeini("Home_offset", Home_offset.ToString());

        }


        string file1 = Application.StartupPath + "\\axis.ini";
        /// <summary>
        /// 读取ini
        /// </summary>
        /// <param name="group">数据分组</param>
        /// <param name="key">关键字</param>
        /// <param name="filepath">init文件地址</param>
        /// <returns>关键字对应的值，没有时含有默认值</returns>
        public string readini(string key)
        {
           
            StringBuilder temp = new StringBuilder();
            

            GetPrivateProfileString(axis.ToString(), key, "", temp, 255, file1);
            return temp.ToString();
        }

        /// <summary>
        /// 存储ini
        /// </summary>
        /// <param name="group">数据分组</param>
        /// <param name="key">关键字</param>
        /// <param name="value">关键字对应的值</param>
        /// <param name="filepath">ini文件地址</param>
        public void writeini(string key, string value)
        {
         //   fpath = MyGlobal.AxisPar;
            WritePrivateProfileString(axis.ToString(), key, value, file1);
        }
    
    }
   

 }





