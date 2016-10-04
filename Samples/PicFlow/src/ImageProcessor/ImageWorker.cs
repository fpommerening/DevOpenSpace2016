using System;
using System.Threading.Tasks;
using EasyNetQ;
using FP.DevSpace2016.PicFlow.Contracts;
using FP.DevSpace2016.PicFlow.Contracts.FileHandler;

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

        private async Task WorkImage(ImageProcessingJob job)
        {
            ImageSaveJob nextJob = new ImageSaveJob();

            MongoDbFileHandler fileHandler = new MongoDbFileHandler("mongodb://localhost");
            var file = await fileHandler.GetMessageObject<DtoImage>(job.SourceId);

            Console.WriteLine(file.FileName);

            Console.WriteLine($"Proc {job.SourceId}");

            nextJob.Ids = job.SourceId;
            await _bus.PublishAsync(nextJob);
        }

        public void Dispose()
        {
            _sub?.Dispose();
            _sub = null;

            
        }
    }
}
