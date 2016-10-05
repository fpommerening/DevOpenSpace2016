using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EasyNetQ;
using FP.DevSpace2016.PicFlow.Contracts;
using FP.DevSpace2016.PicFlow.Contracts.FileHandler;

namespace FP.DevSpace2016.PicFlow.Uploader
{
    public class Transmitter : IDisposable
    {
        private readonly IBus _myBus;
        private readonly string _mongoConnectionString;
        private IDisposable _subscription;

        public Transmitter(IBus myBus, string mongoConnectionstring)
        {
            _myBus = myBus;
            _mongoConnectionString = mongoConnectionstring;
        }

        public void Init()
        {
            _subscription = _myBus.SubscribeAsync<ImageUploadJob>("UploadSubscription", job => UploadImage(job));
        }

        private async Task UploadImage(ImageUploadJob job)
        {
            
            var handler = new MongoDbFileHandler(_mongoConnectionString);
            var image = await handler.GetMessageObject<DtoImage>(job.ImageId);
            var client = new HttpClient();
            using (var inputstream = new MemoryStream(image.Data))
            {
                var contect = new MultipartFormDataContent
                {
                    {new StringContent("Hallo Welt"), "msg"},
                    {new StreamContent(inputstream)}
                };
                await client.PostAsync("http://localhost:8000/api/postimage", contect);
            }
               
            


           
        }

        public void Dispose()
        {
            _subscription?.Dispose();
            _subscription = null;
        }
    }
}
