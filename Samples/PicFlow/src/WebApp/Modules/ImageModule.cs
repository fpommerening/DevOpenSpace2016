using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.WebApp.Handlers;
using FP.DevSpace2016.PicFlow.WebApp.Models;
using Nancy;
using Nancy.ModelBinding;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class ImageModule : NancyModule
    {
        private readonly IFileUploadHandler _fileUploadHandler;
        private readonly MessageRepository _messageRepository;

        public ImageModule(IFileUploadHandler fileUploadHandler)
        {
            _fileUploadHandler = fileUploadHandler;
            _messageRepository = new MessageRepository();

            Get("/", args =>
            {
                return View["ImageRequest"];
            });


            Post("/imagerequest", async args =>
            {
                var request = this.Bind<ImageRequest>();

                var uploadResult = await _fileUploadHandler.HandleUpload(request.File.Name, request.File.Value);
                var job = new Contracts.ImageProcessingJob
                {
                    SourceId = uploadResult.Identifier
                };
                await _messageRepository.SendImageProcessingJob(job);

                return HttpStatusCode.OK;

            });


        }
    }
}
