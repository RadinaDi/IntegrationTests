using System;
using WeatherForecast.Models;
using WeatherForecastTests.Extensions;

namespace WeatherForecastTests.Data
{
    public static class LocationData
    {
        private static Random random = new Random();

        public static LocationModel NewLocationData()
        {
            return new LocationModel()
            {
                City = random.NextString(maxLength: 256),
                State = random.NextString(maxLength: 256),
                Country = random.NextString(maxLength: 256),
            };
        }
    }
}
