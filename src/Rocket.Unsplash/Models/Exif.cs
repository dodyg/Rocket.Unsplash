using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record Exif
{
    [JsonPropertyName("make")] public string? Make { get; init; }
    [JsonPropertyName("model")] public string? Model { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("exposure_time")] public string? ExposureTime { get; init; }
    [JsonPropertyName("aperture")] public string? Aperture { get; init; }
    [JsonPropertyName("focal_length")] public string? FocalLength { get; init; }
    [JsonPropertyName("iso")] public int? Iso { get; init; }
}
