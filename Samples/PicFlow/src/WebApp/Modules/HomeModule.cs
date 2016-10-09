using Nancy;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args =>
            {
                var identity = this.Context.CurrentUser;
                if (identity == null)
                {
                    return View["Login"];
                }
                else
                {
                    return View["Home"];
                }
            });

            Get("/contact", args => View["Contact"]);

            Get("/login", args=> View["Login"]);
        }
    }
}
