using System.Threading.Tasks;

namespace api_fullstack_challenge.Repository.Repository.Interface
{
    public interface ILogRepository
    {
        void CreateLog(string message);
        Task CreateLogAsync(string message);
    }
}
