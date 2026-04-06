using System.Net.Http.Json;
using System.Text.Json;
using Rocket.Unsplash.Enums;
using Rocket.Unsplash.Models;
using Rocket.Unsplash.Requests;
using Rocket.Unsplash.Results;

namespace Rocket.Unsplash;

public sealed class PhotosService(HttpClient client) : IPhotosService
{
    public async Task<PaginatedResult<Photo>> ListAsync(int page = 1, int perPage = 10,
        CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("page", page > 1 ? page : null),
            ("per_page", perPage != 10 ? perPage : null));

        var response = await client.GetAsync($"photos{qs}", ct).ConfigureAwait(false);
        var items = await ApiHelper.DeserializeAsync<List<Photo>>(response, ct).ConfigureAwait(false);
        return ApiHelper.BuildPaginatedResult<Photo>(items ?? [], response);
    }

    public async Task<Photo?> GetAsync(string id, CancellationToken ct = default)
    {
        var response = await client.GetAsync($"photos/{Uri.EscapeDataString(id)}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<Photo>(response, ct).ConfigureAwait(false);
    }

    public async Task<Photo?> GetRandomAsync(string? collections = null, string? topics = null,
        string? username = null, string? query = null, Orientation? orientation = null,
        ContentFilter? contentFilter = null, CancellationToken ct = default)
    {
        var qs = BuildRandomQuery(collections, topics, username, query, orientation, contentFilter, null);
        var response = await client.GetAsync($"photos/random{qs}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<Photo>(response, ct).ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<Photo>> GetRandomAsync(int count, string? collections = null,
        string? topics = null, string? username = null, string? query = null,
        Orientation? orientation = null, ContentFilter? contentFilter = null,
        CancellationToken ct = default)
    {
        var qs = BuildRandomQuery(collections, topics, username, query, orientation, contentFilter,
            count > 1 ? count : 1);
        var response = await client.GetAsync($"photos/random{qs}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<List<Photo>>(response, ct).ConfigureAwait(false) ?? [];
    }

    public async Task<PhotoStatistics?> GetStatisticsAsync(string id, string? resolution = null,
        int? quantity = null, CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("resolution", resolution),
            ("quantity", quantity));

        var response = await client.GetAsync(
            $"photos/{Uri.EscapeDataString(id)}/statistics{qs}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<PhotoStatistics>(response, ct).ConfigureAwait(false);
    }

    public async Task<DownloadResult?> TrackDownloadAsync(string id, CancellationToken ct = default)
    {
        var response = await client.GetAsync(
            $"photos/{Uri.EscapeDataString(id)}/download", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<DownloadResult>(response, ct).ConfigureAwait(false);
    }

    public async Task<Photo?> UpdateAsync(string id, UpdatePhotoRequest request, CancellationToken ct = default)
    {
        var content = JsonContent.Create(request, options: UnsplashJson.Options);
        var response = await client.PutAsync($"photos/{Uri.EscapeDataString(id)}", content, ct)
            .ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<Photo>(response, ct).ConfigureAwait(false);
    }

    private static string BuildRandomQuery(string? collections, string? topics, string? username,
        string? query, Orientation? orientation, ContentFilter? contentFilter, int? count)
    {
        return ApiHelper.BuildQueryString(
            ("collections", collections),
            ("topics", topics),
            ("username", username),
            ("query", query),
            ("orientation", orientation),
            ("content_filter", contentFilter),
            ("count", count));
    }
}
