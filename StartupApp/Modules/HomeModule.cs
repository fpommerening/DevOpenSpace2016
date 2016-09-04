using Nancy;

namespace StartupApp.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hallo World";

        }
    }
}
