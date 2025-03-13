using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(AppDbContext context) : base(context)
        {
        }
    }
}
