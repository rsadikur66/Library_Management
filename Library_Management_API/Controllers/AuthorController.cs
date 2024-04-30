using Library_Management_API.Models;
using Library_Management_API.Repository.implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Library_Management_API.Controllers
{
    public class AuthorController : Controller
    {
        
        private readonly IAuthor _author_repository;
        public AuthorController(IAuthor author_repo)
        {
            _author_repository = author_repo;
        }

        // GET: AuthorController
        [HttpGet(("api/Author/GetAuthorList"))]
        public async Task<IEnumerable<Author>> GetAuthorList()
        {
            var authors = await _author_repository.GetAllAuthors();
            return authors;
        }        

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("/api/Author/InsertAuthor")]
        public async Task<IActionResult> InsertAuthor([FromBody] Author authorModel)
        {
            try
            {
                await _author_repository.AddAuthorAsync(authorModel);
                return Ok("Author Created");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: AuthorController/Edit/5
        [HttpGet("/api/Author/GetAuthorById/{AuthorId}")]
        public async Task<Author> GetAuthorById(int AuthorId)
        {
            var authorDetails = await _author_repository.GetAuthorByIdAsync(AuthorId);
            return authorDetails;
        }
        // POST: AuthorController/Edit/5
        [HttpPut("/api/Author/EditAuthor")]
        public async Task<IActionResult> EditAuthor([FromBody] Author authorModel)
        {
            try
            {
                await _author_repository.UpdateAuthorAsync(authorModel);
                return Ok("Author is Updated");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }      
      

        // POST: AuthorController/Delete/5
        [HttpDelete("/api/Author/DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                await _author_repository.DeleteAuthorAsync(id);
                return Ok("Author is Deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
