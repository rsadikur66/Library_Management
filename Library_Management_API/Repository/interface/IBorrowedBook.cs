
using Library_Management_API.Models;

public interface IBorrowedBook
{
    Task<IEnumerable<BorrowedBook>> GetAllBorrowedBookList();
}
