using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherForecast.Models;
using WeatherForecast.Storage;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        [HttpGet]
        public IEnumerable<WeatherForecastModel> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Location = (LocationStorage.Instance.Length == 0) ? null :
                            LocationStorage.Instance[rng.Next(LocationStorage.Instance.Length)],
            })
            .ToArray();
        }

        [HttpGet]
        [Route("Tomorrow")]
        public WeatherForecastModel GetTomorrow()
        {
            var rng = new Random();
            return new WeatherForecastModel
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Location = (LocationStorage.Instance.Length == 0) ? null :
                            LocationStorage.Instance[rng.Next(LocationStorage.Instance.Length)],
            };
        }
    }
}
