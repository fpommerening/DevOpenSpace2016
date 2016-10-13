using System;

namespace FP.DevSpace2016.PicFlow.ImagePersistor
{
    public class Program
    {
        public const string DbCnn = "host=localhost;database=devspace;password=leipzig;username=devspace";
        public const string MongoCnn = "mongodb://localhost";
        public const string RabbitCnn = "host=localhost";

        public static void Main(string[] args)
        {
            
            try
            {
                
                Console.WriteLine("ImagePersistor gestartet...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ImagePersistor - Verbindung ist fehlgeschlagen");
                Console.WriteLine(ex);
            }

            Console.WriteLine("ImagePersistor beendet...");
        }
    }
}
