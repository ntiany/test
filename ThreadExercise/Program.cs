using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ThreadExercise
{
    class Program
    {
        private List<Stopwatch> _stopwatches = new List<Stopwatch>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Command?");
                var answer = Console.ReadLine();
                var answers = answer.Split();



            }
        }

        public Thread CreateThread(string name)
        {
            var threadStart = new ThreadStart(AddNewStopwatch);
            var thread = new Thread(threadStart);
            return null;
        }

        public void AddNewStopwatch()
        {
            var stopwatch = new Stopwatch();
            _stopwatches.Add(stopwatch);
            stopwatch.Start();
        }
    }
}
