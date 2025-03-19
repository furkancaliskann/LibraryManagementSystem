﻿namespace Business.Dtos.Fine
{
    public class AddFineDto
    {
        public int LoanId { get; set; }
        public decimal FineAmount { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}
