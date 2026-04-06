namespace Rocket.Unsplash.Requests;

public sealed record UpdateCurrentUserRequest
{
    public string? Username { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Url { get; init; }
    public string? Location { get; init; }
    public string? Bio { get; init; }
    public string? InstagramUsername { get; init; }
}
