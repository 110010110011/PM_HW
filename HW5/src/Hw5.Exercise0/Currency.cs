using System.Text.Json.Serialization;

namespace Hw5.Exercise0;

internal class Currency
{
    [JsonPropertyName("r030")]
    [JsonIgnore]
    public int R030 { get; set; }

    [JsonPropertyName("txt")]
    [JsonIgnore]
    public string? Txt { get; set; }

    [JsonPropertyName("rate")]
    public decimal? Rate { get; set; }

    [JsonPropertyName("cc")]
    public string? CurrencyValue { get; set; }

    [JsonPropertyName("exchangedate")]
    public string? ExchangeDate { get; set; }
}
