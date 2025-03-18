using AutoMapper;
using Business.Abstract;
using Business.Dtos.Publisher;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddPublisherDto> _addPublisherDtoValidator;
        private readonly IValidator<UpdatePublisherDto> _updatePublisherDtoValidator;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper,
           IValidator<AddPublisherDto> addPublisherDtoValidator, IValidator<UpdatePublisherDto> updatePublisherDtoValidator)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _addPublisherDtoValidator = addPublisherDtoValidator;
            _updatePublisherDtoValidator = updatePublisherDtoValidator;
        }

        public async Task<Result<IEnumerable<Publisher>>> GetAllAsync()
        {
            var publishers = await _publisherRepository.GetAllAsync();
            return Result<IEnumerable<Publisher>>.SuccessResultWithData(publishers);
        }

        public async Task<Result<IEnumerable<Publisher>>> GetWithoutDeletedAsync()
        {
            var publishers = await _publisherRepository.GetWithoutDeletedAsync();
            return Result<IEnumerable<Publisher>>.SuccessResultWithData(publishers);
        }

        public async Task<Result<Publisher>> GetByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher == null)
                return Result<Publisher>.FailedResult("Publisher not found!", ResultCodes.NotFound);

            return Result<Publisher>.SuccessResultWithData(publisher);
        }

        public async Task<Result<bool>> AddAsync(string? userRole, AddPublisherDto addPublisherDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can add publisher!", ResultCodes.Forbidden);

            var validatorResult = _addPublisherDtoValidator.Validate(addPublisherDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingCategory = await _publisherRepository.GetByNameAsync(addPublisherDto.Name);

            if (existingCategory != null)
                return Result<bool>.FailedResult("This publisher has already been registered!", ResultCodes.Conflict);

            var mappedPublisher = _mapper.Map<Publisher>(addPublisherDto);

            await _publisherRepository.AddAsync(mappedPublisher);
            var result = await _publisherRepository.SaveChangesAsync();

            if (!result)
                return Result<bool>.FailedResult("An error occurred while adding the publisher!", ResultCodes.ServerError);

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> UpdateAsync(string? userRole, int publisherId, UpdatePublisherDto updatePublisherDto)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can update publishers!", ResultCodes.Forbidden);

            var validatorResult = _updatePublisherDtoValidator.Validate(updatePublisherDto);

            if (!validatorResult.IsValid)
                return Result<bool>.FailedResult(validatorResult.ToString(), ResultCodes.BadRequest);

            var existingPublisher = await _publisherRepository.GetByIdAsync(publisherId);

            if (existingPublisher == null)
                return Result<bool>.FailedResult("Publisher not found!", ResultCodes.NotFound);

            _mapper.Map(updatePublisherDto, existingPublisher);

            _publisherRepository.Update(existingPublisher);
            await _publisherRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }

        public async Task<Result<bool>> DeleteAsync(string? userRole, int id)
        {
            if (userRole == null || (!userRole.Equals("Admin") && !userRole.Equals("Employee")))
                return Result<bool>.FailedResult("Only admins and employees can delete publishers!", ResultCodes.Forbidden);

            var publisher = await _publisherRepository.GetByIdAsync(id);

            if (publisher == null)
                return Result<bool>.FailedResult("Publisher not found", ResultCodes.NotFound);

            publisher.IsDeleted = true;

            _publisherRepository.Update(publisher);
            await _publisherRepository.SaveChangesAsync();

            return Result<bool>.SuccessResult();
        }
    }
}
