using Library_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_API.Repository.implementation
{
    public class MemberRepository : IMember
    {
        private readonly Library_Management_SystemContext _dbContext;
        public MemberRepository(Library_Management_SystemContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            return await _dbContext.Members.ToListAsync();
        }
    }
}
