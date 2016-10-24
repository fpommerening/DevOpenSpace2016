using System;
using System.Threading;
using EasyNetQ;
using FP.DevSpace2016.PicFlow.Contracts;

namespace FP.DevSpace2016.PicFlow.ImagePersistor
{
    public class Program
    {
       

        public static void Main(string[] args)
        {
            var dbCnn = EnvironmentVariable.GetValueOrDefault("ConnectionStringImageDB",
                "host=localhost;database=devspace;password=leipzig;username=devspace");
            var mongoCnn = EnvironmentVariable.GetValueOrDefault("ConnectionStringDocumentDB", "mongodb://localhost");
            var rabbitCnn = EnvironmentVariable.GetValueOrDefault("ConnectionStringRabbitMQ", "host=localhost");

            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus(rabbitCnn);
                myBus.SubscribeAsync<Contracts.Messages.ImageSaveJob>("ImagePersistor", async job =>
                {
                    var dbWriter = new DbWriter(mongoCnn, dbCnn);
                    await dbWriter.PersistImage(job.Id, job.UserId, job.SourceId, job.Message, job.Resolution);
                });
                    
                Console.WriteLine("ImagePersistor gestartet...");
                while (Console.ReadLine() != "quit") { Thread.Sleep(int.MaxValue); }
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
