using System;
using EasyNetQ;
using FP.DevSpace2016.Logging.Contacts;

namespace FP.DevSpace2016.Logging.ConsoleListener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost");
                myBus.Subscribe<LogItem>("ConsoleLogger", log =>
                {
                    Console.WriteLine("{0:HH:mm:ss.fff} [{1}] {2} -> {3} {4}",
                        log.Timestamp, log.SessionId, log.RemoteHost, log.InstanceHost, log.State);
                });
                Console.WriteLine("Logger gestartet...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Verbindung ist fehlgeschlagen");
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }

            Console.WriteLine("Logger beendet...");
        }
    }
}
