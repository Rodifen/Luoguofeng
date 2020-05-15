using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuoGuoFeng
{
    class Global
    {
        //public delegate void SendData(SendPara para);
        //public static SendData sendData;
        //public static SendData sendposition;
        public static Control_Card Ccard1 = new Control_Card();

        //
        public static Publisher publisher = new Publisher();
        public static Subscriber Sub1 = new Subscriber("1", publisher);
        public static FrmMain frmMain;

        public static List<Models> listModel = new List<Models>();
        public static Models NowModel = new Models();

        public static string BasePath = @"D:\MC019F";
        public static string AxisPar = BasePath + @"\" + "AxisPar.ini";
        public static Axis X = new Axis(0, AxisPar);
        public static Axis Y = new Axis(1, AxisPar);
        public static Axis Z = new Axis(2, AxisPar);

        public static Axis A = new Axis(3, AxisPar);
        public static Axis B = new Axis(4, AxisPar);

        public static string pubpType;
        public static double A_pumpDensity;
        public static double A_equivalent;

        public static double B_pumpDensity;
        public static double B_equivalent;
        public static double A_ratio;
        public static double B_ratio;


        public static string modelPath = "";   //型号参数路径
        public static string IO_text = BasePath + @"\" + "IO_text.ini";
        //public static string currModel;                                                                     //当前路径

           public class Cdefault
            {
                public double[] Aposition;
                public double[] Bposition;
                public double vel;
                public double Ade;
            //    public Button Bt;
                public int time;
                public int setup;
                public string[,] table;
            /// <summary>
            /// 不带料模式
            /// </summary>
                public bool tryRun;
            }
    }

    public class SendPara
    {
        public ushort[] inputdata { set; get; }
        public double db { get; set; }
        public double[] position { set; get; }
        public ushort CardStarus { set; get; }

    }


 

}
