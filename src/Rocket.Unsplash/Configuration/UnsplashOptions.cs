namespace Rocket.Unsplash.Configuration;

public sealed class UnsplashOptions
{
    public string? AccessKey { get; set; }
    public string? BearerToken { get; set; }
    public string BaseUrl { get; set; } = "https://api.unsplash.com";
}
