﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FP.DevSpace2016.PicFlow.Contracts.Dto
{
    public class DtoMessage
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("object")]
        public object Object { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
