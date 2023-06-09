﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RPA.AeC.Domain.Entities
{
    public class SearchedResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Title { get; set; }
        public string? Area { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime SeachDate { get; set; } = DateTime.UtcNow;
        public string? SearchTerm { get; set; }
    }
}