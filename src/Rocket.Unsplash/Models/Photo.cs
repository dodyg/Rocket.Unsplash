using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record Photo
{
    [JsonPropertyName("id")] public string? Id { get; init; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; init; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; init; }
    [JsonPropertyName("width")] public int? Width { get; init; }
    [JsonPropertyName("height")] public int? Height { get; init; }
    [JsonPropertyName("color")] public string? Color { get; init; }
    [JsonPropertyName("blur_hash")] public string? BlurHash { get; init; }
    [JsonPropertyName("description")] public string? Description { get; init; }
    [JsonPropertyName("alt_description")] public string? AltDescription { get; init; }
    [JsonPropertyName("downloads")] public int? Downloads { get; init; }
    [JsonPropertyName("public_domain")] public bool? PublicDomain { get; init; }
    [JsonPropertyName("likes")] public int? Likes { get; init; }
    [JsonPropertyName("liked_by_user")] public bool? LikedByUser { get; init; }
    [JsonPropertyName("sponsorship")] public object? Sponsorship { get; init; }
    [JsonPropertyName("user")] public User? User { get; init; }
    [JsonPropertyName("current_user_collections")] public List<Collection>? CurrentUserCollections { get; init; }
    [JsonPropertyName("urls")] public PhotoUrls? Urls { get; init; }
    [JsonPropertyName("links")] public PhotoLinks? Links { get; init; }
    [JsonPropertyName("exif")] public Exif? Exif { get; init; }
    [JsonPropertyName("location")] public PhotoLocation? Location { get; init; }
    [JsonPropertyName("tags")] public List<Tag>? Tags { get; init; }
    [JsonPropertyName("statistics")] public PhotoStatistics? Statistics { get; init; }
}
