using MongoDB.Driver;

namespace api_fullstack_challenge.Repository
{
    public static class ContextMongo
    {
        public static IMongoDatabase Database { get; set; }
    }
}
