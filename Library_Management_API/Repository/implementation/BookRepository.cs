using Library_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_API.Repository.implementation
{
    public class BookRepository : IBook
    {
        private readonly Library_Management_SystemContext _dbContext;
        public BookRepository(Library_Management_SystemContext context)
        {
                _dbContext = context;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }
    }
}
