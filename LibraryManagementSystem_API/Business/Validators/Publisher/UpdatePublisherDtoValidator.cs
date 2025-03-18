using Business.Dtos.Publisher;
using FluentValidation;

namespace Business.Validators.Publisher
{
    public class UpdatePublisherDtoValidator : AbstractValidator<UpdatePublisherDto>
    {
        public UpdatePublisherDtoValidator() 
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name cannot be empty!");
        }
    }
}
