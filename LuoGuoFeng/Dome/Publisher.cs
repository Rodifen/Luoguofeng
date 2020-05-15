using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuoGuoFeng
{
    public class SendParameter
    {
        public ushort[] inputdata { set; get; }
        public double[] AxisPosition { set; get; }
        public ushort[] AxisStatu { set; get; }
        public ushort CardStatu { set; get; }


        public bool[] AxisSensorX { set; get; }
        public bool[] AxisSensorY { set; get; }
        public bool[] AxisSensorZ { set; get; }
        public bool[] AxisSensorA { set; get; }
        public bool[] AxisSensorB { set; get; }

        public string Mess { get; set; }



    }
    public class CustomEventArgs : EventArgs
        {
            public SendParameter SendParat { set; get; }

            public CustomEventArgs(SendParameter sendParameter)
            {
                SendParat = sendParameter;
            }
            private string message;

            public string Message
            {
                get { return message; }
                set { message = value; }
            }
    }

    // Class that publishes an event
    class Publisher
    {

        // Declare the event using EventHandler<T>
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;
        public Func<SendParameter> action;
        public void DoSomething()
        {
            SendParameter sen = new SendParameter();
            // Write some code that does something useful here
            // then raise the event. You can also raise an event
            // before you execute a block of code.
           sen  = action();
            OnRaiseCustomEvent(new CustomEventArgs(sen));
        }

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of                  制作事件的临时副本，以避免发生
            // a race condition if the last subscriber unsubscribes                             如果最后一个订阅者取消订阅，则为竞争条件
            // immediately after the null check and before the event is raised.       在空检查之后立即引发事件之前。


            EventHandler<CustomEventArgs> handler = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message =  DateTime.Now.ToString("HH:mm:ss :  ") +e.Message;
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }
    }

    //Class that subscribes to an event
    class Subscriber
    {
        private string id;
        public Action<SendParameter> func;
         public Subscriber(string ID, Publisher pub)
        {
            id = ID;
            // Subscribe to the event using C# 2.0 syntax
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        // Define what actions to take when the event is raised.
        void HandleCustomEvent(object sender, CustomEventArgs e)
        {

            func(e.SendParat);
        //Console.WriteLine(id + " received this message: {0}", e.Message);
        }
    }



    #region Exmple
    
   
        //static void Main(string[] args)
        //{

        //    Publisher pub = new Publisher();
        //    Subscriber sub1 = new Subscriber("sub1", pub);
        //    Subscriber sub2 = new Subscriber("sub2", pub);

        //    // Call the method that raises the event.
        //    pub.DoSomething();

        //    // Keep the console window open
        //    Console.WriteLine("Press Enter to close this window.");
        //    Console.ReadLine();
    //}
    #endregion


}
