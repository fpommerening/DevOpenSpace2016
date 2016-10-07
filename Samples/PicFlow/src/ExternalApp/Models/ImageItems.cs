using System.Collections.Generic;

namespace FP.DevSpace2016.PicFlow.ExternalApp.Models
{
    public class ImageItems
    {
        public int Start { get; set; }

        public int End { get; set; }

        public List<ImageItem> Images { get; set; }
    }
}
