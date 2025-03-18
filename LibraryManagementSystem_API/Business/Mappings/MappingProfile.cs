using AutoMapper;
using Business.Dtos.Auth;
using Business.Dtos.Author;
using Business.Dtos.Book;
using Business.Dtos.BookCopy;
using Business.Dtos.Category;
using Business.Dtos.Publisher;
using Business.Dtos.User;
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

            CreateMap<AddAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();

            CreateMap<AddBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();

            CreateMap<AddBookCopyDto, BookCopy>();
            CreateMap<UpdateBookCopyDto, BookCopy>();

            CreateMap<AddCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<AddPublisherDto, Publisher>();
            CreateMap<UpdatePublisherDto, Publisher>();
        }
    }
}
