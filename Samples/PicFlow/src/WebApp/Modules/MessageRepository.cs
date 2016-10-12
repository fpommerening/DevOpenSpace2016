using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.Contracts.Messages;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class MessageRepository
    {
        
        public MessageRepository()
        {
            
        }

        public Task SendImageProcessingJob(ImageProcessingJob job)
        {
            return null;
        }

        public Task SendUploadJob(ImageUploadJob job)
        {
            return null;
        }
    }
}
