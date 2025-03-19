using AutoMapper;
using Business.Abstract;
using Business.Dtos.Shelf;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class ShelfService : IShelfService
    {
        private readonly IShelfRepository _shelfRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddShelfDto> _addShelfDtoValidator;
        private readonly IValidator<UpdateShelfDto> _updateShelfDtoValidator;

        public ShelfService(IShelfRepository shelfRepository, IMapper mapper,
           IValidator<AddShelfDto> addShelfDtoValidator, IValidator<UpdateShelfDto> updateShelfDtoValidator)
        {
            _shelfRepository = shelfRepository;
            _mapper = mapper;
            _addShelfDtoValidator = addShelfDtoValidator;
            _updateShelfDtoValidator = updateShelfDtoValidator;
        }

        public async Task<Result<IEnumerable<Shelf>>> GetAllAsync()
        {
            var shelves = await _shelfRepository.GetAllAsync();
            return Result<IEnumerable<Shelf>>.SuccessResultWithData(shelves);
        }

        public async Task<Result<IEnumerable<Shelf>>> GetWithoutDeletedAsync()
        {
            var shelves = await _shelfRepository.GetWithoutDeletedAsync();
            return Result<IEnumerable<Shelf>>.SuccessResultWithData(shelves);
        }

        public async Task<Result<Shelf>> GetByIdAsync(int id)
        {
            var shelf = await _shelfRepository.GetByIdAsync(id);
            if (shelf == null)
                return Result<Shelf>.FailedResult("Shelf not found!", ResultCodes.NotFound);

            return Result<Shelf>.SuccessResultWithData(shelf);
        }

        public async Task<Result<bool>> AddAsync(string? userRole, AddShelfDto addShelfDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can add shelf!", ResultCodes.Forbidden);

            var validatorResult = _addShelfDtoValidator.Validate(addShelfDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingShelf = await _shelfRepository.GetByLocationAsync(addShelfDto.Location);

            if (existingShelf != null)
                return Result<bool>.FailedResult("This shelf has already been registered!", ResultCodes.Conflict);

            var mappedShelf = _mapper.Map<Shelf>(addShelfDto);

            await _shelfRepository.AddAsync(mappedShelf);
            var result = await _shelfRepository.SaveChangesAsync();

            if (!result)
                return Result<bool>.FailedResult("An error occurred while adding the shelf!", ResultCodes.ServerError);

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> UpdateAsync(string? userRole, int shelfId, UpdateShelfDto updateShelfDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can update shelves!", ResultCodes.Forbidden);

            var validatorResult = _updateShelfDtoValidator.Validate(updateShelfDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingShelf = await _shelfRepository.GetByIdAsync(shelfId);

            if (existingShelf == null)
                return Result<bool>.FailedResult("Shelf not found!", ResultCodes.NotFound);

            _mapper.Map(updateShelfDto, existingShelf);

            _shelfRepository.Update(existingShelf);
            await _shelfRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> DeleteAsync(string? userRole, int id)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can delete shelves!", ResultCodes.Forbidden);

            var shelf = (await GetByIdAsync(id)).Data;

            if (shelf == null)
                return Result<bool>.FailedResult("Shelf not found", ResultCodes.NotFound);

            shelf.IsDeleted = true;

            _shelfRepository.Update(shelf);
            await _shelfRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }
    }
}
