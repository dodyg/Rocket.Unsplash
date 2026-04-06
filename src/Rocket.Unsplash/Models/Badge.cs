using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record Badge
{
    [JsonPropertyName("title")] public string? Title { get; init; }
    [JsonPropertyName("primary")] public bool? Primary { get; init; }
    [JsonPropertyName("slug")] public string? Slug { get; init; }
    [JsonPropertyName("link")] public string? Link { get; init; }
}
