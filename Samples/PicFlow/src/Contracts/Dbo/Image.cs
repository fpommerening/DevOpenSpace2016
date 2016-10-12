using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP.DevSpace2016.PicFlow.Contracts.Dbo
{
    public class Image
    {
        public Guid Id { get; set; }

        public Byte[] Data { get; set; }

        public int Resolution { get; set; }
    }
}
