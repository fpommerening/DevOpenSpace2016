﻿using System.Collections.Generic;

namespace FP.DevSpace2016.PicFlow.Contracts.Messages
{
    public class ImageJob
    {
        public ImageJob()
        {
            Successors = new List<ImageJob>();
        }

        public string Id { get; set; }

        public List<ImageJob> Successors { get; set; }
    }
}
