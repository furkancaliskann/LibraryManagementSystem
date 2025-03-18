using Business.Dtos.Category;
using FluentValidation;

namespace Business.Validators.Category
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!");
        }
    }
}
