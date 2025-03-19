using Business.Dtos.Shelf;
using FluentValidation;

namespace Business.Validators.Shelf
{
    public class AddShelfDtoValidator : AbstractValidator<AddShelfDto>
    {
        public AddShelfDtoValidator() 
        {
            RuleFor(x => x.Location)
                    .NotEmpty().WithMessage("Name cannot be empty!");
        }
    }
}
