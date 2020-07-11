using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WeatherForecastTests.Utils
{
    public static class Json
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
                {
                    OverrideSpecifiedNames = true,
                    ProcessDictionaryKeys = true,
                },
            },
        };

        public static string ToJson(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T ToObject<T>(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(content, settings);
        }
    }
}
