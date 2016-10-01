using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;

namespace FP.DevSpace2016.PicFlow.WebApp.Models
{
    public class ImageRequest
    {
        public HttpFile File { get; set; }

        public long ContentSize { get; set; }
    }
}
