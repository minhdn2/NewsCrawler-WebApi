using NewsCrawler_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NewsCrawler_WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            CallToApi();
            return View();
        }

        private void CallToApi()
        {
            var path = "everything?q=bitcoin&from=2019-03-17&sortBy=publishedAt&apiKey=18ca97d02834421fa4b7429131386d08";
            var temp = GetProductAsync(path);
        }

        static async Task<IEnumerable<JsonResult>> GetProductAsync(string path)
        {
            IEnumerable<JsonResult> dataObjects = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://newsapi.org/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    dataObjects = response.Content.ReadAsAsync<IEnumerable<JsonResult>>().Result;
                }
                return await Task.FromResult(dataObjects);
            }
        }
    }
}
