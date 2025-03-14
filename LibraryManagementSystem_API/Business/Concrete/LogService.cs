using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly IUserService _userService;

        public LogService(ILogRepository logRepository, IUserService userService) 
        {
            _logRepository = logRepository;
            _userService = userService;
        }

        public async Task<Result<Log>> AddAsync(int? userId, string logMessage)
        {
            if(userId != null)
            {
                var result = await _userService.GetByIdAsync(userId.Value);

                if (!result.IsSuccess || result.Data == null)
                    return Result<Log>.FailedResult(result.ErrorMessage, result.StatusCode);
            }            

            var log = new Log
            {
                Action = logMessage,
            };

            await _logRepository.AddAsync(log);
            await _logRepository.SaveChangesAsync();

            return Result<Log>.SuccessResult();
        }
    }
}
