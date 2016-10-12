using System;
using FP.DevSpace2016.PicFlow.WebApp.Models;
using Nancy;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class HomeModule : NancyModule
    {
        public const string DbCnn = "host=localhost;database=devspace;password=leipzig;username=devspace";

        public HomeModule()
        {
            ImageRepository imgRepo = new ImageRepository(DbCnn);

            Get("/", async args =>
            {
                var identity = this.Context.CurrentUser;
                if (identity == null)
                {
                    return View["Login"];
                }
                else
                {
                    var model = new Home {Message = "Herzlich Willkommen"};

                    model.Jobs = await imgRepo.GetProcessingJobs(Guid.Parse(identity.Identity.Name));
                    return View["Home", model];
                }
            });

            Get("/contact", args => View["Contact"]);

            Get("/login", args=> View["Login"]);
        }
    }
}
