using Library_Management_API.Models;
using Library_Web_Front.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}