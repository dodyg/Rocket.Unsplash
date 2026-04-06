using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record Social
{
    [JsonPropertyName("instagram_username")] public string? InstagramUsername { get; init; }
    [JsonPropertyName("portfolio_url")] public string? PortfolioUrl { get; init; }
    [JsonPropertyName("twitter_username")] public string? TwitterUsername { get; init; }
}
