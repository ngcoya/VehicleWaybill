using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using TritonExpress.Models;
using System.Text;

namespace TritonExpress.Controllers
{
    public class WaybillController : Controller
    {
       
        //public WaybillController()
        //{
        //    //_context = context;
        //}

        readonly HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:38225/api/waybill/get-waybills");

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);

                var result = JsonConvert.DeserializeObject<List<Waybill>>(responseBody);

                return View (result);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                throw e;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:38225/api/waybill/get-waybill/" + Id);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
               
                Console.WriteLine(responseBody);

                var result = JsonConvert.DeserializeObject<Waybill>(responseBody);

                return View(result);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                throw e;
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            Waybill waybill = new Waybill();
            return View(waybill);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Waybill waybill)
        {
            try
            {
                var json = JsonConvert.SerializeObject(waybill);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:38225/api/waybill/create-waybill/", data);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
               
                Console.WriteLine(responseBody);

                return RedirectToAction("index");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                throw e;
            }
        }
    }
}
