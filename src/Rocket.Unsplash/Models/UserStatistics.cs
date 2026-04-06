using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record UserStatistics
{
    [JsonPropertyName("username")] public string? Username { get; init; }
    [JsonPropertyName("downloads")] public StatDetail? Downloads { get; init; }
    [JsonPropertyName("views")] public StatDetail? Views { get; init; }
}
