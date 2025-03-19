using Business.Dtos.Fine;
using FluentValidation;

namespace Business.Validators.Fine
{
    public class UpdateFineDtoValidator : AbstractValidator<UpdateFineDto>
    {
        public UpdateFineDtoValidator() 
        {
            RuleFor(x => x.LoanId)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.Paid)
                .NotNull().WithMessage("Paid cannot be null");
        }
    }
}
