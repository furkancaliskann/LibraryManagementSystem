namespace Entities.Concrete
{
    public class Fine : BaseEntity
    {
        public int LoanId { get; set; }
        public required Loan Loan { get; set; }
        public decimal? FineAmount { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}
