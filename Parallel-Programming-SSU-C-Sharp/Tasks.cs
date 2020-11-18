using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Parallel_Programming_SSU_C_Sharp
{
    public class TasksDemo
    {
        public static void Main1()
        {
            var list = new ConcurrentBag<string>();
            string[] dirNames = { ".", ".." };
            List<Task> tasks = new List<Task>();
            foreach (var dirName in dirNames)
            {
                Task t = new Task(() => {
                    foreach (var path in Directory.GetFiles(dirName))
                        list.Add(path);
                });
                tasks.Add(t);
                t.Start();
            }
            Task.WaitAll(tasks.ToArray());
            foreach (Task t in tasks)
                Console.WriteLine("Task {0} Status: {1}", t.Id, t.Status);

            Console.WriteLine("Number of files read: {0}", list.Count);
        }
    }
}
