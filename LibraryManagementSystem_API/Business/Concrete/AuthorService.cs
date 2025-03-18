using AutoMapper;
using Business.Abstract;
using Business.Dtos.Author;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddAuthorDto> _addAuthorDtoValidator;
        private readonly IValidator<UpdateAuthorDto> _updateAuthorDtoValidator;

        public AuthorService (IAuthorRepository authorRepository, IMapper mapper,
            IValidator<AddAuthorDto> addAuthorDtoValidator, IValidator<UpdateAuthorDto> updateAuthorDtoValidator)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _addAuthorDtoValidator = addAuthorDtoValidator;
            _updateAuthorDtoValidator = updateAuthorDtoValidator;
        }

        public async Task<Result<IEnumerable<Author>>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return Result<IEnumerable<Author>>.SuccessResultWithData(authors);
        }

        public async Task<Result<IEnumerable<Author>>> GetWithoutDeletedAsync()
        {
            var authors = await _authorRepository.GetWithoutDeletedAsync();
            return Result<IEnumerable<Author>>.SuccessResultWithData(authors);
        }

        public async Task<Result<Author>> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                return Result<Author>.FailedResult("Author not found!", ResultCodes.NotFound);

            return Result<Author>.SuccessResultWithData(author);
        }

        public async Task<Result<bool>> AddAsync(string? userRole, AddAuthorDto addAuthorDto)
        {
            if (userRole == null || !userRole.Equals("Admin"))
                return Result<bool>.FailedResult("Only admins can add authors!", ResultCodes.Forbidden);

            var validatorResult = _addAuthorDtoValidator.Validate(addAuthorDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingAuthor = await _authorRepository.GetByNameAsync(addAuthorDto.Name);

            if (existingAuthor != null)
                return Result<bool>.FailedResult("This author has already been registered!", ResultCodes.Conflict);

            var mappedAuthor = _mapper.Map<Author>(addAuthorDto);

            await _authorRepository.AddAsync(mappedAuthor);
            var result = await _authorRepository.SaveChangesAsync();

            if (!result)
                return Result<bool>.FailedResult("An error occurred while adding the author!", ResultCodes.ServerError);

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> UpdateAsync(string? userRole, int authorId, UpdateAuthorDto updateAuthorDto)
        {
            if (userRole == null || !userRole.Equals("Admin"))
                return Result<bool>.FailedResult("Only admins can update authors!", ResultCodes.Forbidden);

            var validatorResult = _updateAuthorDtoValidator.Validate(updateAuthorDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingAuthor = await _authorRepository.GetByIdAsync(authorId);

            if (existingAuthor == null)
                return Result<bool>.FailedResult("Author not found!", ResultCodes.NotFound);

            _mapper.Map(updateAuthorDto, existingAuthor);

            _authorRepository.Update(existingAuthor);
            await _authorRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }


        public async Task<Result<bool>> DeleteAsync(string? userRole, int id)
        {
            if (userRole == null || !userRole.Equals("Admin"))
                return Result<bool>.FailedResult("Only admins can delete authors!", ResultCodes.Forbidden);

            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
                return Result<bool>.FailedResult("Author not found", ResultCodes.NotFound);

            author.IsDeleted = true;

            _authorRepository.Update(author);
            await _authorRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }
    }
}
