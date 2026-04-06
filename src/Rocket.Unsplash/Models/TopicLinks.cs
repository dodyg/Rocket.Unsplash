using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record TopicLinks
{
    [JsonPropertyName("self")] public string? Self { get; init; }
    [JsonPropertyName("html")] public string? Html { get; init; }
    [JsonPropertyName("photos")] public string? Photos { get; init; }
}
