using System.Text.Json.Serialization;

namespace bybit.net.api.Models.Market
{
    public class MarketKLineResult
    {
        [JsonPropertyName("category")]
        public String? Category { get; set; }

        [JsonPropertyName("symbol")]
        public String? Symbol { get; set; }

        [JsonPropertyName("list")]
        public List<MarketKlineEntry>? MarketKlineEntries { get; set; }
    }
}
