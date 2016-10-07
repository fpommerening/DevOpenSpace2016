using System.ComponentModel.DataAnnotations;
using FP.DevSpace2016.PicFlow.ExternalApp.Data;
using MongoDB.Driver;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;

namespace FP.DevSpace2016.PicFlow.ExternalApp
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
            container.Register<EntryRepository>(new EntryRepository("mongodb://localhost"));
            base.ApplicationStartup(container, pipelines);
        }
    }
}
