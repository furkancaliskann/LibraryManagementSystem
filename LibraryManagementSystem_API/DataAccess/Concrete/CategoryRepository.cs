using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
