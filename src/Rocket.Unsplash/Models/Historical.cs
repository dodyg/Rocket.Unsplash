using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record Historical
{
    [JsonPropertyName("change")] public int? Change { get; init; }
    [JsonPropertyName("average")] public int? Average { get; init; }
    [JsonPropertyName("resolution")] public string? Resolution { get; init; }
    [JsonPropertyName("quantity")] public int? Quantity { get; init; }
    [JsonPropertyName("values")] public List<StatValue>? Values { get; init; }
}
