using System;
using EasyNetQ;

namespace FP.DevSpace2016.PicFlow.Authorization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost");
                myBus.Subscribe<Contracts.AuthenticationRequest>("Auth", request =>
                {
                    var response = new Contracts.AuthenticationResponse
                    {
                        Id = request.Id,
                    };

                    if (request.UserName == "frank")
                    {
                        response.UserId = Guid.Parse("34D012C4-2572-4481-84D6-3AF1FDA3A756");
                        response.User = "Frank Pommerening";
                        response.IsValid = true;
                    }
                  
                    myBus.Publish(response);
                });

                Console.WriteLine("Authorization gestartet...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Authorization - Verbindung ist fehlgeschlagen");
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }

            Console.WriteLine("Authorization beendet...");
        }
    }
}
