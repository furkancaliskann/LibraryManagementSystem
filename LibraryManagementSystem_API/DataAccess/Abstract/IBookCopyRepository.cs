using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBookCopyRepository : IGenericRepository<BookCopy>
    {
        Task<BookCopy?> GetWithCopyNumber(string copyNumber); 
    }
}
