using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record Totals
{
    [JsonPropertyName("photos")] public long? Photos { get; init; }
    [JsonPropertyName("downloads")] public long? Downloads { get; init; }
    [JsonPropertyName("views")] public long? Views { get; init; }
    [JsonPropertyName("photographers")] public long? Photographers { get; init; }
    [JsonPropertyName("pixels")] public long? Pixels { get; init; }
    [JsonPropertyName("downloads_per_second")] public int? DownloadsPerSecond { get; init; }
    [JsonPropertyName("views_per_second")] public int? ViewsPerSecond { get; init; }
    [JsonPropertyName("developers")] public int? Developers { get; init; }
    [JsonPropertyName("applications")] public int? Applications { get; init; }
    [JsonPropertyName("requests")] public long? Requests { get; init; }
}
