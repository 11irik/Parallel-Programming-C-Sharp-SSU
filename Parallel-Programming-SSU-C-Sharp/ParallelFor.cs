//ParallelFor.cs

using System;

namespace Parallel_Programming_SSU_C_Sharp
{
    class ParallelFor
    {
        public double My_Task(int k)
        {
            int KK = ((k + 11) % 11) + ((k + 3) % 4);
            double S = 0;
            for (int j1 = 1; j1 <= 1000 * KK; j1++)
            {
                double Tmp1 = 3.14 * j1;
                for (int j2 = 1; j2 <= 1000 * KK; j2++)
                {
                    double Tmp2 = 2.78 * j2;
                    S += 1.0 / (Tmp1 * Tmp1 * Tmp1 + Tmp2 * Tmp2 * Tmp2);
                }
            }

            return S;
        }
    };

    class ParallelForDemo
    {
        static void Main1(string[] args)
        {
            const int N = 100;
            ParallelFor Obj = new ParallelFor();
            double[] V = new double [N];
            Int64 Tms = (DateTime.Now).Ticks;
            for (int k = 0; k < N; k++)
            {
                V[k] = Obj.My_Task(k);
            }

            Tms = (DateTime.Now).Ticks - Tms;
            TimeSpan Tmss = new TimeSpan(Tms);
            Console.WriteLine("Время выполнения последовательного цикла " + (Tmss.TotalSeconds).ToString() + " c");
            Tms = (DateTime.Now).Ticks;
            System.Threading.Tasks.Parallel.For(0, N, k => { V[k] = Obj.My_Task(k); });
            Tms = (DateTime.Now).Ticks - Tms;
            Tmss = new TimeSpan(Tms);
            Console.WriteLine("Время выполнения параллельного цикла " + (Tmss.TotalSeconds).ToString() + " с");
        }
    }
}