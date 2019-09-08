using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HotelAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            string baseUrl= "http://localhost:51391/api/";
            string username = "aaa";
            string password = "baa";
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);

                string queryString = string.Format("values/login?username={0}&Password={1}", username, password);
                var httpResponse = httpClient.GetAsync(queryString);
                HttpResponseMessage httpResponseMessage = httpResponse.GetAwaiter().GetResult();
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var resultset = httpResponseMessage.Content.ReadAsStringAsync();//   .Parse(httpResponseMessage.Content.ToString());// ReadAsStringAsync().ToString());
                    //var resultset = JObject.Parse(httpResponseMessage.Content.ToString());// ReadAsStringAsync().ToString());
                    string Result = JsonConvert.DeserializeObject (resultset.Result.ToString()).ToString();
                }
            }



                ViewBag.Title = "Home Page";

            return View();
        }
    }
}
