using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record PhotoLocation
{
    [JsonPropertyName("city")] public string? City { get; init; }
    [JsonPropertyName("country")] public string? Country { get; init; }
    [JsonPropertyName("position")] public GeoPosition? Position { get; init; }
}
