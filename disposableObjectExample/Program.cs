using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace disposableObjectExample
{
    public class Program
    {
        static ThreadStart childref = new ThreadStart(multiThreadingFunction.CallToChild);
        static Thread childThread2 = new Thread(childref);

        static ThreadStart childref1 = new ThreadStart(multiThreadingFunction.CallToChildTest);
        static Thread childThread21 = new Thread(childref1);
        static void Main(string[] args)
        {
            multiThreadingFunction threads = new multiThreadingFunction();
            createThread createThread = new createThread();

            linqClass link = new linqClass();
            UsingProcesses process = new UsingProcesses();
            ParallExample parallelExample= new ParallExample();



            //for(int i= 0; i < args.Length;i++)
            //{
            //    Console.WriteLine($"Args:{0}", args[i]);
            //}

            //using (var disp = new disposableDemoClass())
            //{

            //}

            // ///link.linqFunctions();
            //// link.linqFunctionsDictionary();
            // Console.WriteLine("\n\n");
            // Student.display();
            // Console.WriteLine("\n\n");
            // Student.StandardQuery();
            // Console.WriteLine("\n\n");
            // process.ListAllRunningProcess();
            // Console.WriteLine("\n\n");
            // process.GetProcByID();
            // process.StartAndKillProcess();
            //threads.multiThread();

            // createThread.startThread();
            //childThread2.Start();
            //Console.WriteLine("\n\n");
            // childThread21.Start();
            //threads.destroyThreads();

            //  parallelExample.loop();
            // Console.WriteLine("\n\n");
            //parallelExample.ParallelLoop();
            // Console.WriteLine("\n\n");
            // parallelExample.CheckEfficency();
            parallelExample.UseTimerToSeeTheDifferenceForLoop();
            Console.WriteLine("\n\n");
            parallelExample.UseParallelToSeeTheDifference();
            Console.WriteLine("\n\n");
           







            Console.ReadKey();
        }

        class disposableDemoClass:IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Dispose called");
            }
        }

        class Orders
        {
            public Orders(int i)
            {
                   
            }
        }
    }
}
