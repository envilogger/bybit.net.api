using System.Text.Json.Serialization;

namespace bybit.net.api.Models.Account.Response
{
    public class BatchSetCollateralCoinResult
    {
        [JsonPropertyName("list")]
        public List<CollateralCoinEntry>? collateralCoinEntries { get; set; }
    }
}
