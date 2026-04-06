using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record Collection
{
    [JsonPropertyName("id")] public int? Id { get; init; }
    [JsonPropertyName("title")] public string? Title { get; init; }
    [JsonPropertyName("description")] public string? Description { get; init; }
    [JsonPropertyName("published_at")] public DateTimeOffset? PublishedAt { get; init; }
    [JsonPropertyName("last_collected_at")] public DateTimeOffset? LastCollectedAt { get; init; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; init; }
    [JsonPropertyName("total_photos")] public int? TotalPhotos { get; init; }
    [JsonPropertyName("private")] public bool? Private { get; init; }
    [JsonPropertyName("share_key")] public string? ShareKey { get; init; }
    [JsonPropertyName("featured")] public bool? Featured { get; init; }
    [JsonPropertyName("cover_photo")] public Photo? CoverPhoto { get; init; }
    [JsonPropertyName("user")] public User? User { get; init; }
    [JsonPropertyName("links")] public CollectionLinks? Links { get; init; }
}
