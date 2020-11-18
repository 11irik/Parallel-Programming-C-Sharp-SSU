//ParallelForEach.cs

using System;

namespace Parallel_Programming_SSU_C_Sharp
{
    class ParallelForEach
    {
        public double Func(double x)
        {
            int N = Math.Max(20, (int) Math.Floor(20 * Math.Abs(x)));
            double S = 0;
            double x2 = x * x;
            for (int k = 1; k <= N; k++)
            for (int j = 1; j <= N; j++)
                S += x2 * Math.Sin((k + j) * x) / (x2 + k * k + j * j);
            return S;
        }
    };

    class ParallelForEachDemo
    {
        static void Main1(string[] args)
        {
            const int N = 200;
            ParallelForEach fobj = new ParallelForEach();
            double[] X = new double[N + 1];
            for (int k = 0; k <= N; k++)
            {
                X[k] = 100 * Math.Cos(1.0 * k);
            }

            double S = 0;
            Int64 Tms = (DateTime.Now).Ticks;
            foreach (double x in X) S += fobj.Func(x);
            Tms = (DateTime.Now).Ticks - Tms;
            TimeSpan Tmss = new TimeSpan(Tms);
            Console.WriteLine("S=" + S.ToString());
            Console.WriteLine("Время выполнения последовательной операции foreach " + (Tmss.TotalSeconds).ToString() +
                              " c");

            Object obj = new Object();
            S = 0;
            Tms = (DateTime.Now).Ticks;
            System.Threading.Tasks.Parallel.ForEach(X,
                x =>
                {
                    double Tmp = fobj.Func(x);
                    lock (obj)
                    {
                        S += Tmp;
                    }
                }
            );
            Tms = (DateTime.Now).Ticks - Tms;
            Tmss = new TimeSpan(Tms);
            Console.WriteLine("S=" + S.ToString());
            Console.WriteLine("Время выполнения параллельного метода ForEach " + (Tmss.TotalSeconds).ToString() + " c");
        }
    }
}