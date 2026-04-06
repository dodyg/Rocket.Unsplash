using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record PhotoUrls
{
    [JsonPropertyName("raw")] public string? Raw { get; init; }
    [JsonPropertyName("full")] public string? Full { get; init; }
    [JsonPropertyName("regular")] public string? Regular { get; init; }
    [JsonPropertyName("small")] public string? Small { get; init; }
    [JsonPropertyName("thumb")] public string? Thumb { get; init; }
}
