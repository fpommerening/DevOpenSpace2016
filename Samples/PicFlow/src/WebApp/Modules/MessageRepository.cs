﻿using System.Threading.Tasks;
using EasyNetQ;
using FP.DevSpace2016.PicFlow.Contracts.Messages;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class MessageRepository
    {
        private readonly IBus _bus = null;

        public MessageRepository(IBus bus)
        {
            _bus = bus;
        }

        public Task SendImageProcessingJob(ImageProcessingJob job)
        {
            return _bus.PublishAsync(job);
        }

        public Task SendUploadJob(ImageUploadJob job)
        {
            return _bus.PublishAsync(job);
        }
    }
}
