using System.Text.Json.Serialization;

namespace bybit.net.api.Models
{
    public class GeneralResponse<T>
    {
        [JsonPropertyName("retCode")]
        public int? RetCode { get; set; }

        [JsonPropertyName("retMsg")]
        public string? RetMsg { get; set; }

        [JsonPropertyName("result")]
        public T? Result { get; set; }

        [JsonPropertyName("retExtInfo")]
        public Dictionary<string, object>? RetExtInfo { get; set; }

        [JsonPropertyName("time")]
        public long? Time { get; set; }
    }
}
