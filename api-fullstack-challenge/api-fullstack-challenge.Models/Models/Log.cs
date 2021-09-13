using api_fullstack_challenge.Models.Models.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_fullstack_challenge.Models.Models
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public ELogType LogType { get; set; }
    }
}
