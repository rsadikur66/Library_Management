using Library_Management_API.Models;
using Library_Management_API.Repository.implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Library_Management_API.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook  _book_repository;
            public BookController(IBook book_repo)
        {
                _book_repository = book_repo;
        }
        [HttpGet("/api/Book/GetAllBooks")]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
           var all_books = await _book_repository.GetAllBooks();
            return  all_books;
        }



        [HttpGet("/api/Book/GetAllAuthors")]
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            var all_authors = await _book_repository.GetAllAuthors();
            return all_authors;
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost("/api/Book/InsertBook")]
        public async Task<IActionResult> InsertBook([FromBody] Book bookModel)
        {
            try
            {
                await _book_repository.AddBookAsync(bookModel);
                return Ok("Author Created");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("/api/Book/GetBookById/{BookId}")]
        public async Task<Book> GetBookById(int BookId)
        {
            var bookDetails = await _book_repository.GetBooksByIdAsync(BookId);
            return bookDetails;
        }
        
        [HttpPut("/api/Book/EditBook")]
        public async Task<IActionResult> EditBook([FromBody] Book bookModel)
        {
            try
            {
                await _book_repository.UpdateBookAsync(bookModel);
                return Ok("Book is Updated");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("/api/Book/DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _book_repository.DeleteBookAsync(id);
                return Ok("Book is Deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
