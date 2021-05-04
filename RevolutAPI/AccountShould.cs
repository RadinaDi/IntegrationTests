using FluentAssertions;
using RevolutAPI.Data;
using RevolutAPI.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace RevolutAPI
{
    public class AccountShould : BaseTest
    {
        [Theory]
        [InlineData("b945c622-58a0-42b7-b6e9-b46815571489", "Main", 28600, "GBP")]
        [InlineData("0fe1adb4-d4d9-4801-9faa-e398748a1320", "Payments", 5300, "AUD")]
        public async Task HaveValidData(string id, string name, decimal balance, string currency)
        {
            var response = await this.HttpClient.GetAsync($"accounts/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var data = await response.Content.ReadAsStringAsync();

            var account = JsonSerializer.Deserialize<Account>(data);
            account.Should().Match<Account>(a => a.Name == name &&
                                                 a.Balance == balance &&
                                                 a.Currency == currency);
        }

        [Fact]
        public async Task TransferMoney()
        {
            var model = TransferData.NewTransfer()
                                    .WithSourceAccountId("76b3c339-6ce4-43b8-b8cb-12a0c34b6ff4")
                                    .WithTargetAccountId("b6d42a45-da2e-4e53-aafe-74d4ea6b1fb8")
                                    .WithAmount(1)
                                    .WithCurrency("USD");


            var body = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await this.HttpClient.PostAsync("transfer", body);           
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
