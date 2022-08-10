using DrugMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
namespace DrugMvc.Controllers
{
    public class LoginController : Controller
    {
        string baseURL = "https://localhost:7195/";
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(Users u)
        {
           using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7195/api/Methods/", content);
               
            }
           return RedirectToAction("Index","Calling");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Users u)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7195/api/Methods/", content);
            }
            return RedirectToAction("UserLogin", "Login");
        }
    }
}
