using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Task> jobs = new List<Task>();
            for (int i = 0; i < 20; i++)
            {
                string id = "worker " + i;
                jobs.Add(Task.Factory.StartNew(new Action<object>(Run), id));

            }
            Task.WaitAll(jobs.ToArray());

            //Console.WriteLine("Hello World!");
        }

        public static void Run(Object param)
        {
            while (true)
            {
                string stamp = DateTime.Now.ToString("HH:mm:ss") + "-->" + Math.Sqrt(DateTime.Now.Millisecond);
                Console.WriteLine($"{param}:{stamp}");
            }
        }
    }
}