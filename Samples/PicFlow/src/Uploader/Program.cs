using System;

namespace FP.DevSpace2016.PicFlow.Uploader
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            try
            {
           
                using (var transmittter = new Transmitter("mongodb://localhost"))
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
            }

            Console.WriteLine("Uploader beendet...");
        }
    }
}
