using System;
using System.Threading.Tasks;

namespace Parallel_Programming_SSU_C_Sharp
{
    public class TasksContinuationDemo
    {
        public static void Main1()
        {
            var firstTask = Task.Factory.StartNew(() => {
                Random rnd = new Random();
                DateTime[] dates = new DateTime[100];
                Byte[] buffer = new Byte[8];
                int ctr = dates.GetLowerBound(0);
                while (ctr <= dates.GetUpperBound(0))
                {
                    rnd.NextBytes(buffer);
                    long ticks = BitConverter.ToInt64(buffer, 0);
                    if (ticks <= DateTime.MinValue.Ticks | ticks >= DateTime.MaxValue.Ticks)
                        continue;

                    dates[ctr] = new DateTime(ticks);
                    ctr++;
                }
                return dates;
            });

            Task continuationTask = firstTask.ContinueWith((antecedent) => {
                DateTime[] dates = antecedent.Result;
                DateTime earliest = dates[0];
                DateTime latest = earliest;

                for (int ctr = dates.GetLowerBound(0) + 1; ctr <= dates.GetUpperBound(0); ctr++)
                {
                    if (dates[ctr] < earliest) earliest = dates[ctr];
                    if (dates[ctr] > latest) latest = dates[ctr];
                }
                Console.WriteLine("Earliest date: {0}", earliest);
                Console.WriteLine("Latest date: {0}", latest);
            });
            // Since a console application otherwise terminates, wait for the continuation to complete.
            continuationTask.Wait();
        }
    }
}
