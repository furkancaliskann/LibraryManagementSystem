using Entities.Concrete;

namespace Business.Dtos.Loan
{
    public class AddLoanDto
    {
        public int UserId { get; set; }
        public int BookCopyId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public LoanStatus Status { get; set; }
    }
}
