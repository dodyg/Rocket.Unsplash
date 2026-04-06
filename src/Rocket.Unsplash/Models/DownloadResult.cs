using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record DownloadResult
{
    [JsonPropertyName("url")] public string? Url { get; init; }
}
