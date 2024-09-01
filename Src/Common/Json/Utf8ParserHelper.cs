using System.Buffers.Text;
using System.Text.Json;

namespace bybit.net.api.Json;

/// <summary>
/// Provides helper extension methods that allows parsing numbers from strings.
/// Default <see cref="Utf8JsonReader"/> will throw to get a number if it's represented as a string
/// </summary>
public static class UtfJsonReaderStringExtensions
{
    /// <summary>
    /// Gets decimal value from string
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    /// <exception cref="JsonException">Throws if failed to parse a number</exception>
    public static decimal GetDecimalFromString(this Utf8JsonReader reader)
    {
        ReadOnlySpan<byte> span = reader.ValueSpan;
        bool success = Utf8Parser.TryParse(span, out decimal result, out int bytesConsumed);
        
        if(!success || bytesConsumed != span.Length) 
        {
            throw new JsonException("Unable to parse decimal from string");
        }
        
        return result;
    }
    
    /// <summary>
    /// Gets int64 value from string
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    /// <exception cref="JsonException">Throws if failed to parse a number</exception>
    public static long GetInt64FromString(this Utf8JsonReader reader) 
    {
        ReadOnlySpan<byte> span = reader.ValueSpan;
        bool success = Utf8Parser.TryParse(span, out long result, out int bytesConsumed);
        
        if(!success || bytesConsumed != span.Length) 
        {
            throw new JsonException("Unable to parse long from string");
        }

        return result;
    }
}