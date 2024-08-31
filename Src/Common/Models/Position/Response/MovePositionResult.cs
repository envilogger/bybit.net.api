using System.Text.Json.Serialization;

namespace bybit.net.api.Models.Position.Response
{
    public class MovePositionResult
    {
        [JsonPropertyName("blockTradeId")]
        public string? blockTradeId { get; set; }

        [JsonPropertyName("status")]
        public string? status { get; set; }

        [JsonPropertyName("rejectParty")]
        public string? rejectParty { get; set; }
    }
}
