using Business.Dtos.Reservation;
using FluentValidation;

namespace Business.Validators.Reservation
{
    public class AddReservationDtoValidator : AbstractValidator<AddReservationDto>
    {
        public AddReservationDtoValidator() 
        {
            RuleFor(x => x.UserId)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.BookCopyId)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.ReservationDate)
                .NotNull().WithMessage("ReservationDate cannot be null!");

            RuleFor(x => x.Status)
                .NotNull().WithMessage("Status cannot be null!");
        }
    }
}
