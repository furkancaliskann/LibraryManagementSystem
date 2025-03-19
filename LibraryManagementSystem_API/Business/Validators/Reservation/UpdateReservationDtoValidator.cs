using Business.Dtos.Reservation;
using FluentValidation;

namespace Business.Validators.Reservation
{
    public class UpdateReservationDtoValidator : AbstractValidator<UpdateReservationDto>
    {
        public UpdateReservationDtoValidator() 
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
