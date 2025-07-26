﻿using MongoDB.Bson.Serialization.Attributes;

namespace CourseMicroservice.Catalog.Api.Repositories
{
    public class BaseEntity
    {
        [BsonElement("_id")]
        public Guid Id { get; set; }
    }
}
