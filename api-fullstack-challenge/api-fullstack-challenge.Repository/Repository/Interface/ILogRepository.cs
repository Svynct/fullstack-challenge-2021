using api_fullstack_challenge.Models.Models;
using api_fullstack_challenge.Models.Models.Enum;
using System.Collections.Generic;

namespace api_fullstack_challenge.Repository.Repository.Interface
{
    public interface ILogRepository
    {
        void CreateLog(string message, ELogType type);
        List<Log> GetSyncLogs();
        List<Log> GetDeleteLogs();
    }
}
