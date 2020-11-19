//ParallelForEach.cs

using System;
using System.Collections.Generic;

namespace Parallel_Programming_SSU_C_Sharp
{ 
    class ParallelForEachDemo
    {
        static void Main1(string[] args)
        {
            const int N = 100;
            Functions functions = new Functions();
            double[] array = new double[N + 1];
            for (int k = 0; k <= N; k++)
            {
                array[k] = 100 * Math.Cos(1.0 * k);
            }

            double S = 0;
            Int64 ticks = (DateTime.Now).Ticks;
            foreach (double x in array) S += functions.CalcRow(x);
            ticks = (DateTime.Now).Ticks - ticks;
            TimeSpan time = new TimeSpan(ticks);
            Console.WriteLine("S=" + S.ToString());
            Console.WriteLine("Sequential algorithm: " + (time.TotalSeconds).ToString() + " seconds");

            S = 0;
            ticks = (DateTime.Now).Ticks;
            System.Threading.Tasks.Parallel.ForEach(array,
                x =>
                {
                    S += functions.CalcRow(x);
                }
            );
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("S=" + S.ToString());
            Console.WriteLine("Parallel algorithm: " + (time.TotalSeconds).ToString() + " seconds");
        }

        static void Main2(string[] args)
        {
            const int N = 100;
            Functions functions = new Functions();
            List<double> list = new List<double>();
            Stack<double> stack = new Stack<double>();
            Queue<double> queue = new Queue<double>();
            for (int k = 0; k <= N; k++)
            {
                double tmp = 100 * Math.Cos(1.0 * k);
                list.Add(tmp);
                stack.Push(tmp);
                queue.Enqueue(tmp);
            }

            double S = 0;
            Int64 ticks = (DateTime.Now).Ticks;
            foreach (double x in list) S += functions.CalcRow(x);
            ticks = (DateTime.Now).Ticks - ticks;
            TimeSpan time = new TimeSpan(ticks);
            Console.WriteLine("S=" + S.ToString());
            Console.WriteLine("Sequential algorithm for list: " + (time.TotalSeconds).ToString() + " seconds");
            
            S = 0;
            ticks = (DateTime.Now).Ticks;
            foreach (double x in stack) S += functions.CalcRow(x);
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("S=" + S.ToString());
            Console.WriteLine("Sequential algorithm for stack: " + (time.TotalSeconds).ToString() + " seconds");
            
            S = 0;
            ticks = (DateTime.Now).Ticks;
            foreach (double x in queue) S += functions.CalcRow(x);
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("S=" + S.ToString());
            Console.WriteLine("Sequential algorithm for queue: " + (time.TotalSeconds).ToString() + " seconds");

            S = 0;
            ticks = (DateTime.Now).Ticks;
            System.Threading.Tasks.Parallel.ForEach(list,
                x =>
                {
                    S += functions.CalcRow(x);
                }
            );
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("S=" + S.ToString());
            Console.WriteLine("Parallel algorithm for list: " + (time.TotalSeconds).ToString() + " seconds");
            
            S = 0;
            ticks = (DateTime.Now).Ticks;
            System.Threading.Tasks.Parallel.ForEach(stack,
                x =>
                {
                    S += functions.CalcRow(x);
                }
            );
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("S=" + S.ToString());
            Console.WriteLine("Parallel algorithm for stack: " + (time.TotalSeconds).ToString() + " seconds");
            
            S = 0;
            ticks = (DateTime.Now).Ticks;
            System.Threading.Tasks.Parallel.ForEach(queue,
                x =>
                {
                    S += functions.CalcRow(x);
                }
            );
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("S=" + S.ToString());
            Console.WriteLine("Parallel algorithm for queue: " + (time.TotalSeconds).ToString() + " seconds");
        }
    
    
    static void Main(string[] args)
        {
            const int N = 100;
            Functions functions = new Functions();
            List<double> list = new List<double>();
            Stack<double> stack = new Stack<double>();
            Queue<double> queue = new Queue<double>();
            
            List<double> listY = new List<double>();
            Stack<double> stackY = new Stack<double>();
            Queue<double> queueY = new Queue<double>();
            for (int k = 0; k <= N; k++)
            {
                double tmp = 100 * Math.Cos(1.0 * k);
                list.Add(tmp);
                stack.Push(tmp);
                queue.Enqueue(tmp);
            }

            Int64 ticks = (DateTime.Now).Ticks;
            foreach (double x in list)
            {
                listY.Add(functions.CalcRow(x));
            }
            ticks = (DateTime.Now).Ticks - ticks;
            TimeSpan time = new TimeSpan(ticks);
            Console.WriteLine("Sequential algorithm for list: " + (time.TotalSeconds).ToString() + " seconds");
            
            ticks = (DateTime.Now).Ticks;
            foreach (double x in stack)
            {
                stackY.Push(functions.CalcRow(x));
            }
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("Sequential algorithm for stack: " + (time.TotalSeconds).ToString() + " seconds");
            
            ticks = (DateTime.Now).Ticks;
            foreach (double x in queue)
            {
                queueY.Enqueue(functions.CalcRow(x));
            }
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("Sequential algorithm for queue: " + (time.TotalSeconds).ToString() + " seconds");
            
            listY = new List<double>();
            stackY = new Stack<double>();
            queueY = new Queue<double>();

            ticks = (DateTime.Now).Ticks;
            System.Threading.Tasks.Parallel.ForEach(list,
                x =>
                {
                     listY.Add(functions.CalcRow(x));
                }
            );
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("Parallel algorithm for list: " + (time.TotalSeconds).ToString() + " seconds");
            
            ticks = (DateTime.Now).Ticks;
            System.Threading.Tasks.Parallel.ForEach(stack,
                x =>
                {
                    stackY.Push(functions.CalcRow(x));
                }
            );
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("Parallel algorithm for stack: " + (time.TotalSeconds).ToString() + " seconds");
            
            ticks = (DateTime.Now).Ticks;
            System.Threading.Tasks.Parallel.ForEach(queue,
                x =>
                {
                    queueY.Enqueue(functions.CalcRow(x));
                }
            );
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("Parallel algorithm for queue: " + (time.TotalSeconds).ToString() + " seconds");
        }
    }
}