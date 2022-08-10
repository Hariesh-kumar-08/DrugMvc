using DrugMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DrugMvc.Controllers
{
    public class MethodsController : Controller
    {
        string baseURL = "https://localhost:7195/";

        [HttpGet]
        public async Task<IActionResult> Buy(int id)
        {
            TempData["id"]=id;
            Dummy dummy = new Dummy();
            using (var client = new HttpClient())
            {
                using (var res = await client.GetAsync("https://localhost:7195/api/Methods/" + id))
                {
                    string ar = await res.Content.ReadAsStringAsync();
                    dummy = JsonConvert.DeserializeObject<Dummy>(ar);
                }
            }
            return View(dummy);
        }
        [HttpPost]
        public async Task<IActionResult> Buy(String Name,String location,String PN)
        {
            Products p1 = new Products();
            Dummy dummy = new Dummy();
            
            int id=  (int)TempData["id"];
            dummy.location=location;
            dummy.Name=Name;
            dummy.PhoneNumber = PN;
            dummy.ProductId=id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                StringContent content = new StringContent(JsonConvert.SerializeObject(dummy), Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7195/api/Methods/", content);
                 return RedirectToAction("Index","Calling");
            }
        }
    }
}
