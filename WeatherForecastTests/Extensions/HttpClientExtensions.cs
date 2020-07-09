using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastTests.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> SendAsync(this HttpClient client, string url, HttpMethod method, object body = null)
        {
            switch (method.Method.ToLower())
            {
                case "get":
                    return await client.GetAsync(url);
                case "post":
                    var json = JsonConvert.SerializeObject(body);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    return await client.PostAsync(url, content);
                case "delete":
                    return await client.DeleteAsync(url);
                default:
                    return await Task.FromResult(default(HttpResponseMessage));
            }
        }
    }
}
