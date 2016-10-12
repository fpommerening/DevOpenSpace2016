﻿using System;
using System.Collections.Generic;

namespace FP.DevSpace2016.PicFlow.Contracts.Dbo
{
    public class ProcessingJob
    {
        public Guid Id { get; set; }

        public string SourceId { get; set; }

        public Guid UserId { get; set; }

        public string Message { get; set; }

        public List<Image> Images { get; set; }
    }
}