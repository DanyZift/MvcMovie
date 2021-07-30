using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;
using MvcMovie.Services;

namespace MvcMovie.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;

        private readonly WeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(this._weatherService.GetWeather());
        }

        public IActionResult Details(int? id) 
        {
            return View(this._weatherService.GetWeatherByCountry(id));
        }
    }
}
