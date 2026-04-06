using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record ProfileImage
{
    [JsonPropertyName("small")] public string? Small { get; init; }
    [JsonPropertyName("medium")] public string? Medium { get; init; }
    [JsonPropertyName("large")] public string? Large { get; init; }
}
