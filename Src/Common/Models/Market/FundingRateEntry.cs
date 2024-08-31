using System.Text.Json.Serialization;

namespace bybit.net.api.Models.Market
{
    public class FundingRateEntry
    {
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("fundingRate")]
        public string? FundingRate { get; set; }

        [JsonPropertyName("fundingRateTimestamp")]
        public long? FundingRateTimestamp { get; set; }
    }
}