using System.Text.Json.Serialization;

namespace RevolutAPI.Models
{
    public class Transfer
    {

        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }

        [JsonPropertyName("source_account_id")]
        public string SourceAccountId { get; set; }

        [JsonPropertyName("target_account_id")]
        public string TargetAccountId { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

    }
}
