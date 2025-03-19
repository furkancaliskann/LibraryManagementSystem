using Business.Dtos.Fine;
using FluentValidation;

namespace Business.Validators.Fine
{
    public class AddFineDtoValidator : AbstractValidator<AddFineDto>
    {
        public AddFineDtoValidator() 
        {
            RuleFor(x => x.LoanId)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.Paid)
                .NotNull().WithMessage("Paid cannot be null");
        }
    }
}
