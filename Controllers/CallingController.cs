using DrugMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DrugMvc.Controllers
{
    public class CallingController : Controller
    {

        string baseURL = "https://localhost:7195/";
        public async Task<IActionResult> Index()
        {
            List<Products> p = new List<Products>();
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("https://localhost:7195/api/Products");
                if (res.IsSuccessStatusCode)
                {
                    var Prodres=res.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<List<Products>>(Prodres);
                }
                return View(p);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Products pr)
        {
            using(var client=new HttpClient())
            {
                client.BaseAddress=new Uri(baseURL);
                StringContent content = new StringContent(JsonConvert.SerializeObject(pr),Encoding.UTF8,"application/json");
                await client.PostAsync("api/Products",content);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Products obj = new Products();
            using(var client=new HttpClient())
            {
                using (var ares = await client.GetAsync("https://localhost:7195/api/Products/"+id))
                {
                    string apires = await ares.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<Products>(apires);
                }
            }
            return View(obj);
        }
        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            Products p1 = new Products();
            using(var client=new HttpClient())
            {
                using (var res = await client.GetAsync("https://localhost:7195/api/Products/" + id))
                {
                    string ar=await res.Content.ReadAsStringAsync();
                    p1 = JsonConvert.DeserializeObject<Products>(ar);
                }
            }
            return View(p1);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Products p)
        {
            Products p2=new Products();
            using( var client=new HttpClient())
            {
                int id = p.ProductId;
                StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                using(var res=await client.PutAsync("https://localhost:7195/api/Products/" + id,content))
                {
                    string apr=await res.Content.ReadAsStringAsync();
                    p2= JsonConvert.DeserializeObject<Products>(apr);
                }
            }
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Products p3=new Products();
            using (var client = new HttpClient())
            {
                using(var res=await client.GetAsync("https://localhost:7195/api/Products/" + id))
                {
                    string apir=await res.Content.ReadAsStringAsync();
                    p3 = JsonConvert.DeserializeObject<Products>(apir);
                }
            }
            return View(p3);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Products products)
        {
            int id = products.ProductId;
            using(var client=new HttpClient())
            {
                client.BaseAddress=new Uri(baseURL);
                await client.DeleteAsync("https://localhost:7195/api/Products/" + id);
            }
            return RedirectToAction("Index");   
        }

       
    }
}
