using System.Threading.Tasks;
using EasyNetQ;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class MessageRepository
    {
        private readonly IBus _bus = null;

        public MessageRepository(IBus bus)
        {
            _bus = bus;
        }

        public Task SendImageProcessingJob(Contracts.ImageProcessingJob job)
        {
            return _bus.PublishAsync(job);
        }

        public Task SendUploadJob(Contracts.ImageUploadJob job)
        {
            return _bus.PublishAsync(job);
        }
    }
}
