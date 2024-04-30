using Library_Management_API.Models;
public interface IBook
{
    Task<IEnumerable<Book>> GetAllBooks();
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<Book> GetBooksByIdAsync(int id);
    Task AddBookAsync(Book Book_model);
    Task UpdateBookAsync(Book book_model);
    Task DeleteBookAsync(int id);
}
