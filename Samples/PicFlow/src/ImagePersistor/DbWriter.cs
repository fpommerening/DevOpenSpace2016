using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.Contracts.Dbo;
using FP.DevSpace2016.PicFlow.Contracts.Dto;
using FP.DevSpace2016.PicFlow.Contracts.FileHandler;
using Marten;

namespace FP.DevSpace2016.PicFlow.ImagePersistor
{
    public class DbWriter
    {
        private readonly string _mongoConnectionString;
        private readonly string _dbConnectionString;
        public DbWriter(string mongoConnectionString, string dbConnectionString)
        {
            _mongoConnectionString = mongoConnectionString;
            _dbConnectionString = dbConnectionString;
        }

        public async Task PersistImage(string imageId, Guid userId, string sourceId, string message)
        {
            var handler = new MongoDbFileHandler(_mongoConnectionString);
            var image = await handler.GetMessageObject<DtoImage>(imageId);

            var store = DocumentStore.For(_dbConnectionString);
            using (var session = store.LightweightSession())
            {
                var user = await session.Query<User>().Where(x => x.Id == userId).FirstAsync();

                var processingJob = await session.Query<ProcessingJob>().Where(x => x.UserId == user.Id && x.SourceId == sourceId).FirstOrDefaultAsync();

                if (processingJob == null)
                {
                    processingJob = new ProcessingJob
                    {
                        Message = message,
                        UserId = user.Id,
                        SourceId = sourceId,
                        Images = new List<Image>()
                    };
                }
                var dbImage = new Image {Data = image.Data, Filename = image.FileName};
                processingJob.Images.Add(dbImage);
                session.Store(processingJob);
                session.SaveChanges();
            }
        }
    }
}
