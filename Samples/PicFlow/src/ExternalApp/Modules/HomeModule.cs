using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.ExternalApp.Models;
using Nancy;

namespace FP.DevSpace2016.PicFlow.ExternalApp.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", async args =>
            {

                var model = new ImageItems
                {
                    Start = 1,
                    End = 20
                };


                return View["Home", model];
            });

            Get("/{start}/{end}", async args =>
            {
                int? start = args.start;
                int? end = args.end;

                var model = new ImageItems
                {
                    Start = start.GetValueOrDefault(1),
                    End = end.GetValueOrDefault(20)
                };


                return View["Home", model];
            });
        }
    }
}
