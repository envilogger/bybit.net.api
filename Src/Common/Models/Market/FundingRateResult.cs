using System.Text.Json.Serialization;

namespace bybit.net.api.Models.Market
{
    public class FundingRateResult
    {
        [JsonPropertyName("category")]
        public String? Category { get; set; }

        [JsonPropertyName("list")]
        public List<FundingRateEntry>? FundingRateEntries { get; set; }
    }
}
