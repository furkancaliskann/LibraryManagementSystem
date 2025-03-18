using Business.Dtos.Publisher;
using FluentValidation;

namespace Business.Validators.Publisher
{
    public class AddPublisherDtoValidator : AbstractValidator<AddPublisherDto>
    {
        public AddPublisherDtoValidator() 
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name cannot be empty!");
        }
    }
}
