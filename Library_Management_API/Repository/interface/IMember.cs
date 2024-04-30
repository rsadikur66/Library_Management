using Library_Management_API.Models;
    public interface IMember
{
    Task<IEnumerable<Member>> GetAllMembers();
    Task<Member> GetMemberByIdAsync(int id);
    Task AddMemberAsync(Member Member_model);
    Task UpdateMemberAsync(Member book_model);
    Task DeleteMemberAsync(int id);
}

