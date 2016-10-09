using System;
using EasyNetQ;
using FP.DevSpace2016.PicFlow.Contracts.FileHandler;
using FP.DevSpace2016.PicFlow.WebApp.Modules;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;

namespace FP.DevSpace2016.PicFlow.WebApp
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("css", "css"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("img", "img"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("font", "font"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("js", "js"));
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            container.Register<IBus>(RabbitHutch.CreateBus("host=localhost"));
            //var authRepo = new AuthenticationRepository(bus);
            container.Register<AuthenticationRepository>().AsSingleton();
            
            container.Register<IFileHandler, MongoDbFileHandler>(new MongoDbFileHandler("mongodb://localhost"));
            base.ApplicationStartup(container, pipelines);
        }

        private IBus CreateBus(TinyIoCContainer tinyIoCContainer, NamedParameterOverloads namedParameterOverloads)
        {
            return RabbitHutch.CreateBus("host=localhost");
        }
    }
}
