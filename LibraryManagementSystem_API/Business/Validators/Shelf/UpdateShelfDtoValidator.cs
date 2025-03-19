using Business.Dtos.Shelf;
using FluentValidation;

namespace Business.Validators.Shelf
{
    public class UpdateShelfDtoValidator : AbstractValidator<UpdateShelfDto>
    {
        public UpdateShelfDtoValidator() 
        {
            RuleFor(x => x.Location)
                    .NotEmpty().WithMessage("Name cannot be empty!");
        }
    }
}
