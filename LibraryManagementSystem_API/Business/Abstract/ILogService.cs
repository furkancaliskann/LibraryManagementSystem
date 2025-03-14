using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILogService
    {
        Task<Result<Log>> AddAsync(int? userId, string logMessage);
    }
}
