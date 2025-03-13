using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class FineRepository : GenericRepository<Fine>, IFineRepository
    {
        public FineRepository(AppDbContext context) : base(context)
        {
        }
    }
}
