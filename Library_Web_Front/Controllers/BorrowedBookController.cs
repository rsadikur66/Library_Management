using Library_Web_Front.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Library_Web_Front.Controllers
{
    public class BorrowedBookController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5205/api");
        private readonly HttpClient _httpClient;
        public BorrowedBookController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<BorrowedBookViewModel> BorrowedBooksList = new List<BorrowedBookViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/BorrowedBook/GetAllBorrowedBookList").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                BorrowedBooksList = JsonConvert.DeserializeObject<List<BorrowedBookViewModel>>(data);
            }
            return View(BorrowedBooksList);
            //return View();
        }
    }
}
