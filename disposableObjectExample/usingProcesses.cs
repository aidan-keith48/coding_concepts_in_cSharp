using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disposableObjectExample
{
    public class UsingProcesses
    {
        int count = 0;
       public void ListAllRunningProcess()
        {
            var runningProcs = from process in Process.GetProcesses(".")
                               orderby process.Id
                               select process;

            foreach(var p in runningProcs)
            {
                count++;
                string info = string.Format("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
                Console.WriteLine($"{info}");
                Console.WriteLine("************************************************************************************");
            }

            Console.WriteLine("This is the total amount of process: " + count.ToString());
        }

        public void GetProcByID()
        {
            Process theProcess = null;
            try
            {
                theProcess = Process.GetProcessById(636);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return; // Return early to avoid further processing if an exception occurs
            }

            // List stats of each thread

            Console.WriteLine("Here are the threads used by: {0}", theProcess.ProcessName);
            ProcessThreadCollection theThread = theProcess.Threads;

            foreach (ProcessThread pt in theThread)
            {
                string info = string.Format("-> Thread ID: {0}\tStart time: {1}\tPriority: {2}", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************************************************************");
        }


        public void StartAndKillProcess()
        {
            Process ieProc = null;

            try
            {
                ieProc = Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", "https://www.instagram.com/");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (ieProc != null)
            {
                Console.WriteLine("--> Hit enter to kill {0}..", ieProc.ProcessName);
                //Console.ReadKey();

                try
                {
                    ieProc.Kill();
                    ieProc.Dispose(); // Properly dispose of the process
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
