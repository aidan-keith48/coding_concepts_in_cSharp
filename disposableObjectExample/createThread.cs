using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace disposableObjectExample
{
    public class createThread
    {
        public static void CallToChildThread()
        {
            Console.WriteLine("Child thread starts");
        }

        public void startThread()
        {
            Thread th = Thread.CurrentThread;
            ThreadStart childRef = new ThreadStart(CallToChildThread);

            //th.Suspend();
            Console.WriteLine("In main: Creating the child thread");
            // th.Resume(); 

            Thread childThread = new Thread(childRef);
            childThread.Start();

        }
    }
}

