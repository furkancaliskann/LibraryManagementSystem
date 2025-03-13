using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Presentation.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookCopyRepository, BookCopyRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFineRepository, FineRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookCopyService, BookCopyService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFineService, FineService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
