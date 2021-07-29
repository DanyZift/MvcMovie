using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;

namespace MvcMovies.Services
{
    public class MoviesService {

        public HttpClient Client { get; }

        public MoviesService(HttpClient httpClient) {
            httpClient.BaseAddress = new Uri("https://localhost:5006");
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await Client.GetFromJsonAsync<IEnumerable<Movie>>("/movies");
        }
    }
}