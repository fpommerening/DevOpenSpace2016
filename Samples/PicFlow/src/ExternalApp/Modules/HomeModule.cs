using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.ExternalApp.Data;
using FP.DevSpace2016.PicFlow.ExternalApp.Models;
using Nancy;

namespace FP.DevSpace2016.PicFlow.ExternalApp.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule(EntryRepository repo)
        {
            Get("/", async args =>
            {

                var model = new ImageItems
                {
                    CurrentStartIndex = 1,
                    CurrentEndIndex = 20,
                };

                var count = await repo.GetEntriesCount();

                if (count > model.CurrentEndIndex)
                {
                    model.NextStartIndex = 21;
                    model.NextEndIndex = 40;
                }

                foreach (var entry in await repo.GetEntries(model.CurrentStartIndex, model.CurrentEndIndex))
                {
                    var imageItem = new ImageItem
                    {
                        Id = entry.Id.ToString()
                    };

                    model.Entries.Add(imageItem);
                }

                return View["Home", model];
            });

            Get("/{start}/{end}", async args =>
            {
                int start = args.start;
                int end = args.end;

                var model = new ImageItems
                {
                    CurrentStartIndex = start,
                    CurrentEndIndex = end
                };

                if (start > 21)
                {
                    model.PreviousStartIndex = start - 20;
                    model.PreviousEndIndex = start - 1;
                }
                else if(start > 1)
                {
                    model.PreviousStartIndex = 1;
                    model.PreviousEndIndex = start - 1;
                }

                var count = await repo.GetEntriesCount();

                if (count > model.CurrentEndIndex)
                {
                    model.NextStartIndex = end + 1;
                    model.NextEndIndex = end + 20;
                }

                foreach (var entry in await repo.GetEntries(model.CurrentStartIndex, model.CurrentEndIndex))
                {
                    var imageItem = new ImageItem
                    {
                        Id = entry.Id.ToString()
                    };

                    model.Entries.Add(imageItem);
                }

                return View["Home", model];
            });
        }
    }
}
