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
        public async Task<IEnumerable<BorrowedBookDetails>> GetAllBorrowedBookList()
        {
           //return await _dbContext.BorrowedBooks.ToListAsync().sele;
           var query = from borrowedBook in _dbContext.BorrowedBooks
                       join book in _dbContext.Books on borrowedBook.BookId equals book.BookId
                       join member in _dbContext.Members on borrowedBook.MemberId equals member.MemberId
                       join author in _dbContext.Authors on book.AuthorId equals author.AuthorId
                       select new BorrowedBookDetails
                       {
                           BookId = borrowedBook.BookId.HasValue ? borrowedBook.BookId.Value : default(int),
                           Title = book.Title,
                           AuthorName = author.AuthorName,
                           BorrowDate = borrowedBook.BorrowDate,
                           ReturnDate = borrowedBook.ReturnDate,
                           BookStatus = borrowedBook.Status,
                           MemberName = member.FirstName + " " + member.LastName
                       };
            return await query.ToListAsync();
        }
    }
}
