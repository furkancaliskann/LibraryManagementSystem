using AutoMapper;
using Business.Abstract;
using Business.Dtos.Loan;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddLoanDto> _addLoanDtoValidator;
        private readonly IValidator<UpdateLoanDto> _updateLoanDtoValidator;
        private readonly IUserService _userService;
        private readonly IBookCopyService _bookCopyService;

        public LoanService(ILoanRepository loanRepository, IMapper mapper,
           IValidator<AddLoanDto> addLoanDtoValidator, IValidator<UpdateLoanDto> updateLoanDtoValidator,
           IUserService userService, IBookCopyService bookCopyService)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
            _addLoanDtoValidator = addLoanDtoValidator;
            _updateLoanDtoValidator = updateLoanDtoValidator;
            _userService = userService;
            _bookCopyService = bookCopyService;
        }

        public async Task<Result<IEnumerable<Loan>>> GetAllAsync()
        {
            var loans = await _loanRepository.GetAllAsync();
            return Result<IEnumerable<Loan>>.SuccessResultWithData(loans);
        }

        public async Task<Result<IEnumerable<Loan>>> GetWithoutDeletedAsync()
        {
            var loans = await _loanRepository.GetWithoutDeletedAsync();
            return Result<IEnumerable<Loan>>.SuccessResultWithData(loans);
        }

        public async Task<Result<Loan>> GetByIdAsync(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            if (loan == null)
                return Result<Loan>.FailedResult("Loan not found!", ResultCodes.NotFound);

            return Result<Loan>.SuccessResultWithData(loan);
        }

        public async Task<Result<bool>> AddAsync(string? userRole, AddLoanDto addLoanDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can add loan!", ResultCodes.Forbidden);

            var checkUser = await _userService.GetByIdAsync(addLoanDto.UserId);

            if (checkUser.Data == null)
                return Result<bool>.FailedResult("User not found!", ResultCodes.BadRequest);

            var checkBookCopy = await _bookCopyService.GetByIdAsync(addLoanDto.BookCopyId);

            if (checkBookCopy.Data == null)
                return Result<bool>.FailedResult("Book Copy not found!", ResultCodes.BadRequest);

            var validatorResult = _addLoanDtoValidator.Validate(addLoanDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var mappedLoan = _mapper.Map<Loan>(addLoanDto);

            await _loanRepository.AddAsync(mappedLoan);
            var result = await _loanRepository.SaveChangesAsync();

            if (!result)
                return Result<bool>.FailedResult("An error occurred while adding the loan!", ResultCodes.ServerError);

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> UpdateAsync(string? userRole, int loanId, UpdateLoanDto updateLoanDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can update loans!", ResultCodes.Forbidden);

            var validatorResult = _updateLoanDtoValidator.Validate(updateLoanDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingLoan = await _loanRepository.GetByIdAsync(loanId);

            if (existingLoan == null)
                return Result<bool>.FailedResult("Loan not found!", ResultCodes.NotFound);

            _mapper.Map(updateLoanDto, existingLoan);

            _loanRepository.Update(existingLoan);
            await _loanRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> DeleteAsync(string? userRole, int id)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can delete loans!", ResultCodes.Forbidden);

            var loan = await _loanRepository.GetByIdAsync(id);

            if (loan == null)
                return Result<bool>.FailedResult("Loan not found", ResultCodes.NotFound);

            loan.IsDeleted = true;

            _loanRepository.Update(loan);
            await _loanRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }
    }
}
