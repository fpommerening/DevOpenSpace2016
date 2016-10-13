﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.Contracts.Dto;
using FP.DevSpace2016.PicFlow.Contracts.FileHandler;
using FP.DevSpace2016.PicFlow.Contracts.Messages;
using ImageProcessorCore;

namespace FP.DevSpace2016.PicFlow.ImageProcessor
{
    public class ImageWorker : IDisposable
    {
        


        public ImageWorker()
        {

        }

        public void Init()
        {

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
                
                // Nachfolgeprozess starten
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
            var prefix = string.Empty;

            switch (overlayId.ToLowerInvariant())
            {
                case "dos":
                    prefix = "Overlays/DevSpace";
                    break;
                case "sp":
                    prefix = "Overlays/Sparta";
                    break;
                default:
                    throw new NotSupportedException($"the overlay id {overlayId} is not supported");
            }

            if (resolution > 10)
            {
                return File.OpenRead($"{prefix}_10_10.png");
            }
            if (resolution >= 6)
            {
                return File.OpenRead($"{prefix}_7_7.png");
            }
            if (resolution >= 3)
            {
                return File.OpenRead($"{prefix}_5_5.png");
            }
            return File.OpenRead($"{prefix}_3_3.png");
        }

        public void Dispose()
        {
         
        }

        
    }

    
}
