using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record Topic
{
    [JsonPropertyName("id")] public string? Id { get; init; }
    [JsonPropertyName("slug")] public string? Slug { get; init; }
    [JsonPropertyName("title")] public string? Title { get; init; }
    [JsonPropertyName("description")] public string? Description { get; init; }
    [JsonPropertyName("published_at")] public DateTimeOffset? PublishedAt { get; init; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; init; }
    [JsonPropertyName("starts_at")] public DateTimeOffset? StartsAt { get; init; }
    [JsonPropertyName("ends_at")] public DateTimeOffset? EndsAt { get; init; }
    [JsonPropertyName("only_submissions_after")] public DateTimeOffset? OnlySubmissionsAfter { get; init; }
    [JsonPropertyName("visibility")] public string? Visibility { get; init; }
    [JsonPropertyName("featured")] public bool? Featured { get; init; }
    [JsonPropertyName("total_photos")] public int? TotalPhotos { get; init; }
    [JsonPropertyName("status")] public string? Status { get; init; }
    [JsonPropertyName("owners")] public List<User>? Owners { get; init; }
    [JsonPropertyName("top_contributors")] public List<User>? TopContributors { get; init; }
    [JsonPropertyName("cover_photo")] public Photo? CoverPhoto { get; init; }
    [JsonPropertyName("preview_photos")] public List<PreviewPhoto>? PreviewPhotos { get; init; }
    [JsonPropertyName("links")] public TopicLinks? Links { get; init; }
}
