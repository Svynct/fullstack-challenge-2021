using api_fullstack_challenge.Models.Models;
using api_fullstack_challenge.Models.Models.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_fullstack_challenge.Repository.Repository.Interface
{
    public interface ILogRepository
    {
        void CreateLog(string message, ELogType type);
        public List<Log> GetSyncLogs();
        public List<Log> GetDeleteLogs();
    }
}
