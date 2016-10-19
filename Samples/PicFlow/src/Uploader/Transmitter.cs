﻿using System;
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
        private readonly string _externalAppUrl;

        public Transmitter(IBus myBus, string mongoConnectionstring, string externalAppUrl)
        {
            _myBus = myBus;
            _mongoConnectionString = mongoConnectionstring;
            _externalAppUrl = externalAppUrl;
        }

        public void Init()
        {
            _subscription = _myBus.SubscribeAsync<ImageUploadJob>("UploadSubscription", job => UploadImage(job));
        }

        private async Task UploadImage(ImageUploadJob job)
        {

            var handler = new MongoDbFileHandler(_mongoConnectionString);
            var image = await handler.GetMessageObject<DtoImage>(job.Id);

            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(job.User), "User");
                content.Add(new StringContent(job.Message), "Message");
                content.Add(new StringContent("devspace2016"), "APIKEY");
                content.Add(new ByteArrayContent(image.Data), "Image", image.FileName);
                await client.PostAsync(_externalAppUrl, content);
            }

        }

        public void Dispose()
        {
            _subscription?.Dispose();
            _subscription = null;
        }
    }
}
