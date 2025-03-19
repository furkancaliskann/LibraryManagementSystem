using AutoMapper;
using Business.Abstract;
using Business.Dtos.Reservation;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddReservationDto> _addReservationDtoValidator;
        private readonly IValidator<UpdateReservationDto> _updateReservationDtoValidator;
        private readonly IUserService _userService;
        private readonly IBookCopyService _bookCopyService;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper,
           IValidator<AddReservationDto> addReservationDtoValidator, IValidator<UpdateReservationDto> updateReservationDtoValidator,
           IUserService userService, IBookCopyService bookCopyService)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _addReservationDtoValidator = addReservationDtoValidator;
            _updateReservationDtoValidator = updateReservationDtoValidator;
            _userService = userService;
            _bookCopyService = bookCopyService;
        }

        public async Task<Result<IEnumerable<Reservation>>> GetAllAsync()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return Result<IEnumerable<Reservation>>.SuccessResultWithData(reservations);
        }

        public async Task<Result<IEnumerable<Reservation>>> GetWithoutDeletedAsync()
        {
            var reservations = await _reservationRepository.GetWithoutDeletedAsync();
            return Result<IEnumerable<Reservation>>.SuccessResultWithData(reservations);
        }

        public async Task<Result<Reservation>> GetByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
                return Result<Reservation>.FailedResult("Reservation not found!", ResultCodes.NotFound);

            return Result<Reservation>.SuccessResultWithData(reservation);
        }

        public async Task<Result<bool>> AddAsync(string? userRole, AddReservationDto addReservationDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can add reservation!", ResultCodes.Forbidden);

            var checkUser = await _userService.GetByIdAsync(addReservationDto.UserId);

            if (checkUser.Data == null)
                return Result<bool>.FailedResult("User not found!", ResultCodes.BadRequest);

            var checkBookCopy = await _bookCopyService.GetByIdAsync(addReservationDto.BookCopyId);

            if (checkBookCopy.Data == null)
                return Result<bool>.FailedResult("Book Copy not found!", ResultCodes.BadRequest);

            var validatorResult = _addReservationDtoValidator.Validate(addReservationDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var mappedReservation = _mapper.Map<Reservation>(addReservationDto);

            await _reservationRepository.AddAsync(mappedReservation);
            var result = await _reservationRepository.SaveChangesAsync();

            if (!result)
                return Result<bool>.FailedResult("An error occurred while adding the reservation!", ResultCodes.ServerError);

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> UpdateAsync(string? userRole, int reservationId, UpdateReservationDto updateReservationDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can update reservations!", ResultCodes.Forbidden);

            var validatorResult = _updateReservationDtoValidator.Validate(updateReservationDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingReservation = (await GetByIdAsync(reservationId)).Data;

            if (existingReservation == null)
                return Result<bool>.FailedResult("Reservation not found!", ResultCodes.NotFound);

            _mapper.Map(updateReservationDto, existingReservation);

            _reservationRepository.Update(existingReservation);
            await _reservationRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> DeleteAsync(string? userRole, int id)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can delete reservations!", ResultCodes.Forbidden);

            var reservation = (await GetByIdAsync(id)).Data;

            if (reservation == null)
                return Result<bool>.FailedResult("Reservation not found", ResultCodes.NotFound);

            reservation.IsDeleted = true;

            _reservationRepository.Update(reservation);
            await _reservationRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }
    }
}
