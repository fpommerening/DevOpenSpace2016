using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FP.DevSpace2016.PicFlow.WebApp.Handlers
{
    public interface IFileUploadHandler
    {
        Task<FileUploadResult> HandleUpload(string fileName, Stream stream);
    }
}
