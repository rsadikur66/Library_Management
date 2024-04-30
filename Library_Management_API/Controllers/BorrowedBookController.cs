using Library_Management_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_API.Controllers
{
    public class BorrowedBookController : Controller
    {
        private readonly IBorrowedBook _borrowedBook_repository;
        public BorrowedBookController(IBorrowedBook borrowedBook_repo)
        {
            _borrowedBook_repository = borrowedBook_repo;
        }

        [HttpGet("/api/BorrowedBook/GetAllBorrowedBookList")]
        // GET: BorrowedBookController
        public async Task<IEnumerable<BorrowedBookDetails>> GetAllBorrowedBookList()
        {
            var borrowed_books_list = await _borrowedBook_repository.GetAllBorrowedBookList();
            return borrowed_books_list;
         
        }

        
        
    }
}
