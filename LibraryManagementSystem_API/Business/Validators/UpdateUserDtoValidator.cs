using Business.Dtos;
using FluentValidation;

namespace Business.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!");

            RuleFor(x => x.Surname)
               .NotEmpty().WithMessage("Surname cannot be empty!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty!")
                .EmailAddress().WithMessage("Invalid email format!");

            RuleFor(x => x.Phone)
               .NotEmpty().WithMessage("Phone cannot be empty!");
        }
    }
}
