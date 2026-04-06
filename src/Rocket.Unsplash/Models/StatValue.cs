using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record StatValue
{
    [JsonPropertyName("date")] public string? Date { get; init; }
    [JsonPropertyName("value")] public int? Value { get; init; }
}
