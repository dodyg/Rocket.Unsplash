namespace Rocket.Unsplash.Results;

public sealed record PaginatedResult<T>
{
    public required IReadOnlyList<T> Results { get; init; }
    public int Total { get; init; }
    public int TotalPages { get; init; }
    public int Page { get; init; }
    public int PerPage { get; init; }
}
