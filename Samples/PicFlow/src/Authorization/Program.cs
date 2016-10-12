using System;

namespace FP.DevSpace2016.PicFlow.Authorization
{
    public class Program
    {
        public static void Main(string[] args)
        {

            
            try
            {
                var userRepo = new UserRepository("host = localhost; database = devspace; password = leipzig; username = devspace");

                Console.WriteLine("Authorization gestartet...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Authorization - Verbindung ist fehlgeschlagen");
                Console.WriteLine(ex);
            }
           

            Console.WriteLine("Authorization beendet...");
        }

      
    }
}
