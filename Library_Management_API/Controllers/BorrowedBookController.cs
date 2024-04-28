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
        public async Task<IEnumerable<BorrowedBook>> GetAllBorrowedBookList()
        {
            var borrowed_books_list = await _borrowedBook_repository.GetAllBorrowedBookList();
            return borrowed_books_list;
         
        }

        // GET: BorrowedBookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BorrowedBookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BorrowedBookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BorrowedBookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BorrowedBookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BorrowedBookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BorrowedBookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
