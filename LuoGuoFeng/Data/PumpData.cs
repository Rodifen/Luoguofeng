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
    class PumpData
    {

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);




        enum type
        {
            // Volumetric piston dispensers – from low viscosity to high viscosity and abrasive，体积式活塞注胶头
            // Gear pump dispensers – for continuous dispensing 齿轮泵注胶头
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
        double maxStrke  = 0;

        /// <summary>
        /// 螺距
        /// </summary>
        double pitch = 0;
      
        
        
        string group = String.Empty;
        string filePath;


        void Read()
        {

            reduction_ratio = readini("reduction_ratio").ToDouble();
            density = readini("density").ToDouble();
            radius = readini("radius").ToDouble();
            maxStrke = readini("maxStrke").ToDouble();
            pitch = readini("mitch").ToDouble();
        }

       void Write()
        {
            writeini("Reduction_ratio", reduction_ratio.ToString());
            writeini("density", density.ToString());
            writeini("radius", radius.ToString());
            writeini("maxStrke", maxStrke.ToString());
            writeini("pitch", pitch.ToString());
        }



        public string readini(string key)
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
        public void writeini(string key, string value)
        {
            WritePrivateProfileString(group, key, value, filePath);
        }


    }
}
