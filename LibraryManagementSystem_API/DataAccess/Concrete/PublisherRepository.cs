using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(AppDbContext context) : base(context)
        {
        }
    }
}
