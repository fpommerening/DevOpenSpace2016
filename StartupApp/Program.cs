using System;
using System.Threading;
using Nancy.Hosting.Self;

namespace StartupApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:15106")))
            {
                host.Start();

                while (Console.ReadLine() != "quit") { Thread.Sleep(Int32.MaxValue); }
            }
        }
    }
}
