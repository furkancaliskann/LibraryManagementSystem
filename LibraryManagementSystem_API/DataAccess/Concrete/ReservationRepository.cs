using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
