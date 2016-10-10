using FP.DevSpace2016.PicFlow.Contracts.FileHandler;
using FP.DevSpace2016.PicFlow.Contracts.Messages;
using FP.DevSpace2016.PicFlow.WebApp.Models;
using Nancy;
using Nancy.ModelBinding;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class ImageModule : NancyModule
    {
        private readonly IFileHandler _fileUploadHandler;
        private readonly MessageRepository _messageRepository;

        public ImageModule(IFileHandler fileUploadHandler, MessageRepository messageRepository)
        {
            _fileUploadHandler = fileUploadHandler;
            _messageRepository = messageRepository;

            Get("/imagerequest", args =>
            {
                var identity = this.Context.CurrentUser;
                if (identity == null)
                {
                    return View["Login"];
                }
                else
                {
                    return View["ImageRequest"];
                }
            });

            Post("/imagerequest", async args =>
            {
                var request = this.Bind<ImageRequest>();

                

                var uploadResult = await _fileUploadHandler.HandleUpload(request.File.Name, request.File.Value);
                var job = new ImageProcessingJob
                {
                    SourceId = uploadResult.Identifier
                };
                var job2 = new ImageUploadJob
                {
                    ImageId = uploadResult.Identifier
                };

                // await _messageRepository.SendImageProcessingJob(job);
                await _messageRepository.SendUploadJob(job2);

                return HttpStatusCode.OK;

            });


        }
    }
}
