using Library_Management_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_API.Repository.implementation
{
    public class AuthorRepository : IAuthor
    {
        private readonly Library_Management_SystemContext _dbContext;
        public AuthorRepository(Library_Management_SystemContext dbContext)
        {

            _dbContext = dbContext;

        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _dbContext.Authors.FindAsync(id);
        }
        public Task AddAuthorAsync(Author Author_model)
        {
            _dbContext.Authors.Add(Author_model);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task UpdateAuthorAsync(Author author_model)
        {
            if (author_model == null || author_model.AuthorId == 0)
            {
                throw new ArgumentException("Invalid author data. Author model is null or AuthorId is 0.");
            }
            try
            {
                var authors = _dbContext.Authors.Find(author_model.AuthorId);
                if (authors == null)
                {
                    throw new ArgumentException($"Author not found with id {author_model.AuthorId}.");

                }
                authors.AuthorName = author_model.AuthorName;
                authors.AuthorBio = author_model.AuthorBio;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating author.", ex);
            }
            
        }

        public Task DeleteAuthorAsync(int id)
        {
            var author = _dbContext.Authors.Find(id);
            if (author == null)
            {
                throw new ArgumentException($"Author not found with id {id}.");

            }
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
