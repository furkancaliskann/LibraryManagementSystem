using AutoMapper;
using Business.Dtos.Auth;
using Business.Dtos.Author;
using Business.Dtos.Book;
using Business.Dtos.BookCopy;
using Business.Dtos.Category;
using Business.Dtos.Fine;
using Business.Dtos.Loan;
using Business.Dtos.Publisher;
using Business.Dtos.Reservation;
using Business.Dtos.Shelf;
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

            CreateMap<AddLoanDto, Loan>();
            CreateMap<UpdateLoanDto, Loan>();

            CreateMap<AddFineDto, Fine>();
            CreateMap<UpdateFineDto, Fine>();

            CreateMap<AddReservationDto, Reservation>();
            CreateMap<UpdateReservationDto, Reservation>();

            CreateMap<AddShelfDto, Shelf>();
            CreateMap<UpdateShelfDto, Shelf>();
        }
    }
}
