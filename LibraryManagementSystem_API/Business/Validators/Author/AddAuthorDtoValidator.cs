using Business.Dtos.Author;
using FluentValidation;

namespace Business.Validators.Author
{
    public class AddAuthorDtoValidator : AbstractValidator<AddAuthorDto>
    {
        public AddAuthorDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!");
        }
    }
}
