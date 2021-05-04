using Microsoft.Extensions.Configuration;
using RevolutAPI.Configurations;
using System;
using System.Net.Http;

namespace RevolutAPI
{
    public class BaseTest
    {
        public BaseTest()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("local.settings.json", false, false)
            .Build();

            this.Settings = new AppSettings(config);

            this.HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(this.Settings.BaseUrl)
            };

            this.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.Settings.AccessToken}");
        }

        protected HttpClient HttpClient { get; private set; }

        protected AppSettings Settings { get; set; }
    }
}