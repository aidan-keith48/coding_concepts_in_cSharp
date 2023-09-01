using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace disposableObjectExample
{
    public class multiThreadingFunction
    {
        // Declaration of a ThreadStart delegate for CallToChild method
        static ThreadStart childref = new ThreadStart(CallToChild);

        // Declaration of a child thread using the ThreadStart delegate
        static Thread childThread2 = new Thread(childref);

        static ThreadStart childRefTest=new ThreadStart(CallToChildTest);
        static Thread testChildThread = new Thread(childRefTest);

        // Entry point for the child thread
        public static void CallToChild()
        {
            Console.WriteLine("Starting child thread");
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(500); // Sleep for 500 milliseconds
                if (i == 5)
                {
                    Console.WriteLine("Thread " + childThread2.Name + " is killed");
                }
                Console.WriteLine(i);
            }
        }

        public static void CallToChildTest()
        {
            Console.WriteLine("Starting Test child thread");
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(500); // Sleep for 500 milliseconds
                if (i == 5)
                {
                    Console.WriteLine("Thread " + testChildThread.CurrentCulture + " is TESTED killed " + testChildThread.ThreadState);
                }
                Console.WriteLine(i +"TESTING THREADS");
            }
        }

        // Another entry point for a different child thread
        public static void callToChild2()
        {
            Console.WriteLine("Second child thread starts");
            int sleepFor = 5000;
            Console.WriteLine("Child thread paused for {0} seconds", sleepFor / 1000);
            Thread.Sleep(sleepFor); // Sleep for 5 seconds
            Console.WriteLine("Second child thread resumes");
        }
        


        // Method to demonstrate main thread and its properties
        public void multiThread()
        {
            Thread th = Thread.CurrentThread;
            th.Name = "Main_Thread";
            Console.WriteLine("This is {0} threadstate {1}", th.Name, th.ThreadState);
        }

        // Method to create and destroy threads
        public void destroyThreads()
        {
            // Creating a new child thread using the callToChild2 method
            ThreadStart childref = new ThreadStart(callToChild2);
            Console.WriteLine("In main: Creating the child thread");
            Thread childThread = new Thread(childref);
            childThread.Start(); // Starting the previously declared child thread

            Thread.Sleep(2000); // Sleep for 2 seconds
            Console.WriteLine("In main: Aborting the child thread");
            childThread2.Abort(); // Aborting the child thread (Note: Abort is discouraged)
        }
    }

}
