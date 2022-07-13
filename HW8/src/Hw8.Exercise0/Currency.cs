using System.Text.Json.Serialization;

namespace Hw8.Exercise0;

public class Currency
{
    [JsonPropertyName("rate")]
    public decimal? Rate { get; set; }

    [JsonPropertyName("cc")]
    public string? CurrencyValue { get; set; }

    [JsonPropertyName("exchangedate")]
    public string? ExchangeDate { get; set; }
}
