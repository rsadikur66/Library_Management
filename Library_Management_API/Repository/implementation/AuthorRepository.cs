using Library_Management_API.Models;
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
          return await  _dbContext.Authors.ToListAsync();
        }

        public Task AddProductAsync(Author product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<Author> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(int id, Author product)
        {
            throw new NotImplementedException();
        }
    }
}
