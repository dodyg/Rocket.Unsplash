using System.Text.Json;
using Rocket.Unsplash.Enums;
using Rocket.Unsplash.Models;
using Rocket.Unsplash.Results;

namespace Rocket.Unsplash;

public sealed class TopicsService(HttpClient client) : ITopicsService
{
    public async Task<PaginatedResult<Topic>> ListAsync(string? ids = null, int page = 1, int perPage = 10,
        TopicsOrderBy? orderBy = null, CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("ids", ids),
            ("page", page > 1 ? page : null),
            ("per_page", perPage != 10 ? perPage : null),
            ("order_by", orderBy));

        var response = await client.GetAsync($"topics{qs}", ct).ConfigureAwait(false);
        var items = await ApiHelper.DeserializeAsync<List<Topic>>(response, ct).ConfigureAwait(false);
        return ApiHelper.BuildPaginatedResult<Topic>(items ?? [], response);
    }

    public async Task<Topic?> GetAsync(string idOrSlug, CancellationToken ct = default)
    {
        var response = await client.GetAsync(
            $"topics/{Uri.EscapeDataString(idOrSlug)}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<Topic>(response, ct).ConfigureAwait(false);
    }

    public async Task<PaginatedResult<Photo>> GetPhotosAsync(string idOrSlug, int page = 1, int perPage = 10,
        Orientation? orientation = null, TopicPhotosOrderBy? orderBy = null,
        CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("page", page > 1 ? page : null),
            ("per_page", perPage != 10 ? perPage : null),
            ("orientation", orientation),
            ("order_by", orderBy));

        var response = await client.GetAsync(
            $"topics/{Uri.EscapeDataString(idOrSlug)}/photos{qs}", ct).ConfigureAwait(false);
        var items = await ApiHelper.DeserializeAsync<List<Photo>>(response, ct).ConfigureAwait(false);
        return ApiHelper.BuildPaginatedResult<Photo>(items ?? [], response);
    }
}
