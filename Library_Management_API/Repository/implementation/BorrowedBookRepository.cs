using Library_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_API.Repository.implementation
{
    public class BorrowedBookRepository : IBorrowedBook
    {
        private readonly Library_Management_SystemContext _dbContext;
        public BorrowedBookRepository(Library_Management_SystemContext context)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<BorrowedBook>> GetAllBorrowedBookList()
        {
           return await _dbContext.BorrowedBooks.ToListAsync();
        }
    }
}
