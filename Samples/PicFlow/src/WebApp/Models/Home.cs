using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP.DevSpace2016.PicFlow.WebApp.Models
{
    public class Home
    {
        public Home()
        {
            Jobs = new List<ProcessingJob>();
        }

        public string Message { get; set; }

        public List<ProcessingJob> Jobs { get; set; }
    }
}
