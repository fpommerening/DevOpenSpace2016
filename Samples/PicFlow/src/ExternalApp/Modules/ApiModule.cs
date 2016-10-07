using FP.DevSpace2016.PicFlow.ExternalApp.Models;
using Nancy;
using Nancy.ModelBinding;

namespace FP.DevSpace2016.PicFlow.ExternalApp.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule() : base("/api")
        {
            Post("/postimage", args =>
            {
                var apiUpload = this.Bind<ApiUpload>();
                return HttpStatusCode.OK;
            });
        }
    }
}
