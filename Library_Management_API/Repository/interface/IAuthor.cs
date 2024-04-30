using Library_Management_API.Models;
using Microsoft.AspNetCore.Mvc;

public interface IAuthor
{
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<Author> GetAuthorByIdAsync(int id);
    Task AddAuthorAsync(Author Author_model);
    Task UpdateAuthorAsync(Author author_model);
    Task DeleteAuthorAsync(int id);
}