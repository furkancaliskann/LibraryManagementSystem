using Business.Dtos.Auth;
using FluentValidation;

namespace Business.Validators.Auth
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty!")
                .EmailAddress().WithMessage("Invalid email format!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty!")
                .MinimumLength(3).WithMessage("Password must be at least 3 characters long!");
        }
    }
}
