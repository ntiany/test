using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ThreadExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<ThreadKeeper>();
            var running = true;

            while (running)
            {
                Console.WriteLine("Command?");
                var answer = Console.ReadLine();
                var answers = answer?.Split();

                if (answers != null && answers.Length == 2)
                {
                    var name = answers[1];
                    var command = answers[0];
                    var thread = list.FirstOrDefault(x => x.Name == name);

                    if (thread == null && command == "start")
                    {
                        list.Add(new ThreadKeeper(name));
                        Console.WriteLine($"Thread {name} added");
                    }
                    else if(thread != null && command == "stop")
                    {
                        thread.StopThread();
                        list.Remove(thread);
                        Console.WriteLine($"Thread {name} removed");
                    }
                    else if (thread != null && command == "show")
                    {
                        Console.WriteLine("Current threads:");
                        Console.WriteLine($"Thread {thread.Thread.Name} Id: {thread.Thread.ManagedThreadId} is executing for {thread.Watch.ElapsedMilliseconds} ms");
                    }
                }
                else if (answer == "show")
                {
                    list.ForEach(thread => Console.WriteLine($"Thread {thread.Thread.Name} Id: {thread.Thread.ManagedThreadId} is executing for {thread.Watch.ElapsedMilliseconds} ms"));
                }
                else if (answer == "exit")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
        }
    }
}
