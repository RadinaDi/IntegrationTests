using System.Collections.Generic;
using System.Linq;
using WeatherForecast.Models;

namespace WeatherForecast.Storage
{
    public class LocationStorage
    {
        private static List<LocationModel> locations = new List<LocationModel>();

        public static LocationStorage Instance => new LocationStorage();

        public int Length => locations.Count();

        public LocationModel this[int index]
        {
            get
            {
                return locations[index];
            }
        }

        public void Add(LocationModel location)
        {
            locations.Add(location);
        }
    }
}
