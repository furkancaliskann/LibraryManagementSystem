using Entities.Abstract;

namespace Entities.Concrete
{
    public class Reservation : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public int BookCopyId { get; set; }
        public required BookCopy BookCopy { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; }
    }

    public enum ReservationStatus
    {
        Pending,
        Completed,
        Cancelled
    }
}
