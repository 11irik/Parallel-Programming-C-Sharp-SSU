using System;
using System.Threading;

namespace Parallel_Programming_SSU_C_Sharp
{
    class ThreadStaticAttributeDemo
    {
        static void Main1()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread newThread = new Thread(ThreadData.ThreadStaticDemo);
                newThread.Start();
            }
        }
    }

    class ThreadData
    {
        [ThreadStatic]
        static int threadSpecificData;

        public static void ThreadStaticDemo()
        {
            // Store the managed thread id for each thread in the static 
            // variable.
            threadSpecificData = Thread.CurrentThread.ManagedThreadId;

            // Allow other threads time to execute the same code, to show 
            // that the static data is unique to each thread.
            Thread.Sleep(1000);

            // Display the static data.
            Console.WriteLine("Data for managed thread {0}: {1}",
                Thread.CurrentThread.ManagedThreadId, threadSpecificData);
        }
    }
}