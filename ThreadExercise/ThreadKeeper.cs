using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ThreadExercise
{
    public class ThreadKeeper
    {
        public Stopwatch Watch { get; private set; }

        public Thread Thread { get; private set; }

        public string Name { get; private set; }

        private bool _run = true;

        public ThreadKeeper(string name)
        {
            Watch = new Stopwatch();
            Thread = CreateThread(name);
            StartThread();
        }

        public Thread CreateThread(string name)
        {
            var threadStart = new ThreadStart(DoNothing);
            var thread = new Thread(threadStart);
            Name = name;
            thread.Name = name;
            return thread;
        }

        public void DoNothing()
        {
            while (true)
            {

            }
        }

        public void StartThread()
        {
            Watch.Start();
            Thread.Start();
        }

        public void StopThread()
        {
            Watch.Stop();
            _run = false;
        }

    }
}
