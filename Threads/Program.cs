using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread");
            var thread = new ThreadStart(CallInsideSecondThread);
            var newThread = new Thread(thread);
            newThread.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Back to the main thread");
            Console.ReadKey();

            Example example = new Example();

            lock (example)
            {
                example.ThreadMethod();
            }
        }

        class Example
        {
            private object _syncObject = new object();

            public void ThreadMethod()
            {
                System.Threading.Monitor.Enter(_syncObject);
                try
                {
                    // always sync 
                }
                finally
                {
                    System.Threading.Monitor.Exit(_syncObject);
                }
            }
        }







        public static void CallInsideSecondThread()
        {
            Console.WriteLine($"The second thread has started");
            Thread.Sleep(2000);
            Console.WriteLine($"We are again in the second thread");
        }
    }
}