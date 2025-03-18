using Business.Dtos.Author;
using FluentValidation;

namespace Business.Validators.Author
{
    public class UpdateAuthorDtoValidator : AbstractValidator<UpdateAuthorDto>
    {
        public UpdateAuthorDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!");
        }
    }
}
