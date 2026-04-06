using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record MonthStats
{
    [JsonPropertyName("downloads")] public long? Downloads { get; init; }
    [JsonPropertyName("views")] public long? Views { get; init; }
    [JsonPropertyName("new_photos")] public long? NewPhotos { get; init; }
    [JsonPropertyName("new_photographers")] public int? NewPhotographers { get; init; }
    [JsonPropertyName("new_pixels")] public long? NewPixels { get; init; }
    [JsonPropertyName("new_developers")] public int? NewDevelopers { get; init; }
    [JsonPropertyName("new_applications")] public int? NewApplications { get; init; }
    [JsonPropertyName("new_requests")] public long? NewRequests { get; init; }
}
