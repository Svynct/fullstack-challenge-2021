using MongoDB.Bson.Serialization.Attributes;

namespace api_fullstack_challenge.Models.Models
{
    [BsonIgnoreExtraElements]
    public class LogError : Log
    {
        public string Title { get; set; }
        public string InnerException { get; set; }
    }
}
