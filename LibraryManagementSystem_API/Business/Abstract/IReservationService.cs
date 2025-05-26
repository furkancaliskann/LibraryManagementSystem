using Business.Dtos.Reservation;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IReservationService
    {
        Task<Result<IEnumerable<Reservation>>> GetAllAsync();
        Task<Result<IEnumerable<Reservation>>> GetWithoutDeletedAsync();
        Task<Result<Reservation>> GetByIdAsync(int id);
        Task<Result<bool>> AddAsync(string? userRole, int? userId, AddReservationDto addReservationDto);
        Task<Result<bool>> UpdateAsync(string? userRole, int reservationId, UpdateReservationDto updateReservationDto);
        Task<Result<bool>> DeleteAsync(string? userRole, int id);
    }
}
