namespace Entities.Concrete
{
    public class Loan : BaseEntity
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int BookCopyId { get; set; }
        public BookCopy? BookCopy { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public LoanStatus Status { get; set; }
    }

    public enum LoanStatus
    {
        Borrowed,
        Returned,
        Overdue
    }
}
