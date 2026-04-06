using System.Net.Http.Json;
using System.Text.Json;
using Rocket.Unsplash.Enums;
using Rocket.Unsplash.Models;
using Rocket.Unsplash.Results;

namespace Rocket.Unsplash;

public sealed class UsersService(HttpClient client) : IUsersService
{
    public async Task<User?> GetProfileAsync(string username, CancellationToken ct = default)
    {
        var response = await client.GetAsync($"users/{Uri.EscapeDataString(username)}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<User>(response, ct).ConfigureAwait(false);
    }

    public async Task<PaginatedResult<Photo>> ListPhotosAsync(string username, int page = 1, int perPage = 10,
        PhotosOrderBy? orderBy = null, Orientation? orientation = null, bool stats = false,
        string? resolution = null, int? quantity = null, CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("page", page > 1 ? page : null),
            ("per_page", perPage != 10 ? perPage : null),
            ("order_by", orderBy),
            ("orientation", orientation),
            ("stats", stats ? stats : null),
            ("resolution", resolution),
            ("quantity", quantity));

        var response = await client.GetAsync(
            $"users/{Uri.EscapeDataString(username)}/photos{qs}", ct).ConfigureAwait(false);
        var items = await ApiHelper.DeserializeAsync<List<Photo>>(response, ct).ConfigureAwait(false);
        return ApiHelper.BuildPaginatedResult<Photo>(items ?? [], response);
    }

    public async Task<PaginatedResult<Collection>> ListCollectionsAsync(string username, int page = 1,
        int perPage = 10, CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("page", page > 1 ? page : null),
            ("per_page", perPage != 10 ? perPage : null));

        var response = await client.GetAsync(
            $"users/{Uri.EscapeDataString(username)}/collections{qs}", ct).ConfigureAwait(false);
        var items = await ApiHelper.DeserializeAsync<List<Collection>>(response, ct).ConfigureAwait(false);
        return ApiHelper.BuildPaginatedResult<Collection>(items ?? [], response);
    }

    public async Task<UserStatistics?> GetStatisticsAsync(string username, string? resolution = null,
        int? quantity = null, CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("resolution", resolution),
            ("quantity", quantity));

        var response = await client.GetAsync(
            $"users/{Uri.EscapeDataString(username)}/statistics{qs}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<UserStatistics>(response, ct).ConfigureAwait(false);
    }
}
