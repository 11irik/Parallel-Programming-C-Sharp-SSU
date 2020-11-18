using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Programming_SSU_C_Sharp
{
    class BarrierDemo
    {
        private static void Main()
        {
            Barrier barrier = new Barrier(4,
                (b) => { Console.WriteLine("Post-Phase action: phase={0}", b.CurrentPhaseNumber); });

            Action action = () =>
            {
                Random Rnd = new Random();
                int num = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("Thread {0}: start work", num);
                Thread.Sleep((int) (1000 * num));
                Console.WriteLine("Thread {0}: end work", num);
                barrier.SignalAndWait();
                Console.WriteLine("Thread {0}: start work", num);
                Thread.Sleep((int) (1000 * num));
                Console.WriteLine("Thread {0}: end work", num);
                barrier.SignalAndWait();
                Console.WriteLine("Thread {0}: start work", num);
                Thread.Sleep((int) (1000 * num));
                Console.WriteLine("Thread {0}: end work", num);
            };

            Parallel.Invoke(action, action, action, action);
            Console.WriteLine("Work finished");
            barrier.Dispose();
        }
    }
}