using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record PreviewPhoto
{
    [JsonPropertyName("id")] public string? Id { get; init; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; init; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; init; }
    [JsonPropertyName("urls")] public PhotoUrls? Urls { get; init; }
}
