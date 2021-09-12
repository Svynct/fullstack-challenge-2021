using api_fullstack_challenge.Models.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace api_fullstack_challenge.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public long code { get; set; }
        public string barcode { get; set; }
        public EStatus status { get; set; }
        public string url { get; set; }
        public string product_name { get; set; }
        public string quantity { get; set; }
        public string categories { get; set; }
        public string packaging { get; set; }
        public string brands { get; set; }
        public string image_url { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? imported_t { get; set; }
    }
}
