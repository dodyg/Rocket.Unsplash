using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record GeoPosition
{
    [JsonPropertyName("latitude")] public double? Latitude { get; init; }
    [JsonPropertyName("longitude")] public double? Longitude { get; init; }
}
