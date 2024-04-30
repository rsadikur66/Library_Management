using Library_Management_API.Models;
using Library_Management_API.Repository.implementation;
using Library_Web_Front.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Library_Web_Front.Controllers
{
    public class BookController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5205/api");
        private readonly HttpClient _httpClient;
        public BookController()
        {
                _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        // GET: BookController
        public ActionResult Books()
        {
            List<BookViewModel> BooksList = new List<BookViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Book/GetAllBooks").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                BooksList = JsonConvert.DeserializeObject<List<BookViewModel>>(data);
            }           
            return View(BooksList);
        }

        

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookViewModel();
            model.PublishedDate = null;
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Book/GetAllAuthors/").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model.AuthorList = JsonConvert.DeserializeObject<List<AuthorViewModel>>(data);
            }
            // Populate AuthorList from your data source
            //model.AuthorList = _authorRepository.GetAllAuthors(); // Example method to get all authors
            return View(model);
            //return View();
        }

        [HttpPost]
        public ActionResult Create(BookViewModel bookModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(bookModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Book/InsertBook", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Book Created.";
                    return RedirectToAction("Books");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int BookId)
        {
            BookViewModel book = new BookViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Book/GetBookById/" + BookId).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<BookViewModel>(data);
            }
            return View(book);
        }


        [HttpPost]
        public IActionResult Edit(BookViewModel bookModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(bookModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Book/EditBook", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Book is updated.";
                    return RedirectToAction("Books");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();

        }

        [HttpGet]
        public IActionResult Delete(int BookId)
        {
            BookViewModel book = new BookViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Book/GetBookById/" + BookId).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<BookViewModel>(data);
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int BookId)
        {
            try
            {

                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/Book/DeleteBook/" + BookId).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Book is Deleted.";
                    return RedirectToAction("Books");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();

        }
    }
}
