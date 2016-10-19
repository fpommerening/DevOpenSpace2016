using System.IO;
using System.Threading.Tasks;

namespace FP.DevSpace2016.PicFlow.Contracts.FileHandler
{
    public interface IFileHandler
    {
        Task<FileUploadResult> HandleUpload(string fileName, Stream stream);
    }
}
