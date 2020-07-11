using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecast;
using WeatherForecast.Models;
using WeatherForecastTests.Data;
using WeatherForecastTests.Extensions;
using WeatherForecastTests.Utils;
using Xunit;

namespace WeatherForecastTests
{
    public class WeatherForecastControllerShould : BaseTest
    {
        public WeatherForecastControllerShould(WebApplicationFactory<Startup> fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task RetrieveNext5DaysForecast()
        {
            var model = LocationData.NewLocationData();
            var response = await this.HttpClient.SendAsync("/locations", HttpMethod.Post, Json.ToJson(model));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response = await this.HttpClient.SendAsync("/weatherforecast", HttpMethod.Get);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var body = await response.Content.ReadAsStringAsync();
            var forecast = Json.ToObject<WeatherForecastModel[]>(body);
            forecast.Should().HaveCount(5);
            forecast.First().Should().Match<WeatherForecastModel>(x =>
                                 x.Location.City == model.City &&
                                 x.Location.State == model.State &&
                                 x.Location.Country == model.Country);
        }

        [Fact]
        public async Task RetrieveForecastForTomorrow()
        {
            var model = LocationData.NewLocationData();
            var response = await this.HttpClient.SendAsync("/locations", HttpMethod.Post, Json.ToJson(model));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response = await this.HttpClient.SendAsync("/weatherforecast/tomorrow", HttpMethod.Get);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var body = await response.Content.ReadAsStringAsync();
            var forecast = Json.ToObject<WeatherForecastModel>(body);
            forecast.Should().Match<WeatherForecastModel>(x =>
                                       x.Location.City == model.City &&
                                       x.Location.State == model.State &&
                                       x.Location.Country == model.Country);
        }
    }
}
