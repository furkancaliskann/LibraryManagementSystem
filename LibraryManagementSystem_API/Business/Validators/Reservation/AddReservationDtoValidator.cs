using Business.Dtos.Reservation;
using FluentValidation;

namespace Business.Validators.Reservation
{
    public class AddReservationDtoValidator : AbstractValidator<AddReservationDto>
    {
        public AddReservationDtoValidator() 
        {
            RuleFor(x => x.BookCopyId)
                .GreaterThanOrEqualTo(1);
        }
    }
}
