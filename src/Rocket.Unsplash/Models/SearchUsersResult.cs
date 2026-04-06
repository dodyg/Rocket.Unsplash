using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record SearchUsersResult
{
    [JsonPropertyName("total")] public int? Total { get; init; }
    [JsonPropertyName("total_pages")] public int? TotalPages { get; init; }
    [JsonPropertyName("results")] public List<User>? Results { get; init; }
}
