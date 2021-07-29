using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{

    // "date": "2021-07-29T19:21:52.89309+01:00",
    // "temperatureC": 33,
    // "temperatureF": 91,
    // "summary": "Mild"
    public class WeatherModel
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public long TemperatureC { get; set; }
        public long TemperatureF { get; set; }
        public string Summary {get; set;} 
    }
}