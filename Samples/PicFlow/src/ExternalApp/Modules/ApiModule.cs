using System;
using System.Linq;
using Nancy;

namespace FP.DevSpace2016.PicFlow.ExternalApp.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule() : base("/api")
        {
            Post("/postimage", args =>
            {
                Console.WriteLine(this.Request.Files.Count());
                return "Hallo Welt";
            });
        }
    }
}
