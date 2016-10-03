using System;
using EasyNetQ;

namespace FP.DevSpace2016.PicFlow.ImagePersistor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost");
                myBus.Subscribe<Contracts.ImageSaveJob>("tetet", job =>
                {
                    Console.WriteLine($"Los speichern {job.Ids}");
                });
                    
                Console.WriteLine("ImagePersistor gestartet...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ImagePersistor - Verbindung ist fehlgeschlagen");
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }

            Console.WriteLine("ImagePersistor beendet...");
        }
    }
}
