using System;
using System.Threading;

namespace Parallel_Programming_SSU_C_Sharp
{
    public class TimerDemo
    {
        private static Timer ticker;

        public static void TimerMethod(object state)
        {
            Console.Write(".");
        }

        public static void Main1()
        {
            ticker = new Timer(TimerMethod, null, 1000, 1000);

            Console.WriteLine("Press the Enter key to end the program.");
            Console.ReadLine();
        }
    }
}