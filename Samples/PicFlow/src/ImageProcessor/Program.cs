using System;

namespace FP.DevSpace2016.PicFlow.ImageProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            try
            {
                using (var worker = new ImageWorker())
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
                
            }

            Console.WriteLine("ImageProcessor beendet...");
        }
    }
}
