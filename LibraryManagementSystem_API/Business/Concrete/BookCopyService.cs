using AutoMapper;
using Business.Abstract;
using Business.Dtos.BookCopy;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class BookCopyService : IBookCopyService
    {
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddBookCopyDto> _addBookCopyDtoValidator;
        private readonly IValidator<UpdateBookCopyDto> _updateBookCopyDtoValidator;
        private readonly IBookService _bookService;

        public BookCopyService(IBookCopyRepository bookCopyRepository, IMapper mapper,
            IValidator<AddBookCopyDto> addBookCopyDtoValidator, IValidator<UpdateBookCopyDto> updateBookCopyDtoValidator,
            IBookService bookService)
        {
            _bookCopyRepository = bookCopyRepository;
            _mapper = mapper;
            _addBookCopyDtoValidator = addBookCopyDtoValidator;
            _updateBookCopyDtoValidator = updateBookCopyDtoValidator;
            _bookService = bookService;
        }

        public async Task<Result<IEnumerable<BookCopy>>> GetAllAsync()
        {
            var bookCopies = await _bookCopyRepository.GetAllAsync();
            return Result<IEnumerable<BookCopy>>.SuccessResultWithData(bookCopies);
        }

        public async Task<Result<IEnumerable<BookCopy>>> GetWithoutDeletedAsync()
        {
            var bookCopies = await _bookCopyRepository.GetWithoutDeletedAsync();
            return Result<IEnumerable<BookCopy>>.SuccessResultWithData(bookCopies);
        }

        public async Task<Result<BookCopy>> GetByIdAsync(int id)
        {
            var bookCopy = await _bookCopyRepository.GetByIdAsync(id);
            if (bookCopy == null)
                return Result<BookCopy>.FailedResult("BookCopy not found!", ResultCodes.NotFound);

            return Result<BookCopy>.SuccessResultWithData(bookCopy);
        }

        public async Task<Result<bool>> AddAsync(string? userRole, AddBookCopyDto addBookCopyDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can add copy of books!", ResultCodes.Forbidden);

            var resultBook = await _bookService.GetByIdAsync(addBookCopyDto.BookId);
            if (resultBook.Data == null)
                return Result<bool>.FailedResult("The specified book was not found. Please check the Book ID!", ResultCodes.NotFound);

            var validatorResult = _addBookCopyDtoValidator.Validate(addBookCopyDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingBookCopy = await _bookCopyRepository.GetWithCopyNumber(addBookCopyDto.CopyNumber);

            if (existingBookCopy != null)
                return Result<bool>.FailedResult("This copy has already been registered!", ResultCodes.Conflict);

            var mappedBookCopy = _mapper.Map<BookCopy>(addBookCopyDto);

            await _bookCopyRepository.AddAsync(mappedBookCopy);
            var result = await _bookCopyRepository.SaveChangesAsync();

            if (!result)
                return Result<bool>.FailedResult("An error occurred while adding the book copy!", ResultCodes.ServerError);

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> UpdateAsync(string? userRole, int bookCopyId, UpdateBookCopyDto updateBookCopyDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can update copy of books!", ResultCodes.Forbidden);

            var resultBook = await _bookService.GetByIdAsync(updateBookCopyDto.BookId);
            if (resultBook.Data == null)
                return Result<bool>.FailedResult("The specified book was not found. Please check the Book ID!", ResultCodes.NotFound);

            var validatorResult = _updateBookCopyDtoValidator.Validate(updateBookCopyDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingBookCopy = await _bookCopyRepository.GetByIdAsync(bookCopyId);

            if (existingBookCopy == null)
                return Result<bool>.FailedResult("Copy not found!", ResultCodes.NotFound);

            _mapper.Map(updateBookCopyDto, existingBookCopy);

            _bookCopyRepository.Update(existingBookCopy);
            await _bookCopyRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> DeleteAsync(string? userRole, int id)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can delete copy of books!", ResultCodes.Forbidden);

            var bookCopy = await _bookCopyRepository.GetByIdAsync(id);

            if (bookCopy == null)
                return Result<bool>.FailedResult("Copy not found", ResultCodes.NotFound);

            bookCopy.IsDeleted = true;

            _bookCopyRepository.Update(bookCopy);
            await _bookCopyRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }
    }
}
