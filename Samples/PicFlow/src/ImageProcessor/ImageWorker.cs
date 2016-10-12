﻿using System;
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

            var outputfile = AddOverlay(sourcefile, job.Overlay, job.Resolution);
            var id = await fileHandler.SaveMessageObject(outputfile);

            foreach (var successor in job.Successors)
            {
                successor.Id = id;
                var saveJob = successor as ImageSaveJob;
                if (saveJob != null)
                {
                    await _bus.PublishAsync(saveJob);
                }
                var uploadJob = successor as ImageUploadJob;
                if (uploadJob != null)
                {
                    await _bus.PublishAsync(uploadJob);
                }
            }
        }



        private DtoImage AddOverlay(DtoImage sourcefile, string overlayId, int resolution)
        {
            var outputfile = new DtoImage();
            using (var inputstream = new MemoryStream(sourcefile.Data))
            using (var overlay = GetOverlay(overlayId, resolution))
            using (var output = new MemoryStream())
            {
                var imgInput = new Image(inputstream);
                var imgOverlay = new Image(overlay);

                int height = Convert.ToInt32(Math.Sqrt((resolution*1000000)/(((double) imgInput.Height)* (double)imgInput.Width))* (double)imgInput.Height);
                int width = Convert.ToInt32(Math.Sqrt((resolution * 1000000) / (((double)imgInput.Height) * (double)imgInput.Width)) * (double)imgInput.Width);

                int overlaysize = Convert.ToInt32((double) width*0.2);
                int padding = overlaysize + (resolution * 10);

                imgInput.Resize(width, height)
                    .Blend(imgOverlay.Resize(overlaysize, overlaysize).Pad(padding, padding), 80)
                    .Save(output);
                outputfile.Data = output.ToArray();
                outputfile.FileName = sourcefile.FileName;
            }
            return outputfile;
        }

        private FileStream GetOverlay(string overlayId, int resolution)
        {
            if (resolution > 10)
            {
                return File.OpenRead("Overlays/DevSpace_10_10.png");
            }
            if (resolution >= 6)
            {
                return File.OpenRead("Overlays/DevSpace_7_7.png");
            }
            if (resolution >= 3)
            {
                return File.OpenRead("Overlays/DevSpace_5_5.png");
            }
            return File.OpenRead("Overlays/DevSpace_3_3.png");
        }

        public void Dispose()
        {
            _subscription?.Dispose();
            _subscription = null;
        }

        
    }

    
}