using AutoMapper;
using Business.Dtos;
using Entities.Concrete;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, GetUserDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
