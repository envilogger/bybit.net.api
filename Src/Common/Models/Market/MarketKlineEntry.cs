using System.Text.Json.Serialization;
using bybit.net.api.Json;

namespace bybit.net.api.Models.Market
{
    [JsonConverter(typeof(MarketKLineEntryDeserializer))]
    public class MarketKlineEntry
    {
        public long StartTime { get; set; }

        public decimal OpenPrice { get; set; }

        public decimal HighPrice { get; set; }

        public decimal LowPrice { get; set; }

        public decimal ClosePrice { get; set; }

        public long Volume { get; set; }

        public decimal Turnover { get; set; }
    }
}