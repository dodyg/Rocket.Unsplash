using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record SearchCollectionsResult
{
    [JsonPropertyName("total")] public int? Total { get; init; }
    [JsonPropertyName("total_pages")] public int? TotalPages { get; init; }
    [JsonPropertyName("results")] public List<Collection>? Results { get; init; }
}
