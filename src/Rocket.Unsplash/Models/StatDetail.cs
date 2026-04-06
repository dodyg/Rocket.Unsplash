using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record StatDetail
{
    [JsonPropertyName("total")] public int? Total { get; init; }
    [JsonPropertyName("historical")] public Historical? Historical { get; init; }
}
