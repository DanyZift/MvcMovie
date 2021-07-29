using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;

namespace MvcMovies.Services
{
    public class WeatherService
    {
        private readonly IHttpClientFactory _clientFactory;
        public WeatherService(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }

        public IEnumerable<WeatherModel> GetWeatherForcast() {
            IEnumerable<WeatherModel> weatherList = null;
            var client = _clientFactory.CreateClient();
            var response = client.GetAsync("weatherforecast");
            response.Wait();

            var result = response.Result;

            if(result.IsSuccessStatusCode) {
                var readJob = result.Content.ReadAsAsync<IList<WeatherModel>>();
                readJob.Wait();
                weatherList = readJob.Result;  
            }else {
                weatherList = Enumerable.Empty<WeatherModel>();
            } 
            return weatherList;               
        }

    }
}