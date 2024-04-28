using Library_Management_API.Models;
    public interface IMember
{
    Task<IEnumerable<Member>> GetAllMembers();
}

