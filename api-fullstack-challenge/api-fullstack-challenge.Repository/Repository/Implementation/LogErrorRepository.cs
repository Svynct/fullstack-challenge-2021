using api_fullstack_challenge.Models.Models;
using api_fullstack_challenge.Models.Models.Enum;
using api_fullstack_challenge.Repository.Repository.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace api_fullstack_challenge.Repository.Repository.Implementation
{
    public class LogErrorRepository : ILogsErrorRepository
    {
        private static IMongoCollection<LogError> Collection => ContextMongo.Database.GetCollection<LogError>("logsError");

        public void CreateLog(string title, string innerEx, string message)
        {
            var log = new LogError
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Title = title,
                Message = message,
                InnerException = innerEx,
                Data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                LogType = ELogType.Error
            };

            Collection.InsertOne(log);
        }

        public List<LogError> GetErrorLogs()
        {
            return Collection.Find(log => log.LogType == ELogType.Error).ToList();
        }
    }
}
