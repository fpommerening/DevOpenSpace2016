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
        
        private readonly string _mongoConnectionString;

        public Transmitter(string mongoConnectionstring)
        {
            
            _mongoConnectionString = mongoConnectionstring;
        }

        public void Init()
        {
           
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
                await client.PostAsync("http://localhost:8000/api/postimage", content);
            }

        }

        public void Dispose()
        {
        }
    }
}
