using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record UserLinks
{
    [JsonPropertyName("self")] public string? Self { get; init; }
    [JsonPropertyName("html")] public string? Html { get; init; }
    [JsonPropertyName("photos")] public string? Photos { get; init; }
    [JsonPropertyName("portfolio")] public string? Portfolio { get; init; }
    [JsonPropertyName("followers")] public string? Followers { get; init; }
    [JsonPropertyName("following")] public string? Following { get; init; }
}
