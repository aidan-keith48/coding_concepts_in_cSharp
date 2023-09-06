using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            FileReading fr = new FileReading();
            Employee emp = new Employee();



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
            // parallelExample.UseTimerToSeeTheDifferenceForLoop();
            // Console.WriteLine("\n\n");
            //parallelExample.UseParallelToSeeTheDifference();
            //Console.WriteLine("\n\n");
            //parallelExample.CallMethodsUsingParallel();
            //fr.writerMethod();
            //fr.readerMethod();
            // fr.getFirstLetter();
            //fr.BinaryFiles();



            emp.empID = 1;
            emp.empName = "Aidan Keith Naidoo";

            //Adding code for sterialize
            Stream stream = File.Open("EmployeeInfo.osl", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            Console.WriteLine("Writing Employee Informaton");
            bf.Serialize(stream, emp);
            stream.Close();

            //Clear up further usage
            emp = new Employee();

            stream = File.Open("EmployeeInfo.osl", FileMode.Open);
            emp = (Employee)bf.Deserialize(stream);
            stream.Close();

            Console.WriteLine("Employee id: {0}", emp.empID.ToString());
            Console.WriteLine("Employee name: {0} ", emp.empName);




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
