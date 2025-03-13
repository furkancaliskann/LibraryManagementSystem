using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        public LogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
