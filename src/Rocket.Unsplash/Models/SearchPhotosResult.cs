using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record SearchPhotosResult
{
    [JsonPropertyName("total")] public int? Total { get; init; }
    [JsonPropertyName("total_pages")] public int? TotalPages { get; init; }
    [JsonPropertyName("results")] public List<Photo>? Results { get; init; }
}
