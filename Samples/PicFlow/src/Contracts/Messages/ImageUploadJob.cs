﻿namespace FP.DevSpace2016.PicFlow.Contracts.Messages
{
    public class ImageUploadJob : ImageJob
    {
        public string User { get; set; }

        public string Message { get; set; }
    }
}
