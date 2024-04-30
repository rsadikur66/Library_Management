using Library_Management_API.Models;
using Library_Web_Front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace Library_Web_Front.Controllers
{
    public class HomeController : Controller
    {
        
        Uri baseAddress = new Uri("http://localhost:5205/api");
        private readonly HttpClient _httpClient;
        
        public HomeController()
        { 
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            
        }

        public IActionResult Index()
        {
            List<AuthorViewModel> AuthorList = new List<AuthorViewModel>(); 
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Author/GetAuthorList").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                AuthorList = JsonConvert.DeserializeObject<List<AuthorViewModel>>(data);
            }

            return View(AuthorList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AuthorViewModel authorModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(authorModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Author/InsertAuthor", content).Result ;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Product Created.";
                    return RedirectToAction("Index");
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
        public IActionResult Edit(int AuthorId)
        {
            AuthorViewModel author = new AuthorViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Author/GetAuthorById/" + AuthorId).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                author = JsonConvert.DeserializeObject<AuthorViewModel>(data);  
            }
            return View(author);
        }


        [HttpPost] 
        public IActionResult Edit(AuthorViewModel authorModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(authorModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Author/EditAuthor", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Author is updated.";
                    return RedirectToAction("Index");
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
        public IActionResult Delete(int AuthorId)
        {
            AuthorViewModel author = new AuthorViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Author/GetAuthorById/" + AuthorId).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                author = JsonConvert.DeserializeObject<AuthorViewModel>(data);
            }
            return View(author);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int AuthorId)
        {
            try
            {
               
                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/Author/DeleteAuthor/"+ AuthorId).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Author is Deleted.";
                    return RedirectToAction("Index");
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