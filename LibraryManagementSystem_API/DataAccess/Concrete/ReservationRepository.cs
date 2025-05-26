using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore; // Include için

public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        return await _context.Reservations
            .Include(r => r.User)
            .Include(r => r.BookCopy)
                .ThenInclude(bc => bc.Book)
            .ToListAsync();
    }

    public override async Task<IEnumerable<Reservation>> GetWithoutDeletedAsync()
    {
        return await _context.Reservations
            .Where(r => !r.IsDeleted)
            .Include(r => r.User)
            .Include(r => r.BookCopy)
                .ThenInclude(bc => bc.Book)
            .ToListAsync();
    }
}
