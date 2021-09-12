using api_fullstack_challenge.Models.Models;
using api_fullstack_challenge.Repository.Repository.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace api_fullstack_challenge.Repository.Repository.Implementation
{
    public class LogRepository : ILogRepository
    {
        private static IMongoCollection<Log> Collection => ContextMongo.Database.GetCollection<Log>("logs");
        public void CreateLog(string message)
        {
            var log = new Log
            {
                Message = message,
                Data = DateTime.Now.ToLocalTime()
            };

            Collection.InsertOne(log);
        }

        public async Task CreateLogAsync(string message)
        {
            var log = new Log
            {
                Message = message,
                Data = DateTime.Now.ToLocalTime()
            };

            await Collection.InsertOneAsync(log);
        }
    }
}
