using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;
using MvcMovies.Services;

namespace MvcMovie.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService, ILogger<WeatherController> logger)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            IEnumerable<WeatherModel> weatherModels = _weatherService.GetWeatherForcast();
            return View(weatherModels);
        }
    }
}
