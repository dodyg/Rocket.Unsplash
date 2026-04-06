using Rocket.Unsplash.Enums;
using Rocket.Unsplash.Models;

namespace Rocket.Unsplash;

public interface ISearchService
{
    Task<SearchPhotosResult?> SearchPhotosAsync(string query, int page = 1, int perPage = 10,
        SearchPhotosOrderBy? orderBy = null, string? collections = null,
        ContentFilter? contentFilter = null, string? color = null,
        Orientation? orientation = null, string? lang = null,
        CancellationToken ct = default);
    Task<SearchCollectionsResult?> SearchCollectionsAsync(string query, int page = 1, int perPage = 10,
        CancellationToken ct = default);
    Task<SearchUsersResult?> SearchUsersAsync(string query, int page = 1, int perPage = 10,
        CancellationToken ct = default);
}
