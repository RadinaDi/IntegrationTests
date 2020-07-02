using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using WeatherForecast;
using Xunit;

namespace WeatherForecastTests
{
    public class BaseTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        public BaseTest(WebApplicationFactory<Startup> fixture)
        {
            var clientOptions = new WebApplicationFactoryClientOptions();
            clientOptions.BaseAddress = new Uri("http://localhost:52611");

            this.HttpClient = fixture.CreateClient(clientOptions);
        }

        protected HttpClient HttpClient { get; private set; }
    }
}
