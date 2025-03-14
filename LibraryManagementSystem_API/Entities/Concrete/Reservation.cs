namespace Entities.Concrete
{
    public class Reservation : BaseEntity
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int BookCopyId { get; set; }
        public BookCopy? BookCopy { get; set; }
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
