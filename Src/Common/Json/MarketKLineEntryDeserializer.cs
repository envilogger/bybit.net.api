using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using bybit.net.api.Models.Market;

namespace bybit.net.api.Json;

public class MarketKLineEntryDeserializer : JsonConverter<MarketKlineEntry>
{
  public override MarketKlineEntry? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    reader.Read();
    if(reader.TokenType != JsonTokenType.StartArray)
      throw new JsonException("Expected an array.");

    reader.Read();
    ReadOnlySpan<byte> span = reader.ValueSpan;
    Utf8Parser.TryParse(span, out long timeStart, out _);

    reader.Read();
    span = reader.ValueSpan;
    Utf8Parser.TryParse(span, out decimal openPrice, out _);
    reader.Read();
    span = reader.ValueSpan;
    Utf8Parser.TryParse(span, out decimal highPrice, out _);
    reader.Read();
    span = reader.ValueSpan;
    Utf8Parser.TryParse(span, out decimal lowPrice, out _);
    reader.Read();
    span = reader.ValueSpan;
    Utf8Parser.TryParse(span, out decimal closePrice, out _);
    reader.Read();
    span = reader.ValueSpan;
    Utf8Parser.TryParse(span, out long volume, out _);
    reader.Read();
    span = reader.ValueSpan;
    Utf8Parser.TryParse(span, out decimal turnover, out _);

    return new MarketKlineEntry
    {
      StartTime = timeStart,
      OpenPrice = openPrice,
      HighPrice = highPrice,
      LowPrice = lowPrice,
      ClosePrice = closePrice,
      Volume = volume,
      Turnover = turnover
    };
  }

  public override void Write(Utf8JsonWriter writer, MarketKlineEntry value, JsonSerializerOptions options)
  {
    throw new NotImplementedException();
  }
}