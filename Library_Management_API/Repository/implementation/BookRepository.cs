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
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Book> GetBooksByIdAsync(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }
        public Task AddBookAsync(Book Book_model)
        {
            _dbContext.Books.Add(Book_model);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task UpdateBookAsync(Book book_model)
        {
            if (book_model == null || book_model.BookId == 0)
            {
                throw new ArgumentException("Invalid book data. Book model is null or BookId is 0.");
            }
            try
            {
                var books = _dbContext.Books.Find(book_model.BookId);
                if (books == null)
                {
                    throw new ArgumentException($"Book not found with id {book_model.BookId}.");

                }
                books.Title = book_model.Title;
                books.PublishedDate = book_model.PublishedDate;
                books.AvailableCopies = book_model.AvailableCopies;
                books.Isbn = book_model.Isbn;
                books.TotalCopies = book_model.TotalCopies;
                books.AuthorId = book_model.AuthorId;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating book.", ex);
            }

        }

        public Task DeleteBookAsync(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book == null)
            {
                throw new ArgumentException($"Book not found with id {id}.");

            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
