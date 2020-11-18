﻿using System;
using System.Threading;

namespace Parallel_Programming_SSU_C_Sharp
{
    class MutexDemo
    {
        // Create a new Mutex. The creating thread does not own the mutex. 
        private static Mutex mut = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 3;

        static void Main1()
        {
            // Create the threads that will use the protected resource. 
            for (int i = 0; i < numThreads; i++)
            {
                Thread newThread = new Thread(new ThreadStart(ThreadProc));
                newThread.Name = String.Format("Thread{0}", i + 1);
                newThread.Start();
            }

            // The main thread exits, but the application continues to 
            // run until all foreground threads have exited.
        }

        private static void ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }

        // This method represents a resource that must be synchronized 
        // so that only one thread at a time can enter. 
        private static void UseResource()
        {
            // Wait until it is safe to enter, and do not enter if the request times out.
            Console.WriteLine("{0} is requesting the mutex", Thread.CurrentThread.Name);
            if (mut.WaitOne(1000))
            {
                Console.WriteLine("{0} has entered the protected area",
                    Thread.CurrentThread.Name);

                // Place code to access non-reentrant resources here. 

                // Simulate some work.
                Thread.Sleep(5000);

                Console.WriteLine("{0} is leaving the protected area",
                    Thread.CurrentThread.Name);

                // Release the Mutex.
                mut.ReleaseMutex();
                Console.WriteLine("{0} has released the mutex",
                    Thread.CurrentThread.Name);
            }
            else
            {
                Console.WriteLine("{0} will not acquire the mutex",
                    Thread.CurrentThread.Name);
            }
        }
    }
}
