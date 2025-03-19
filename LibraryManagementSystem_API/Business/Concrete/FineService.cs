using AutoMapper;
using Business.Abstract;
using Business.Dtos.Fine;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class FineService : IFineService
    {
        private readonly IFineRepository _fineRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddFineDto> _addFineDtoValidator;
        private readonly IValidator<UpdateFineDto> _updateFineDtoValidator;
        private readonly ILoanService _loanService;

        public FineService(IFineRepository fineRepository, IMapper mapper,
           IValidator<AddFineDto> addFineDtoValidator, IValidator<UpdateFineDto> updateFineDtoValidator,
           ILoanService loanService)
        {
            _fineRepository = fineRepository;
            _mapper = mapper;
            _addFineDtoValidator = addFineDtoValidator;
            _updateFineDtoValidator = updateFineDtoValidator;
            _loanService = loanService;
        }

        public async Task<Result<IEnumerable<Fine>>> GetAllAsync()
        {
            var fines = await _fineRepository.GetAllAsync();
            return Result<IEnumerable<Fine>>.SuccessResultWithData(fines);
        }

        public async Task<Result<IEnumerable<Fine>>> GetWithoutDeletedAsync()
        {
            var fines = await _fineRepository.GetWithoutDeletedAsync();
            return Result<IEnumerable<Fine>>.SuccessResultWithData(fines);
        }

        public async Task<Result<Fine>> GetByIdAsync(int id)
        {
            var fine = await _fineRepository.GetByIdAsync(id);
            if (fine == null)
                return Result<Fine>.FailedResult("Fine not found!", ResultCodes.NotFound);

            return Result<Fine>.SuccessResultWithData(fine);
        }

        public async Task<Result<bool>> AddAsync(string? userRole, AddFineDto addFineDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can add fine!", ResultCodes.Forbidden);

            var checkLoan = await _loanService.GetByIdAsync(addFineDto.LoanId);

            if (checkLoan.Data == null)
                return Result<bool>.FailedResult("Loan not found!", ResultCodes.BadRequest);

            var validatorResult = _addFineDtoValidator.Validate(addFineDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var mappedFine = _mapper.Map<Fine>(addFineDto);

            await _fineRepository.AddAsync(mappedFine);
            var result = await _fineRepository.SaveChangesAsync();

            if (!result)
                return Result<bool>.FailedResult("An error occurred while adding the fine!", ResultCodes.ServerError);

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> UpdateAsync(string? userRole, int fineId, UpdateFineDto updateFineDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can update fines!", ResultCodes.Forbidden);

            var validatorResult = _updateFineDtoValidator.Validate(updateFineDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingFine = (await GetByIdAsync(fineId)).Data;

            if (existingFine == null)
                return Result<bool>.FailedResult("Fine not found!", ResultCodes.NotFound);

            _mapper.Map(updateFineDto, existingFine);

            _fineRepository.Update(existingFine);
            await _fineRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> DeleteAsync(string? userRole, int id)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can delete fines!", ResultCodes.Forbidden);

            var fine = (await GetByIdAsync(id)).Data;

            if (fine == null)
                return Result<bool>.FailedResult("Fine not found", ResultCodes.NotFound);

            fine.IsDeleted = true;

            _fineRepository.Update(fine);
            await _fineRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }
    }
}
