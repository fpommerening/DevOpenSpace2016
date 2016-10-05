using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EasyNetQ;
using FP.DevSpace2016.PicFlow.Contracts;

namespace FP.DevSpace2016.PicFlow.Uploader
{
    public class Transmitter : IDisposable
    {
        private readonly IBus _myBus;
        private IDisposable _subscription;

        public Transmitter(IBus myBus)
        {
            _myBus = myBus;
        }

        public void Init()
        {
            _subscription = _myBus.SubscribeAsync<ImageUploadJob>("UploadSubscription", job => UploadImage(job));
        }

        private Task UploadImage(ImageUploadJob job)
        {
            HttpClient client = new HttpClient();
            var contect = new MultipartFormDataContent();
            //contect.
            client.PostAsync("http://extweb/api/postimage", null);
            return null;
        }

        public void Dispose()
        {
            _subscription?.Dispose();
            _subscription = null;
        }
    }
}
