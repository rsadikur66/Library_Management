using Library_Web_Front.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Library_Web_Front.Controllers
{
    public class MemberController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5205/api");
        private readonly HttpClient _httpClient;
        public MemberController()
        {
                _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: MemberController
        public ActionResult Members()
        {
            List<MemberViewModel> MembersList = new List<MemberViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Member/GetAllMembers").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                MembersList = JsonConvert.DeserializeObject<List<MemberViewModel>>(data);
            }
            return View(MembersList);
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MemberViewModel memberModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(memberModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Member/InsertMember", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Member Created.";
                    return RedirectToAction("Members");
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
        public IActionResult Edit(int MemberId)
        {
            MemberViewModel Member = new MemberViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Member/GetMemberById/" + MemberId).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Member = JsonConvert.DeserializeObject<MemberViewModel>(data);
            }
            return View(Member);
        }


        [HttpPost]
        public IActionResult Edit(MemberViewModel memberModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(memberModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Member/EditMember", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Member is updated.";
                    return RedirectToAction("Members");
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
        public IActionResult Delete(int MemberId)
        {
            MemberViewModel Member = new MemberViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Member/GetMemberById/" + MemberId).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Member = JsonConvert.DeserializeObject<MemberViewModel>(data);
            }
            return View(Member);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int MemberId)
        {
            try
            {

                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/Member/DeleteMember/" + MemberId).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Member is Deleted.";
                    return RedirectToAction("Members");
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
