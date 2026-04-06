using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record PhotoLinks
{
    [JsonPropertyName("self")] public string? Self { get; init; }
    [JsonPropertyName("html")] public string? Html { get; init; }
    [JsonPropertyName("download")] public string? Download { get; init; }
    [JsonPropertyName("download_location")] public string? DownloadLocation { get; init; }
}
