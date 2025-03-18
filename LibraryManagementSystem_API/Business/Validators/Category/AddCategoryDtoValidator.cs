using Business.Dtos.Category;
using FluentValidation;

namespace Business.Validators.Category
{
    public class AddCategoryDtoValidator : AbstractValidator<AddCategoryDto>
    {
        public AddCategoryDtoValidator() 
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name cannot be empty!");
        }
    }
}
