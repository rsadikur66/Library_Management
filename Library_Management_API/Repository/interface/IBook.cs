using Library_Management_API.Models;
public interface IBook
{
    Task<IEnumerable<Book>> GetAllBooks();
    
}
