using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Storage;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        [HttpPost]
        public void Add(LocationModel model)
        {
            LocationStorage.Instance.Add(model);
        }
    }
}
