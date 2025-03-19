using Business.Dtos.Loan;
using FluentValidation;

namespace Business.Validators.Loan
{
    public class UpdateLoanDtoValidator : AbstractValidator<UpdateLoanDto>
    {
        public UpdateLoanDtoValidator() 
        {
            RuleFor(x => x.UserId)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.BookCopyId)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.LoanDate)
                    .NotEmpty().WithMessage("LoanDate cannot be empty!");

            RuleFor(x => x.DueDate)
                   .NotEmpty().WithMessage("DueDate cannot be empty!");

            RuleFor(x => x.Status)
                   .NotEmpty().WithMessage("Status cannot be empty!");
        }
    }
}
