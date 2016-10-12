using System;
using EasyNetQ;

namespace FP.DevSpace2016.PicFlow.ImagePersistor
{
    public class Program
    {
        public const string DbCnn = "host=localhost;database=devspace;password=leipzig;username=devspace";
        public const string MongoCnn = "mongodb://localhost";
        public const string RabbitCnn = "host=localhost";

        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus(RabbitCnn);
                myBus.SubscribeAsync<Contracts.Messages.ImageSaveJob>("ImagePersistor", job =>
                {
                    var dbWriter = new DbWriter(MongoCnn, DbCnn);
                    return dbWriter.PersistImage(job.Id, job.UserId, job.SourceId, job.Message);
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
