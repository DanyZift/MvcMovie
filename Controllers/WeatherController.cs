using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //get my data and then pass to the view of Index in the Weather folder!
            //https://localhost:5006/WeatherForcast
            IEnumerable<WeatherModel> weatherList = null;
            //GET Request 
            using(var client = new HttpClient()) {

                client.BaseAddress = new Uri("https://localhost:5006");

                var responseTask = client.GetAsync("weatherforcast");
                responseTask.Wait();

                var result = responseTask.Result;

                if(result.IsSuccessStatusCode) {
                    _logger.LogInformation("Got the data back!!");
                    var readJob = result.Content.ReadAsAsync<IList<WeatherModel>>();
                    readJob.Wait();
                    weatherList = readJob.Result;                                   
                } else {
                    _logger.LogInformation("Got No Data :(");
                    _logger.LogInformation("STATUS CODE: " + result.StatusCode.ToString());           
                    weatherList = Enumerable.Empty<WeatherModel>();
                    ModelState.AddModelError(string.Empty, "No Weather Forcast Found!");
                }

            }
            //Get Body of request
            //feed the data into the View below....
            return View(weatherList);
        }
    }
}
