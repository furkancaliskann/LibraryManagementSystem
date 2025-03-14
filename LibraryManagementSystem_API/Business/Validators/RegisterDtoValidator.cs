using Business.Dtos;
using FluentValidation;

namespace Business.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!");

            RuleFor(x => x.Surname)
               .NotEmpty().WithMessage("Surname cannot be empty!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty!")
                .EmailAddress().WithMessage("Invalid email format!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty!")
                .MinimumLength(3).WithMessage("Password must be at least 3 characters long!");

            RuleFor(x => x.Phone)
               .NotEmpty().WithMessage("Phone cannot be empty!");
        }
    }
}
