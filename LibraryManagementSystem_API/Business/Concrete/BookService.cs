using AutoMapper;
using Business.Abstract;
using Business.Dtos.Book;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddBookDto> _addBookDtoValidator;
        private readonly IValidator<UpdateBookDto> _updateBookDtoValidator;

        public BookService(IBookRepository bookRepository, IMapper mapper,
            IValidator<AddBookDto> addBookDtoValidator, IValidator<UpdateBookDto> updateBookDtoValidator) 
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _addBookDtoValidator = addBookDtoValidator;
            _updateBookDtoValidator = updateBookDtoValidator;
        }

        public async Task<Result<IEnumerable<Book>>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return Result<IEnumerable<Book>>.SuccessResultWithData(books);
        }

        public async Task<Result<IEnumerable<Book>>> GetWithoutDeletedAsync()
        {
            var books = await _bookRepository.GetWithoutDeletedAsync();
            return Result<IEnumerable<Book>>.SuccessResultWithData(books);
        }

        public async Task<Result<Book>> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                return Result<Book>.FailedResult("Book not found!", ResultCodes.NotFound);

            return Result<Book>.SuccessResultWithData(book);
        }

        public async Task<Result<bool>> AddAsync(string? userRole, AddBookDto addBookDto)
        {
            if (userRole == null || !userRole.Equals("Admin"))
                return Result<bool>.FailedResult("Only admins can add books!", ResultCodes.Forbidden);

            var validatorResult = _addBookDtoValidator.Validate(addBookDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingBook = await _bookRepository.GetByTitleAsync(addBookDto.Title);

            if (existingBook != null)
                return Result<bool>.FailedResult("This book has already been registered!", ResultCodes.Conflict);

            var mappedAuthor = _mapper.Map<Book>(addBookDto);

            await _bookRepository.AddAsync(mappedAuthor);
            var result = await _bookRepository.SaveChangesAsync();

            if (!result)
                return Result<bool>.FailedResult("An error occurred while adding the book!", ResultCodes.ServerError);

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> UpdateAsync(string? userRole, int bookId, UpdateBookDto updateBookDto)
        {
            if (userRole == null || !userRole.Equals("Admin"))
                return Result<bool>.FailedResult("Only admins can update books!", ResultCodes.Forbidden);

            var validatorResult = _updateBookDtoValidator.Validate(updateBookDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingBook = await _bookRepository.GetByIdAsync(bookId);

            if (existingBook == null)
                return Result<bool>.FailedResult("Book not found!", ResultCodes.NotFound);

            _mapper.Map(updateBookDto, existingBook);

            _bookRepository.Update(existingBook);
            await _bookRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> DeleteAsync(string? userRole, int id)
        {
            if (userRole == null || !userRole.Equals("Admin"))
                return Result<bool>.FailedResult("Only admins can delete books!", ResultCodes.Forbidden);

            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                return Result<bool>.FailedResult("Book not found", ResultCodes.NotFound);

            book.IsDeleted = true;

            // TODO: After creating the BookCopy service, mark the book copies of the relevant book as IsDeleted.

            _bookRepository.Update(book);
            await _bookRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }
    }
}
