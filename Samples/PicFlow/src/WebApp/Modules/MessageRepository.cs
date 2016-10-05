using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class MessageRepository
    {
        public MessageRepository()
        {
            
        }

        public Task SendImageProcessingJob(Contracts.ImageProcessingJob job)
        {
            return GetOrCreateBus().PublishAsync(job);
        }

        public Task SendUploadJob(Contracts.ImageUploadJob job)
        {
            return GetOrCreateBus().PublishAsync(job);
        }

        private IBus bus = null;
        private IBus GetOrCreateBus()
        {
            return bus ?? (bus = RabbitHutch.CreateBus("host=localhost"));
        }
    }
}
