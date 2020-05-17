using LuoGuoFeng.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoGuoFeng
{
    class Control_Card : Axis
    {
        public ushort CarNum;   //卡号
        ushort crd = 0;   //轴系
        public int CarErrCode = 0;  //卡错误代码

        public bool exies = false;


        #region  构造函数

        public Control_Card()
        {

        }
        #endregion

        //1.板卡设置功能--
        #region  //检查控制卡数量      返回卡号
        public bool CarInitial()         //检查控制卡数量      返回卡号
        {
            int carNub = 0;

            try
            {
                short num = LTDMC.dmc_board_init();//获取卡数量
                if (num <= 0 || num > 8)
                {
                    //MessageBox.Show("初始卡失败!", "出错");
                    CarErrCode = 1;
                    return false;
                }
                ushort _num = 0;
                ushort[] cardids = new ushort[8];
                uint[] cardtypes = new uint[8];
                short res = LTDMC.dmc_get_CardInfList(ref _num, cardtypes, cardids);
                if (res != 0)
                {
                    CarErrCode = 2;
                    // MessageBox.Show("获取卡信息失败!");
                    return false;
                }
                CarNum = cardids[0];
                return true;
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message);
                CarErrCode = 3;
                return false;
            }
        }
        #endregion

        #region 清除卡报警

        public ushort GetErrorCode()
        {
            ushort errcode = 0;
            LTDMC.nmc_get_errcode(CarNum, 2, ref errcode);
            return errcode;
        }


        public bool   resetCar()     // 重启运动控制卡      报警
        {

            LTDMC.dmc_soft_reset(CarNum);
            LTDMC.dmc_board_reset();
            LTDMC.dmc_board_close();

            for (int i = 0; i < 15; i++)//总线卡软件复位耗时15s左右
            {
                Thread.Sleep(1000);
                Global.frmMain.PushMess(i+"/15....");
            }
              var a =   LTDMC.dmc_board_init();
              Global.frmMain.PushMess("Card Number: "+a + "");
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            // Axis.nmc_get_errcode(MyGlobal._CarId, 2, ref errcode);
            //  mess_textBox.AppendText("总线卡软件复位完成,请确认总线状态" + errcode.ToString());
        }
        #endregion

        //2.插补运动驱动--
        #region 插补
        public void Linear_interpolation(ushort AxisNum, ushort[] AxisList, double[] target, ushort posi_mode, double minV, double maxV, double Tacc, double Tdec, double stop)
        {

            LTDMC.dmc_set_vector_profile_unit(CarNum, crd, minV, maxV, Tacc, Tdec, stop);
            //1 执行
            LTDMC.dmc_line_unit(CarNum, crd, AxisNum, AxisList, target, posi_mode);
        }
        public void dmc_line_unit(Global.Cdefault l_data)
        {
            LTDMC.dmc_line_unit(CarNum, 0, 3, new ushort[] { 0, 1, 2 }, l_data.Aposition, 1);
        }

        public void Vector(Global.Cdefault l_data)
        {
            LTDMC.dmc_set_vector_profile_unit(CarNum, 0, 10, l_data.vel, l_data.Ade, l_data.Ade, 0);
        }

        public short dmc_arc_move_3points_unit(ushort AxisNum, double[] target, double[] mid)
        {
            return LTDMC.dmc_arc_move_3points_unit(CarNum, 0, AxisNum, new ushort[] { Global.X.axis, Global.Y.axis, Global.Z.axis }, target, mid, 1, 1);
        }
        #endregion


        #region 三点圆弧插补
        public void Circular_interpolation(ushort AxisNum, ushort[] AxisList, double[] target_pos, double[] Mid_pos, ushort posi_mode, double minV, double maxV, double Tacc, double Tdec, double stop)
        {

            int cricle = -1;//设置空间圆弧，圆弧圈数为0

            LTDMC.dmc_set_vector_profile_unit(CarNum, crd, minV, maxV, Tacc, Tdec, stop);

            LTDMC.dmc_arc_move_3points_unit(CarNum, crd, AxisNum, AxisList, target_pos, Mid_pos, cricle, posi_mode);

        }

        //public void Vector (Global.Cdefault l_data)
        //{

        //    LTDMC.dmc_set_vector_profile_unit(CarNum, 0, 10, l_data.vel, l_data.Ade, l_data.Ade, 0);

        //}

        //public void dmc_line_unit(Global.Cdefault l_data)
        //{
        //    LTDMC.dmc_line_unit(CarNum, 0, 3, new ushort[] { 0, 1, 2 }, l_data.Bposition, 1);
        //}

        public short dmc_check_done_multicoor()
        {
            return LTDMC.dmc_check_done_multicoor(CarNum, 0);
        }




        //public short dmc_arc_move_3points_unit(ushort AxisNum,double[] target ,double[] mid)
        //{
        //    return LTDMC.dmc_arc_move_3points_unit(CarNum, 0, AxisNum, new ushort[] { Global.X.axis, Global.Y.axis, Global.Z.axis }, target, mid, 1, 1);
        //}


        #endregion


        //3.运动控制卡的IO 操作--
        #region 输入
        public void InputerMethod(ref ushort[] bitno)
        {
            for (ushort i = 0; i < 8; i++)              //检查IO输出
            {
                if (LTDMC.dmc_read_inbit(CarNum, i) == 0)
                {
                    bitno[i] = 1;
                }
                else
                {
                    bitno[i] = 0;
                }
            }
            // bitno;
        }
        #endregion

        #region 输出
        public short OutPuter(ushort bitno, ushort on_off)           //1.那个位上  2.哪个字节上
        {
            if (on_off == 0)
            {
                on_off = 1;
            }
            else
            {
                on_off = 0;
            }
            var res = LTDMC.dmc_write_outbit(CarNum, bitno, on_off);    //输出电平
            return res;
        }

        #endregion
        //4.EnterCAT 总线操作函数








        //end 
    }



    public class MotionHelper
    {

        private static object obj = 1;

        #region Interpolation motion 插补运动
       static Task ts = null;
        public static void MotionFun(object ot)
        {
            double X_position;
            double Y_position;
            double Z_position;
            double Vel;
            double ade;
            Global.Cdefault pa = ot as Global.Cdefault;
            int Tsetup = pa.setup;
            string[,] data = pa.table;
        
            Global.Cdefault data1 = new Global.Cdefault();
            Global.Cdefault line_data = new Global.Cdefault();
            Global.Cdefault Arc_data = new Global.Cdefault();
            try
            {
            switch (data[Tsetup, 1])// 读取指定轴状态机
            {
                case "Disabled":

                    break;
                case "Point":

                    X_position = Convert.ToDouble(data[Tsetup, 2]);
                    Y_position = Convert.ToDouble(data[Tsetup, 3]);
                    Z_position = Convert.ToDouble(data[Tsetup, 4]);
                    Vel = Convert.ToDouble(data[Tsetup, 5]);
                    ade = Convert.ToDouble(data[Tsetup, 6]);
                    data1.Aposition = new double[3];
                    data1.Aposition[0] = X_position;
                    data1.Aposition[1] = Y_position;
                    data1.Aposition[2] = Z_position;
                    data1.vel = Vel;
                    data1.Ade = ade;
                 //   mess_textBox.AppendText(DateTime.Now.ToString("HH:mm:ss :") + "Call MotionStartpoint" + "\n");
                    Task task = Task.Run(() => { 
                    
                      MovePoint(data1);
                    });
                    task.Wait();
                    break;
                case "Wait":

                    int dela = Convert.ToInt16(data[Tsetup, 9]);
               //     mess_textBox.AppendText(DateTime.Now.ToString("HH:mm:ss :") + "Call Delay" + "\n");
                    Thread.Sleep(dela);
                    break;
                case "Line":
                    X_position = Convert.ToDouble(data[Tsetup, 2]);
                    Y_position = Convert.ToDouble(data[Tsetup, 3]);
                    Z_position = Convert.ToDouble(data[Tsetup, 4]);
                    Vel = Convert.ToDouble(data[Tsetup, 5]);
                    ade = Convert.ToDouble(data[Tsetup, 6]);
                    line_data.Aposition = new double[3] { X_position, Y_position, Z_position };
                    line_data.vel = Vel;
                    line_data.Ade = ade;
               // mess_textBox.AppendText(DateTime.Now.ToString("HH:mm:ss :") + "Call LineMotion" + "\n");
                     Task task1 = Task.Run(() => { 
                    line(line_data);
                    });
                    task1.Wait();
                    

                    break;
                case "Arc_Mid":
                    X_position = Convert.ToDouble(data[Tsetup, 2]);
                    Y_position = Convert.ToDouble(data[Tsetup, 3]);
                    Z_position = Convert.ToDouble(data[Tsetup, 4]);
                    Vel = Convert.ToDouble(data[Tsetup, 5]);
                    ade = Convert.ToDouble(data[Tsetup, 6]);
                    Arc_data.Aposition = new double[3] { X_position, Y_position, Z_position };
                    Arc_data.vel = Vel;
                    Arc_data.Ade = ade;
                    double X_mid_position = Convert.ToDouble(data[Tsetup + 1, 2]);
                    double Y_mid_position = Convert.ToDouble(data[Tsetup + 1, 3]);
                    double Z_mid_position = Convert.ToDouble(data[Tsetup + 1, 4]);
                  //  mess_textBox.AppendText(DateTime.Now.ToString("HH:mm:ss :") + "Call ArcMotion" + "\n");
                    Arc_data.Bposition = new double[3] { X_mid_position, Y_mid_position, Z_mid_position };
                    //ActionThread = new Thread(new ParameterizedThreadStart(Arc));
                    //ActionThread.Start(a);
                    //ActionThread.Join();
                   
                       Arc(Arc_data);

                 
                    break;
                case "Dipensing":
                        if (!pa.tryRun)      //不带料模式
                        {

                            double Q = Convert.ToDouble(data[Tsetup, 7]);
                            double time = Convert.ToDouble(data[Tsetup, 8]);
                            Global.Pumpdata.Calculation(Q, time);
                            if (ts != null)
                            {
                                if (Global.Pumpdata.IsReset)
                                {
                                    ReDispensing();
                                    ts = Task.Run(() =>
                                    {
                                        Dispensing(Global.Pumpdata);
                                    });
                                }
                                if (!ts.IsCompleted)
                                {
                                    ts.Wait();
                                }
                            }
                            ts = Task.Run(() =>
                            {
                                Dispensing(Global.Pumpdata);
                            });
                        }
                        break;
                    case "Dipensed":
                        if (!pa.tryRun)
                        {
                            if (ts != null)
                            {
                                ts.Wait();
                            }
                        }
                        break;
                    case "ReDispensing":
                        if (!pa.tryRun)
                        {
                            if (!ts.IsCompleted)
                            {
                                ts.Wait();
                            }
                            ts = Task.Run(() =>
                            {
                                ReDispensing();
                            });
                        }
                        break;
                default:
                    break;
            };
            }
            catch (Exception ex)
            {
                Global.frmMain.PushMess(ex.ToString());
              
            }
        }

        private static void MovePoint(object a)    //public static void XY_move(double x_p,double y_p,double z_p, double Vel,double AccDec)
        {
            int xy_code = 0;
            //创建传参 拆包
            Global.Cdefault data = a as Global.Cdefault;
      
            Global.Z.dMaxVel = data.vel;
            Global.X.dMaxVel = data.vel;
            Global.Y.dMaxVel = data.vel;

          
                  Global.Z.Pmove(0, data.vel, data.Ade, 1);
            Global.Z.ORG();
     //       Thread.Sleep(0);
            while (Global.Z.IsRun)                //检测完成
            {
                // Thread.Sleep(1000);
                 Application.DoEvents();
            }
            while (Global.X.IsRun | Global.Y.IsRun)                //检测完成
            {
                //  Thread.Sleep(1000);
                 Application.DoEvents();
            }
            //double[] target = { data.x_position, data.y_position, data.z_position };      // 拆出位置
         
                Global.X.Pmove(data.Aposition[0], data.vel, data.Ade, 1);                                //发命令
                Global.Y.Pmove(data.Aposition[1], data.vel, data.Ade, 1);
          

            Thread.Sleep(1);
            while (Global.X.IsRun | Global.Y.IsRun)                //检测完成
            {
                //  Thread.Sleep(1000);
                 Application.DoEvents();
            }
         
                 Global.Z.Pmove(data.Aposition[2], data.vel, data.Ade, 1);
        
            Thread.Sleep(1);
            while (Global.Z.IsRun)
            {
                //  Thread.Sleep(1000);
                // Application.DoEvents();
            }

        }

        private static void  line(object a1)    //public static void XY_move(double x_p,double y_p,double z_p, double Vel,double AccDec)
        {
          
            int i = 0;
            Global.Cdefault l_data = a1 as Global.Cdefault;
            l_data.Aposition[0] = l_data.Aposition[0] * Global.X.dEquiv;
            l_data.Aposition[1] = l_data.Aposition[1] * Global.Y.dEquiv;
            l_data.Aposition[2] = l_data.Aposition[2] * Global.Z.dEquiv;

            Global.Ccard1.Vector(l_data);
            var res = Global.Ccard1.dmc_check_done_multicoor();
            while (res != 1 ) //stop :1   run : 0
            {
                res = Global.Ccard1.dmc_check_done_multicoor();
                i++;
             //   textBox1.Text = "直线运动前检测" + i;
                Application.DoEvents();
            }
            Global.Ccard1.dmc_line_unit(l_data);
            Thread.Sleep(0);
         
            var res1 = Global.Ccard1.dmc_check_done_multicoor();
            while (res1 != 1)
            {
                i++;
                 res1 = Global.Ccard1.dmc_check_done_multicoor();
                Application.DoEvents();
            }

        }

        private static void Arc(object a)    //public static void XY_move(double x_p,double y_p,double z_p, double Vel,double AccDec)
        {
            short Arc_co = 0;
            int i = 0;
            Global.Cdefault data = a as Global.Cdefault;


            double[] mid = { data.Aposition[0] * Global.X.dEquiv, data.Aposition[1] * Global.Y.dEquiv, data.Aposition[2] * Global.Z.dEquiv };
            double[] target = { data.Bposition[0] * Global.X.dEquiv, data.Bposition[1] * Global.Y.dEquiv, data.Bposition[2] * Global.Y.dEquiv }; ;
            ushort AxisNum = 3;
            int cricle = -1;        //圈数：
             #region
            //    负数：表示此时执行的为空间圆弧插补
            //    该值的绝对减 1表示空间圆弧的圈数。如， 表示空间圆弧的圈数。如， -1即表示 0圈 空间圆弧， -2即表示 1圈空间圆弧…
            //    自然数：表示此时执行的为圆柱螺旋线插补
            //    该值表示螺旋线的圈数。如， 0即表示 0圈螺旋线插补， 1即表示 1圈螺旋线插补…
            //    posi_mode 运动模式， 0：
            //相对坐标模式， 1：
            #endregion
            while (LTDMC.dmc_check_done_multicoor(Global.Ccard1.CarNum, 0) == 0)
            {
                i++;
                Application.DoEvents();
            }
            //卡号                  轴数         轴号                              目标位置，  圈数     模式0：相对 1：绝对
            Arc_co = LTDMC.dmc_arc_move_3points_unit(Global.Ccard1.CarNum, 0, AxisNum, new ushort[] { Global.X.axis, Global.Y.axis, Global.Z.axis }, target, mid, cricle, 1);
            i = 0;
            Thread.Sleep(1);
            while (LTDMC.dmc_check_done_multicoor(Global.Ccard1.CarNum, 0) == 0)
            {
                i++;
                Application.DoEvents();
            }

        }
        #endregion


        #region Pump Funtion
        /// <summary>
        ///   单阀气缸函数
        /// </summary>
        /// <param name="outBit">输出位</param>
        /// <param name="inbit">输入感应器 -1 不使用</param>
        /// <param name="stutas">FD or BD</param>
        /// <returns></returns>
        public static bool cylinder(ushort outBit, short inbit, ushort stutas)
        {
            ushort[] bitno = new ushort[8];
            int timeOut = 0;

            var res = Global.Ccard1.OutPuter(outBit, stutas);

            if (inbit == -1)
            {
                Thread.Sleep(100);
                return true;
            }
            while (bitno[inbit] == 1 | timeOut >= 5000)
            {
                Global.Ccard1.InputerMethod(ref bitno);
                Thread.Sleep(10);
                timeOut++;
            }
            if (timeOut >= 5000)
            {
                return false;
            }
            return true;
        }


        public static bool Dispensing(PumpData pumpData )
        {
                      
         
            //1.关入胶阀
            var res = cylinder(0, -1, 0);
            if (!res)
            {
                return false;
            }
            var res1 = cylinder(2, -1, 0);
            if (!res1)
            {
                return false;
            }

            //2.开出胶阀
            var res2 = cylinder(1, 0, 1);
            if (!res2)
            {
                return false;
            }

            var res3 = cylinder(3, 1, 1);
            if (!res3)
            {
                return false;
            }

            Thread.Sleep(100);
            // 3.出胶
            var M =  pumpData.Out_M;
            var speed =  pumpData.Speed;
            var time = pumpData.Time;
            PumpMotion(M, speed,time);


            //关出胶阀
            var res4 = cylinder(1, -1, 0);
            if (!res4)
            {
                return false;
            }

            var res5 = cylinder(3, -1, 0);
            if (!res5)
            {
                return false;
            }





            return true;

        } 
        public static bool Dispensing(double time)
        {
            //1.开出胶阀
            var res2 = cylinder(1, 0, 1);
            if (!res2)
            {
                return false;
            }

            var res3 = cylinder(3, 1, 1);
            if (!res3)
            {
                return false;
            }

         //   Thread.Sleep(100);

            // 2.出胶
            Global.A.Vmove(1,1000,0);
            int tim = (int)(time * 1000);
            Thread.Sleep(tim);
            Global.A.Pstop();

            //关出胶阀
            var res4 = cylinder(1, -1, 0);
            if (!res4)
            {
                return false;
            }

            var res5 = cylinder(3, -1, 0);
            if (!res5)
            {
                return false;
            }





            return true;

        }
        public static bool ReDispensing()
        {

            #region  1.关出胶胶阀
            var res4 = cylinder(1, -1, 0);
            if (!res4)
            {
                return false;
            }

            var res5 = cylinder(3, -1, 0);
            if (!res5)
            {
                return false;
            }
            #endregion

            #region 2. open入胶阀
            var res = cylinder(0, -1, 1);
            if (!res)
            {
                return false;
            }
            var res1 = cylinder(2, -1, 1);
            if (!res1)
            {
                return false;
            }
            #endregion

            #region 3.伺服回零

            Global.A.Pmove(0,5000,0.1,1);
            while (Global.A.IsRun)
                Thread.Sleep(1);


            #endregion

            #region 4.压力检测

            #endregion

            #region delay
            Thread.Sleep(1);
            #endregion

            #region 压力和合格后
            #endregion

            #region 7.关入胶阀
            var res9 = cylinder(0, -1, 0);
            if (!res9)
            {
                return false;
            }
            var res7 = cylinder(2, -1, 0);
            if (!res7)
            {
                return false;
            }
            #endregion

            #region  8.伺服反转启用
            if (PumpFile.Default.CCW)
            {
                 Global.A.Pmove(-0.1, 5000, 0.1, 1);
                 while (Global.A.IsRun)
                        Thread.Sleep(1); 
            }
        
            #endregion

            #region 9.给出完成信号
            #endregion


            return true;
        }
        public static bool PumpMotion(double M, double speed,double time)
        {
            try
            {
                int TimeNum = 0;
                int TimeOut = (int)(time * 2000);
                Global.A.Dir = 1;
                Global.A.Pmove(M, speed, speed, 0);
                while (Global.A.IsRun | TimeNum >= TimeOut)
                {
                    Thread.Sleep(1);
                    TimeNum++;
                }
                if (TimeNum >= TimeOut)
                {
                    
                    Global.frmMain.PushMess("Dipensing time out.");
                    return false;
                }
                 
                return true;
            }
            catch (Exception ex)
            {

                //throw;
                return false;
            }
        } 
        public static bool PumpMotionA(double quality, double time)
        {
            try
            {
                int TimeNum = 0;
                int TimeOut = (int)(time * 2000);
                double V = quality / (double)PumpFile.Default.A3;

                double H = V / ((double)PumpFile.Default.A4 * (double)PumpFile.Default.A4 * 3.14);

                double M = H * (double)PumpFile.Default.A2 * (double)PumpFile.Default.A1;

                // double Tdist = M;
                double speed = M / time;
                Global.A.Pmove(M, speed, speed, 1);
                while (Global.A.IsRun | TimeNum >= TimeOut)
                {
                    Thread.Sleep(1);
                    TimeNum++;
                }
                if (TimeNum >= TimeOut)
                    return false;
                return true;
            }
            catch (Exception ex)
            {

                //throw;
                return false;
            }
        }
        #endregion

        #region Reset Funtiom
        public static void Reset()
        {
            lock (obj)
            {
                try
                {
                    var re = Global.Ccard1.resetCar();
                    Thread.Sleep(200);
                    if (re)
                    {

                        Global.X.read();
                        Global.Y.read();
                        Global.Z.read();
                        Global.A.read();
                        Global.B.read();
                        Global.X.Enable();
                        Global.Y.Enable();
                        Global.Z.Enable();
                        Global.A.Enable();
                        Global.B.Enable();
                        Thread.Sleep(200);
                        Global.Z.ORG();
                        //       Thread.Sleep(0);
                        while (Global.Z.IsRun)                //检测完成
                        {
                            // Thread.Sleep(1000);
                            Application.DoEvents();
                        }
                        Global.X.ORG();
                        Global.Y.ORG();

                        while (Global.X.IsRun | Global.Y.IsRun)                //检测完成
                        {
                            //  Thread.Sleep(1000);
                            Application.DoEvents();
                        }
                        Global.frmMain.PushMess("initial Card Success");
                    }
                    else
                    {
                        Global.frmMain.PushMess("initial Card UnSuccess");
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        #endregion

        #region Caliration Funtion
        public static void Caliration(object e)
        {
            var a = e as C_Pmove;
            
        }

        #endregion



    }


    #region C_PMove
    class C_Pmove
    {
        Axis axis;
        Button bt;
        ushort dir = 0;
        public Axis TAxis
        {
            get { return axis; }
            set { axis = value; }
        }
        public Button Bt
        {
            get { return bt; }
            set { bt = value; }
        }
        public ushort Dir
        {
            get { return dir; }
            set { dir = value; }
        }
    }
       #endregion



}
