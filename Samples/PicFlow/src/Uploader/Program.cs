using System;
using EasyNetQ;

namespace FP.DevSpace2016.PicFlow.Uploader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost");
                using (var transmittter = new Transmitter(myBus))
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
