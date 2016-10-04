using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.Contracts.FileHandler;

using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace FP.DevSpace2016.PicFlow.WebApp
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            container.Register<IFileHandler, MongoDbFileHandler>(new MongoDbFileHandler("mongodb://localhost"));
            base.ApplicationStartup(container, pipelines);
        }
    }
}
