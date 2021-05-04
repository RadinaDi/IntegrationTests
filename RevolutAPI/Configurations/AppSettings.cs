using Microsoft.Extensions.Configuration;
using System;

namespace RevolutAPI.Configurations
{
    public class AppSettings
    {
        public AppSettings(IConfiguration config)
        {
            this.BaseUrl = config["base_url"] ?? throw new ArgumentException(nameof(this.BaseUrl));
            this.AccessToken = config["access_token"] ?? throw new ArgumentException(nameof(this.AccessToken));
        }

        public string BaseUrl { get; set; }

        public string AccessToken { get; set; }
    }
}
