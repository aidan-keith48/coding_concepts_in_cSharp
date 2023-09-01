using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace disposableObjectExample
{
    public class ParallExample
    {
        public void loop()
        {
            Console.WriteLine("C# for loop");

            for(int i = 1; i < 20;i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }

        public void ParallelLoop()
        {
            Console.WriteLine("Printing the numebrs using parallel");
            Parallel.For(1,11,number => {Console.WriteLine(number);});

            Console.ReadKey();
        }

        public void CheckEfficency()
        {
            Console.WriteLine("C# FOR LOOP");
            int number = 1000;

            for(int count = 20; count < number;  count++)
            {
                Console.WriteLine($"Value of count = {count}, " + $"thread = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(50);
            }

            Console.WriteLine();
            Console.WriteLine("Parallel for loop");
            Parallel.For(0, number, count =>
            {
                Console.WriteLine($"Value of count = {count}, " + $"Thread = {Thread.CurrentThread.ManagedThreadId}");
            });

            Thread.Sleep(50);

            Console.ReadKey();
        }

        public void UseTimerToSeeTheDifferenceForLoop()
        {
            DateTime StartDateTime = DateTime.Now;
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("For loop excecution start");

            stopwatch.Start();

            for(int i = 0; i < 10; i++)
            {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1}", i, total);
            }

            DateTime EndDateTime = DateTime.Now;
            Console.WriteLine("for loop exceution END");
            stopwatch.Stop();
            Console.WriteLine($"Time taken to exceute the for loop in milliseconds " + $"{stopwatch.ElapsedMilliseconds}");
            Console.ReadKey();
        }

        static long DoSomeIndependentTask()
        {
            long total = 0;
            for(long i = 1; i < 100000000;i++)
            {
                total += 1;
            }
            return total;
        }

        public void UseParallelToSeeTheDifference()
        {
            DateTime StartDateTime = DateTime.Now;
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("For loop excecution start");

            stopwatch.Start();

            Console.WriteLine("Printing the numebrs using parallel");
            Parallel.For(0, 10, number => 
            {
                long total = DoSomeIndependentTask();
                Console.WriteLine("{0} - {1}", number, total);
            });

            DateTime EndDateTime = DateTime.Now;
            Console.WriteLine("for loop exceution END");
            stopwatch.Stop();
            Console.WriteLine($"Time taken to exceute the for loop in milliseconds " + $"{stopwatch.ElapsedMilliseconds}");
            Console.ReadKey();
        }
    }
}
