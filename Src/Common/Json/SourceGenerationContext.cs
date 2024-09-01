using System.Text.Json.Serialization;
using bybit.net.api.Models;
using bybit.net.api.Models.Market;

namespace bybit.net.api.Json;

[JsonSerializable(typeof(MarketKlineEntry))]
[JsonSerializable(typeof(MarketKLineResult))]
[JsonSerializable(typeof(GeneralResponse<MarketKLineResult>))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}