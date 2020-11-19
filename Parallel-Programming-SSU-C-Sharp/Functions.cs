using System;

namespace Parallel_Programming_SSU_C_Sharp
{
    class Functions
    {
        public double CalcRow(double x)
        {
            x = 100 * Math.Cos(x);
            double y = 0;
            for (int k = 1; k < Math.Max(20.0, 20 * Math.Abs(x)); k++) {
                for (int j = 1; j < Math.Max(20.0, 20 * Math.Abs(x)); j++) {
                    y += (x * x * (k + j)) / (x * x + k * k * k + j * j * j) * Math.Cos(k * x) * Math.Sin(j * x);
                }
            }

            return y;
        }
    }

    class ParallelForDemo
    {
        static void Main1(string[] args)
        {
            const int N = 100;
            
            Functions functions = new Functions();
            double[] array = new double [N];
            
            Int64 ticks = (DateTime.Now).Ticks;
            for (int k = 0; k < N; k++)
            {
                array[k] = functions.CalcRow(k);
            }
            ticks = (DateTime.Now).Ticks - ticks;
            TimeSpan time = new TimeSpan(ticks);
            Console.WriteLine("Sequential algorithm: " + (time.TotalSeconds).ToString() + " seconds");
            
            ticks = (DateTime.Now).Ticks;
            System.Threading.Tasks.Parallel.For(0, N, k => { array[k] = functions.CalcRow(k); });
            ticks = (DateTime.Now).Ticks - ticks;
            time = new TimeSpan(ticks);
            Console.WriteLine("Parallel algorithm " + (time.TotalSeconds).ToString() + " seconds");
        }
    }
}