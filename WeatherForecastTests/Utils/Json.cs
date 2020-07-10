using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace WeatherForecastTests.Utils
{
    public static class Json
    {
        public static string ToJson(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer()
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

            return JObject.FromObject(obj, jsonSerializer).ToString();
        }

        public static T ToObject<T>(string content)
        {
            if (string.IsNullOrEmpty(content) || string.IsNullOrWhiteSpace(content))
            {
                return default(T);
            }

            JsonSerializerSettings settings = new JsonSerializerSettings()
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

            return JsonConvert.DeserializeObject<T>(content, settings);
        }
    }
}
