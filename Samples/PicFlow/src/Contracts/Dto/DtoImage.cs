using System;

namespace FP.DevSpace2016.PicFlow.Contracts.Dto
{
    public class DtoImage
    {
        public byte[] Data { get; set; }

        public string FileName { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
