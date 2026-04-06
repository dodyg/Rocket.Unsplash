using System.Text.Json.Serialization;

namespace Rocket.Unsplash.Models;

public sealed record Tag
{
    [JsonPropertyName("title")] public string? Title { get; init; }
}
