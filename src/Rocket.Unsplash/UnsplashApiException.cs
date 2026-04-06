namespace Rocket.Unsplash;

public sealed class UnsplashApiException : Exception
{
    public int StatusCode { get; }
    public IReadOnlyList<string> Errors { get; }

    public UnsplashApiException(int statusCode, IReadOnlyList<string> errors)
        : base($"Unsplash API error ({statusCode}): {string.Join(", ", errors)}")
    {
        StatusCode = statusCode;
        Errors = errors;
    }
}
