using Library_Management_API.Models;

public interface IAuthor
{
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<Author> GetProductByIdAsync(int id);
    Task AddProductAsync(Author product);
    Task UpdateProductAsync(int id, Author product);
    Task DeleteProductAsync(int id);
}