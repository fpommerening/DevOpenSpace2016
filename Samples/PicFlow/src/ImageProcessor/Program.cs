using System;
using EasyNetQ;

namespace FP.DevSpace2016.PicFlow.ImageProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost");
                using (var worker = new ImageWorker(myBus))
                {
                    worker.Init();
                    Console.WriteLine("ImageProcessor gestartet...");
                    Console.ReadLine();
                }
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

            Console.WriteLine("ImageProcessor beendet...");
        }
    }
}
