using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;

namespace FP.DevSpace2016.PicFlow.WebApp.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => View["Home"]);

            Get("/contact", args => View["Contact"]);

            Get("/login", args=> View["Login"]);
        }
    }
}
