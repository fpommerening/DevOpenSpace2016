using System;
using System.IO;
using System.Threading.Tasks;
using EasyNetQ;
using FP.DevSpace2016.PicFlow.Contracts.Dto;
using FP.DevSpace2016.PicFlow.Contracts.FileHandler;
using FP.DevSpace2016.PicFlow.Contracts.Messages;
using ImageProcessorCore;

namespace FP.DevSpace2016.PicFlow.ImageProcessor
{
    public class ImageWorker : IDisposable
    {
        private readonly IBus _bus;
        private IDisposable _subscription;

        public ImageWorker(IBus bus)
        {
            _bus = bus;
        }

        public void Init()
        {
            _subscription = _bus.SubscribeAsync<ImageProcessingJob>("ImageProcessor", job => WorkImage(job));
        }

        private async Task WorkImage(ImageProcessingJob job)
        {
            var fileHandler = new MongoDbFileHandler("mongodb://localhost");
            var sourcefile = await fileHandler.GetMessageObject<DtoImage>(job.Id);

            var outputfile = AddOverlay(sourcefile);
            var id = await fileHandler.SaveMessageObject(outputfile);

            foreach (var successor in job.Successors)
            {
                successor.Id = id;
                await _bus.PublishAsync(successor);
            }
        }

        private DtoImage AddOverlay(DtoImage sourcefile)
        {
            var outputfile = new DtoImage();
            using (var inputstream = new MemoryStream(sourcefile.Data))
            using (var overlay = File.OpenRead("Overlays/devspace.png"))
            using (var output = new MemoryStream())
            {
                var imgInput = new Image(inputstream);
                var imgOverlay = new Image(overlay);

                imgInput.Blend(imgOverlay, 80, new Rectangle(20, 20, 445, 445))
                    .Save(output);
                outputfile.Data = output.ToArray();
            }
            return outputfile;
        }

        public void Dispose()
        {
            _subscription?.Dispose();
            _subscription = null;
        }
    }
}
