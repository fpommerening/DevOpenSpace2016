using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using FP.DevSpace2016.PicFlow.Contracts;

namespace FP.DevSpace2016.PicFlow.ImageProcessor
{
    public class ImageWorker : IDisposable
    {
        private IBus _bus;
        private IDisposable _sub;

        public ImageWorker(IBus bus)
        {
            _bus = bus;
        }

        public void Init()
        {
            _sub = _bus.SubscribeAsync<Contracts.ImageProcessingJob>("Sub1", job => WorkImage(job));
        }

        private Task WorkImage(ImageProcessingJob job)
        {
            ImageSaveJob nextJob = new ImageSaveJob();
            Console.WriteLine($"Proc {job.SourceId}");

            nextJob.Ids = job.SourceId;
            return _bus.PublishAsync(nextJob);
        }

        public void Dispose()
        {
            _sub?.Dispose();
            _sub = null;

            
        }
    }
}
