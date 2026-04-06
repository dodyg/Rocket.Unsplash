using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record CollectionPhotoResult
{
    [JsonPropertyName("photo")] public Photo? Photo { get; init; }
    [JsonPropertyName("collection")] public Collection? Collection { get; init; }
    [JsonPropertyName("user")] public User? User { get; init; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; init; }
}
