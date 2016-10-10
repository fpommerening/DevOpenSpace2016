using System;
using System.IO;
using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.Contracts;
using FP.DevSpace2016.PicFlow.Contracts.Dto;
using FP.DevSpace2016.PicFlow.Contracts.FileHandler;

namespace FP.DevSpace2016.PicFlow.ImagePersistor
{
    public class FileWriter
    {
        private readonly string _mongoConnectionString;
        public FileWriter(string mongoConnectionString)
        {
            _mongoConnectionString = mongoConnectionString;
        }

        public async Task PersistImage(string id)
        {
            var handler = new MongoDbFileHandler(_mongoConnectionString);
            var image = await handler.GetMessageObject<DtoImage>(id);

            using (var sourceStream = File.Open($"{Guid.NewGuid()}.png", FileMode.OpenOrCreate))
            {
                sourceStream.Seek(0, SeekOrigin.End);
                await sourceStream.WriteAsync(image.Data, 0, image.Data.Length);
            }
        }
    }
}
