using System.Text.Json;
using Rocket.Unsplash.Enums;
using Rocket.Unsplash.Models;

namespace Rocket.Unsplash;

public sealed class SearchService(HttpClient client) : ISearchService
{
    public async Task<SearchPhotosResult?> SearchPhotosAsync(string query, int page = 1, int perPage = 10,
        SearchPhotosOrderBy? orderBy = null, string? collections = null,
        ContentFilter? contentFilter = null, string? color = null,
        Orientation? orientation = null, string? lang = null,
        CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("query", query),
            ("page", page > 1 ? page : null),
            ("per_page", perPage != 10 ? perPage : null),
            ("order_by", orderBy),
            ("collections", collections),
            ("content_filter", contentFilter),
            ("color", color),
            ("orientation", orientation),
            ("lang", lang));

        var response = await client.GetAsync($"search/photos{qs}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<SearchPhotosResult>(response, ct).ConfigureAwait(false);
    }

    public async Task<SearchCollectionsResult?> SearchCollectionsAsync(string query, int page = 1,
        int perPage = 10, CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("query", query),
            ("page", page > 1 ? page : null),
            ("per_page", perPage != 10 ? perPage : null));

        var response = await client.GetAsync($"search/collections{qs}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<SearchCollectionsResult>(response, ct).ConfigureAwait(false);
    }

    public async Task<SearchUsersResult?> SearchUsersAsync(string query, int page = 1, int perPage = 10,
        CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("query", query),
            ("page", page > 1 ? page : null),
            ("per_page", perPage != 10 ? perPage : null));

        var response = await client.GetAsync($"search/users{qs}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<SearchUsersResult>(response, ct).ConfigureAwait(false);
    }
}
