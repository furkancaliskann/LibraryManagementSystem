using Entities.Abstract;

namespace Entities.Concrete
{
    public class Loan : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public int BookCopyId { get; set; }
        public required BookCopy BookCopy { get; set; }
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
