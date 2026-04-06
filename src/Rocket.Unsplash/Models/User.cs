using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record User
{
    [JsonPropertyName("id")] public string? Id { get; init; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; init; }
    [JsonPropertyName("username")] public string? Username { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("first_name")] public string? FirstName { get; init; }
    [JsonPropertyName("last_name")] public string? LastName { get; init; }
    [JsonPropertyName("twitter_username")] public string? TwitterUsername { get; init; }
    [JsonPropertyName("instagram_username")] public string? InstagramUsername { get; init; }
    [JsonPropertyName("portfolio_url")] public string? PortfolioUrl { get; init; }
    [JsonPropertyName("bio")] public string? Bio { get; init; }
    [JsonPropertyName("location")] public string? Location { get; init; }
    [JsonPropertyName("total_collections")] public int? TotalCollections { get; init; }
    [JsonPropertyName("total_likes")] public int? TotalLikes { get; init; }
    [JsonPropertyName("total_photos")] public int? TotalPhotos { get; init; }
    [JsonPropertyName("downloads")] public int? Downloads { get; init; }
    [JsonPropertyName("uploads_remaining")] public int? UploadsRemaining { get; init; }
    [JsonPropertyName("email")] public string? Email { get; init; }
    [JsonPropertyName("links")] public UserLinks? Links { get; init; }
    [JsonPropertyName("profile_image")] public ProfileImage? ProfileImage { get; init; }
    [JsonPropertyName("social")] public Social? Social { get; init; }
    [JsonPropertyName("badge")] public Badge? Badge { get; init; }
}
