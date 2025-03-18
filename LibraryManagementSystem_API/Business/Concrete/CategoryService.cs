using AutoMapper;
using Business.Abstract;
using Business.Dtos.Category;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddCategoryDto> _addCategoryDtoValidator;
        private readonly IValidator<UpdateCategoryDto> _updateCategoryDtoValidator;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper,
           IValidator<AddCategoryDto> addCategoryDtoValidator, IValidator<UpdateCategoryDto> updateCategoryDtoValidator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _addCategoryDtoValidator = addCategoryDtoValidator;
            _updateCategoryDtoValidator = updateCategoryDtoValidator;
        }

        public async Task<Result<IEnumerable<Category>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Result<IEnumerable<Category>>.SuccessResultWithData(categories);
        }

        public async Task<Result<IEnumerable<Category>>> GetWithoutDeletedAsync()
        {
            var categories = await _categoryRepository.GetWithoutDeletedAsync();
            return Result<IEnumerable<Category>>.SuccessResultWithData(categories);
        }

        public async Task<Result<Category>> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return Result<Category>.FailedResult("Category not found!", ResultCodes.NotFound);

            return Result<Category>.SuccessResultWithData(category);
        }

        public async Task<Result<bool>> AddAsync(string? userRole, AddCategoryDto addCategoryDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can add category!", ResultCodes.Forbidden);

            var validatorResult = _addCategoryDtoValidator.Validate(addCategoryDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingCategory = await _categoryRepository.GetByNameAsync(addCategoryDto.Name);

            if (existingCategory != null)
                return Result<bool>.FailedResult("This category has already been registered!", ResultCodes.Conflict);

            var mappedCategory = _mapper.Map<Category>(addCategoryDto);

            await _categoryRepository.AddAsync(mappedCategory);
            var result = await _categoryRepository.SaveChangesAsync();

            if (!result)
                return Result<bool>.FailedResult("An error occurred while adding the category!", ResultCodes.ServerError);

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> UpdateAsync(string? userRole, int categoryId, UpdateCategoryDto updateCategoryDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can update categories!", ResultCodes.Forbidden);

            var validatorResult = _updateCategoryDtoValidator.Validate(updateCategoryDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingCategory = await _categoryRepository.GetByIdAsync(categoryId);

            if (existingCategory == null)
                return Result<bool>.FailedResult("Category not found!", ResultCodes.NotFound);

            _mapper.Map(updateCategoryDto, existingCategory);

            _categoryRepository.Update(existingCategory);
            await _categoryRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> DeleteAsync(string? userRole, int id)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can delete categories!", ResultCodes.Forbidden);

            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return Result<bool>.FailedResult("Category not found", ResultCodes.NotFound);

            category.IsDeleted = true;

            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }
    }
}
