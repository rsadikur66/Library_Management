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

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            return await _dbContext.Members.FindAsync(id);
        }
        public Task AddMemberAsync(Member Member_model)
        {
            _dbContext.Members.Add(Member_model);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task UpdateMemberAsync(Member member_model)
        {
            if (member_model == null || member_model.MemberId == 0)
            {
                throw new ArgumentException("Invalid author data. Member model is null or MemberId is 0.");
            }
            try
            {
                var members = _dbContext.Members.Find(member_model.MemberId);
                if (members == null)
                {
                    throw new ArgumentException($"Member not found with id {member_model.MemberId}.");

                }
                members.FirstName = member_model.FirstName;
                members.LastName = member_model.LastName;
                members.Email = member_model.Email;
                members.PhoneNumber = member_model.PhoneNumber;
                members.RegistrationDate = member_model.RegistrationDate;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating member.", ex);
            }

        }

        public Task DeleteMemberAsync(int id)
        {
            var member = _dbContext.Members.Find(id);
            if (member == null)
            {
                throw new ArgumentException($"Member not found with id {id}.");

            }
            _dbContext.Members.Remove(member);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
