using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record CollectionLinks
{
    [JsonPropertyName("self")] public string? Self { get; init; }
    [JsonPropertyName("html")] public string? Html { get; init; }
    [JsonPropertyName("photos")] public string? Photos { get; init; }
    [JsonPropertyName("related")] public string? Related { get; init; }
}
