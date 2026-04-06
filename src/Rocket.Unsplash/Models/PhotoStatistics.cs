using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record PhotoStatistics
{
    [JsonPropertyName("id")] public string? Id { get; init; }
    [JsonPropertyName("downloads")] public StatDetail? Downloads { get; init; }
    [JsonPropertyName("views")] public StatDetail? Views { get; init; }
}
