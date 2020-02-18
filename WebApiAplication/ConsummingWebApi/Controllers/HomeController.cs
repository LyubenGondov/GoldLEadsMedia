using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsummingWebApi.Models;
using ConsummingWebApi.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace ConsummingWebApi.Controllers
{
    public class HomeController : Controller
    {
        ContragentsApi _api = new ContragentsApi();
        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<ContragentsData> contragentsData = new List<ContragentsData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/contragents");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                contragentsData = JsonConvert.DeserializeObject<List<ContragentsData>>(result);
            }
            return View(contragentsData);
        }

        [Authorize]
        public async Task<IActionResult> Details(int Id)
        {
            var contragent = new ContragentsData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/contragents/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                contragent= JsonConvert.DeserializeObject<ContragentsData>(result);
            }
            return View(contragent);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContragentsData contragentsData)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<ContragentsData>("api/contragents", contragentsData);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
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
