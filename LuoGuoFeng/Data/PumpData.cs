using HZH_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LuoGuoFeng.Data
{
    interface IPump
    {

    }
  public  class PumpData
    {

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        public PumpData(string Tfilepath)
        {
            filePath = Tfilepath;
        }




 //enum type
        //{
        //    // Volumetric piston dispensers – from low viscosity to high viscosity and abrasive，体积式活塞注胶头
        //    // Gear pump dispensers – for continuous dispensing 齿轮泵注胶头
        //}


        #region Variable

        /// <summary>
        ///  pumpTrpe
        /// </summary>
        string _type;

      /// <summary>
      /// 轴数
      /// </summary>
        private string _AxisNum;
        public string AxisNum
        {
            get { return _AxisNum; }
            set { _AxisNum = value; }
        }
        
       
        /// <summary>
        /// 减速比
        /// </summary>
        double reduction_ratio;

        /// <summary>
        /// 密度
        /// </summary>
        double density;

        /// <summary>
        /// 泵半径
        /// </summary>
        double radius;

        /// <summary>
        /// 最大行程
        /// </summary>
        double maxStrke = 0;

        /// <summary>
        /// 螺距
        /// </summary>
        double pitch = 0;

        #endregion

        double out_M = 0;
        double out_time = 0;
        double speed = 0;
        bool isReset = false;
        double time = 0;
        double curPos = 0;
  

        #region interface
        public double Reduction_ratio
        {
            get { return reduction_ratio; }
            set { reduction_ratio = value; }
        }
        public double Density
        {
            get { return density; }
            set { density = value; }
        }
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public double MaxStrke
        {
            get { return maxStrke; }
            set { maxStrke = value; }
        }
        public double Pitch
        {
            get { return pitch; }
            set { pitch = value; }
        }    
        public double Out_M
        {
            get { return out_M; }
            set { out_M = value; }
        }
        public bool IsReset
        {
            get {
           
                return isReset; }
            set { isReset = value; }
        }
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public double Time
        {
            get { return time; }
            set { time = value; }
        }
        public double CurPosion
        {
            get { return curPos; }
            set { curPos = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        #endregion


        string group = String.Empty;
        string filePath;
         
        public void Calculation(double quality, double Ttime,double TcurPos)
        {
            try
            {
                curPos = TcurPos;
                time = Ttime;
                //0
                double V = quality / density;

                double H = V / (radius * radius * 3.14);

                out_M = H * reduction_ratio * pitch;

                speed = (out_M / Ttime) * 1000;

                isReset = out_M + curPos >= maxStrke;

            }
            catch (Exception ex)
            {

                Global.frmMain.PushMess(ex.ToString());
                Global.frmMain.PushMess("pls check Pump Data parameter!");
            }
             
        }
        

      public  void Read()
        {

            reduction_ratio = readini("reduction_ratio").ToDouble();
            density = readini("density").ToDouble();
            radius = readini("radius").ToDouble();
            maxStrke = readini("maxStrke").ToDouble();
            pitch = readini("pitch").ToDouble();

     
        }

       public void Write()
        {
            writeini("Reduction_ratio", reduction_ratio.ToString());
            writeini("density", density.ToString());
            writeini("radius", radius.ToString());
            writeini("maxStrke", maxStrke.ToString());
            writeini("pitch", pitch.ToString());
        }



         string readini(string key)
        {
            StringBuilder temp = new StringBuilder();
            GetPrivateProfileString(group, key, "", temp, 255, filePath);
            return temp.ToString();
        }

        /// <summary>
        /// 存储ini
        /// </summary>
        /// <param name="group">数据分组</param>
        /// <param name="key">关键字</param>
        /// <param name="value">关键字对应的值</param>
        /// <param name="filepath">ini文件地址</param>
         void writeini(string key, string value)
        {
            WritePrivateProfileString(group, key, value, filePath);
        }


    }
}
