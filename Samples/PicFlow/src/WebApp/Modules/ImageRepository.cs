﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.Contracts.Dbo;
using Marten;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class ImageRepository
    {
        private readonly string _dbConnectionString;
        public ImageRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public async Task<List<Models.ProcessingJob>> GetProcessingJobs(Guid userId)
        {
            var store = DocumentStore.For(_dbConnectionString);
            using (var session = store.LightweightSession())
            {
                var user = await session.Query<User>().Where(x => x.Id == userId).FirstAsync();

                var result = new List<Models.ProcessingJob>();

                var processingJobs = await session.Query<ProcessingJob>()
                    .Where(x => x.UserId == user.Id).ToListAsync();


                foreach (var job in processingJobs)
                {
                    var model = new Models.ProcessingJob
                    {
                        JobId = job.Id,
                        Message = job.Message,
                        Timestamp = job.Timestamp,
                        Filename = job.Filename

                    };

                    foreach (var img in job.Images)
                    {
                        switch (img.Resolution)
                        {
                            case 2:
                                model.CalcRes2 = true;
                                model.IdRes2 = img.Id;
                                break;
                            case 3:
                                model.CalcRes3 = true;
                                model.IdRes3 = img.Id;
                                break;

                            case 6:
                                model.CalcRes6 = true;
                                model.IdRes6 = img.Id;
                                break;

                            case 12:
                                model.CalcRes12 = true;
                                model.IdRes12 = img.Id;
                                break;
                        }
                    }

                    result.Add(model);
                }

                return result;

            }
        }
    }
}
