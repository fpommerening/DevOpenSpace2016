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
                var userRepo = new UserRepository("host = localhost; database = devspace; password = leipzig; username = devspace");
                myBus.SubscribeAsync<Contracts.Messages.AuthenticationRequest>("Auth", async request =>
                {
                    var response = new Contracts.Messages.AuthenticationResponse
                    {
                        Id = request.Id,
                    };

                    var userInfo = await userRepo.CheckUser(request.UserName, request.PasswordHash);
                    if (userInfo.IsValid)
                    {
                        response.UserId = userInfo.Id;
                        response.User = userInfo.User;
                        response.IsValid = true;
                    }

                    await myBus.PublishAsync(response);
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
