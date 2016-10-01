using Nancy;

namespace FP.DevSpace2016.Logging.WebLogger
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Hello Developer Open Space 2016");
        }
    }
}
