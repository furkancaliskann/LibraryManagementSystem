using Business.Dtos.Book;
using FluentValidation;

namespace Business.Validators.Book
{
    public class AddBookDtoValidator : AbstractValidator<AddBookDto>
    {
        public AddBookDtoValidator() 
        {
            RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Title cannot be empty!");

            RuleFor(x => x.AuthorId)
                    .GreaterThanOrEqualTo(1);

            RuleFor(x => x.PublisherId)
                    .GreaterThanOrEqualTo(1);

            RuleFor(x => x.CategoryId)
                    .GreaterThanOrEqualTo(1);

            RuleFor(x => x.ISBN)
                    .NotEmpty().WithMessage("ISBN cannot be empty!");

            RuleFor(x => x.PublicationDate)
                    .NotEmpty().WithMessage("Publication date cannot be empty!");
        }    
    }
}
