using api_fullstack_challenge.Models.Models;
using api_fullstack_challenge.Models.Models.Enum;
using api_fullstack_challenge.Repository.Repository.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace api_fullstack_challenge.Repository.Repository.Implementation
{
    public class LogRepository : ILogRepository
    {
        private static IMongoCollection<Log> Collection => ContextMongo.Database.GetCollection<Log>("logs");
        public void CreateLog(string message, ELogType type)
        {
            var log = new Log
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Message = message,
                Data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                LogType = type
            };

            Collection.InsertOne(log);
        }

        public List<Log> GetSyncLogs()
        {
            return Collection.Find(log => log.LogType == ELogType.Sync).ToList();
        }

        public List<Log> GetDeleteLogs()
        {
            return Collection.Find(log => log.LogType == ELogType.Delete).ToList();
        }
    }
}
