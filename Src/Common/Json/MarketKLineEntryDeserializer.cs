using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using bybit.net.api.Models.Market;

namespace bybit.net.api.Json;

/// <summary>
/// Provides Read method to deserialize KLine data
/// </summary>
/// <remarks>
/// ByBit API return KLine data as an array of strings in order: timestamp, open, high, low, close, volume, turnover, 
/// thus custom deserializer is required
/// </remarks>
public class MarketKLineEntryDeserializer : JsonConverter<MarketKlineEntry>
{
  /// <summary>
  /// Reads KLine data from provided <see cref="Utf8JsonReader"/>, expecting that it points to an array beginning
  /// </summary>
  /// <param name="reader">Json reader</param>
  /// <param name="typeToConvert"></param>
  /// <param name="options"></param>
  /// <returns>New instance of <see cref="MarketKlineEntry"/></returns>
  /// <exception cref="JsonException">Throws in case reader does not point at an array</exception>
  public override MarketKlineEntry Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    reader.Read();
    if(reader.TokenType != JsonTokenType.StartArray)
      throw new JsonException("Expected an array.");

    reader.Read();
    long timeStart = reader.GetInt64FromString();

    reader.Read();
    decimal openPrice = reader.GetDecimalFromString();
    
    reader.Read();
    decimal highPrice = reader.GetDecimalFromString();
    
    reader.Read();
    decimal lowPrice = reader.GetDecimalFromString();
    
    reader.Read();
    decimal closePrice = reader.GetDecimalFromString();
    
    reader.Read();
    long volume = reader.GetInt64FromString();
    
    reader.Read();
    decimal turnover = reader.GetDecimalFromString();

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