using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Nancy;

namespace FP.DevSpace2016.PicFlow.ExternalApp
{
    public class ByteArrayResponse : Response
    {
        public ByteArrayResponse(byte[] body, string contentType = null)
        {
            this.ContentType = contentType ?? "application/octet-stream";

            this.Contents = stream =>
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(body);
                }
            };
        }
    }
}
