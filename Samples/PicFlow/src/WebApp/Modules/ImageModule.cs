using FP.DevSpace2016.PicFlow.Contracts.FileHandler;
using FP.DevSpace2016.PicFlow.WebApp.Models;
using Nancy;
using Nancy.ModelBinding;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class ImageModule : NancyModule
    {
        private readonly IFileHandler _fileUploadHandler;
        private readonly MessageRepository _messageRepository;

        public ImageModule(IFileHandler fileUploadHandler)
        {
            _fileUploadHandler = fileUploadHandler;
            _messageRepository = new MessageRepository();

            Get("/", args => View["ImageRequest"]);


            Post("/imagerequest", async args =>
            {
                var request = this.Bind<ImageRequest>();

                var uploadResult = await _fileUploadHandler.HandleUpload(request.File.Name, request.File.Value);
                var job = new Contracts.ImageProcessingJob
                {
                    SourceId = uploadResult.Identifier
                };
                var job2 = new Contracts.ImageUploadJob
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
