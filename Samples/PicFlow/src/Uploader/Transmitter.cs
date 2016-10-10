using System;
using System.Net.Http;
using System.Threading.Tasks;
using EasyNetQ;
using FP.DevSpace2016.PicFlow.Contracts.Dto;
using FP.DevSpace2016.PicFlow.Contracts.FileHandler;
using FP.DevSpace2016.PicFlow.Contracts.Messages;

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

            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent("Jetzt geht es los"), "User");
                content.Add(new StringContent("Jetzt geht es los2"), "Message");
                content.Add(new StringContent("ajskdjkasjdkja"), "APIKEY");
                content.Add(new ByteArrayContent(image.Data), "Image", image.FileName);
                await client.PostAsync("http://localhost:8000/api/postimage", content);
            }

        }

        public void Dispose()
        {
            _subscription?.Dispose();
            _subscription = null;
        }
    }
}
