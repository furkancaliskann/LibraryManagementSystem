using Business.Dtos.BookCopy;
using FluentValidation;

namespace Business.Validators.BookCopy
{
    public class UpdateBookCopyDtoValidator : AbstractValidator<UpdateBookCopyDto>
    {
        public UpdateBookCopyDtoValidator() 
        {
            RuleFor(x => x.CopyNumber)
                    .NotEmpty().WithMessage("CopyNumber cannot be empty!");

            RuleFor(x => x.Status)
                    .NotEmpty().WithMessage("Status cannot be empty!");

            RuleFor(x => x.ShelfLocation)
                    .NotEmpty().WithMessage("ShelfLocation cannot be empty!");
        }
    }
}
