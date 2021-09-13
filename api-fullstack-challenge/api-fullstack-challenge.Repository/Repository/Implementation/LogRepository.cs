using api_fullstack_challenge.Models.Models;
using api_fullstack_challenge.Repository.Repository.Interface;
using api_fullstack_challenge.Util;
using MongoDB.Driver;
using System;

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
                Data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            };

            Collection.InsertOne(log);
        }
    }
}
