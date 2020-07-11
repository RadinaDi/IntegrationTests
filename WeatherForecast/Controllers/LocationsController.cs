using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Storage;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        [HttpPost]
        public void Add(LocationModel model)
        {
            LocationStorage.Instance.Add(model);
        }
    }
}
