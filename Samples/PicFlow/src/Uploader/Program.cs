using System;
using EasyNetQ;
using FP.DevSpace2016.PicFlow.Contracts;

namespace FP.DevSpace2016.PicFlow.Uploader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            try
            {
                myBus = RabbitHutch.CreateBus(EnvironmentVariable.GetValueOrDefault("ConnectionStringRabbitMQ", "host=localhost"));
                var cnnImageDb = EnvironmentVariable.GetValueOrDefault("ConnectionStringImageDB", "mongodb://localhost");
                var externalAppUrl = EnvironmentVariable.GetValueOrDefault("ExternalAppUrl", "http://localhost:8000/api/postimage");
                using (var transmittter = new Transmitter(myBus, cnnImageDb, externalAppUrl))
                {
                    transmittter.Init();
                    Console.WriteLine("Uploader gestartet...");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Uploader ist fehlgeschlagen");
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }

            Console.WriteLine("Uploader beendet...");
        }
    }
}
