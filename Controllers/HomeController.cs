using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ToonClient31.Models;

namespace ToonClient31.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string baseUrl = "http://toonapi.azurewebsites.net/";
            Toon[] toons = null;

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(baseUrl + "api/cartoon"))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    toons = JsonConvert.DeserializeObject<Toon[]>(data);
                }
            }

            ViewBag.BaseUrl = baseUrl;

            return View(toons);
        }


        /*
         *             string api = "http://toonapi.azurewebsites.net/api/cartoon";

            //string data = ToonUtils.GetData(api);

            app.Run(async (context) =>
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage res = await client.GetAsync(api))
                using (HttpContent content = res.Content)
                {
                    string data = await content.ReadAsStringAsync();
                    if (data != null)
                    {
                        Toon[] persons = JsonConvert.DeserializeObject<Toon[]>(data);
                        await context.Response.WriteAsync(persons.Count().ToString());
                    }

                }
            });

         */
    }
}
