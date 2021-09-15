using api_fullstack_challenge.Models.Models;
using System.Collections.Generic;

namespace api_fullstack_challenge.Repository.Repository.Interface
{
    public interface ILogsErrorRepository
    {
        void CreateLog(string title, string innerEx, string message);
        List<LogError> GetErrorLogs();
    }
}
