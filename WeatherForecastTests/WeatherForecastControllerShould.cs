using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using WeatherForecast;
using WeatherForecast.Models;
using Xunit;

namespace WeatherForecastTests
{
    public class WeatherForecastControllerShould : BaseTest
    {
        public WeatherForecastControllerShould(WebApplicationFactory<Startup> fixture)
            : base(fixture)
        {
        }

        [Theory]
        [InlineData("/weatherforecast")]
        public async Task RetrieveForecast(string url)
        {
            var response = await this.HttpClient.GetAsync(url);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var forecast = JsonConvert.DeserializeObject<WeatherForecastModel[]>(await response.Content.ReadAsStringAsync());
            forecast.Should().HaveCount(5);
        }
    }
}
