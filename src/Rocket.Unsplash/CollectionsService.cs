using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Rocket.Unsplash.Enums;
using Rocket.Unsplash.Models;
using Rocket.Unsplash.Results;

namespace Rocket.Unsplash;

public sealed class CollectionsService(HttpClient client) : ICollectionsService
{
    public async Task<PaginatedResult<Collection>> ListAsync(int page = 1, int perPage = 10,
        CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("page", page > 1 ? page : null),
            ("per_page", perPage != 10 ? perPage : null));

        var response = await client.GetAsync($"collections{qs}", ct).ConfigureAwait(false);
        var items = await ApiHelper.DeserializeAsync<List<Collection>>(response, ct).ConfigureAwait(false);
        return ApiHelper.BuildPaginatedResult<Collection>(items ?? [], response);
    }

    public async Task<Collection?> GetAsync(int id, CancellationToken ct = default)
    {
        var response = await client.GetAsync($"collections/{id}", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<Collection>(response, ct).ConfigureAwait(false);
    }

    public async Task<PaginatedResult<Photo>> GetPhotosAsync(int id, int page = 1, int perPage = 10,
        Orientation? orientation = null, CancellationToken ct = default)
    {
        var qs = ApiHelper.BuildQueryString(
            ("page", page > 1 ? page : null),
            ("per_page", perPage != 10 ? perPage : null),
            ("orientation", orientation));

        var response = await client.GetAsync($"collections/{id}/photos{qs}", ct).ConfigureAwait(false);
        var items = await ApiHelper.DeserializeAsync<List<Photo>>(response, ct).ConfigureAwait(false);
        return ApiHelper.BuildPaginatedResult<Photo>(items ?? [], response);
    }

    public async Task<IReadOnlyList<Collection>> GetRelatedAsync(int id, CancellationToken ct = default)
    {
        var response = await client.GetAsync($"collections/{id}/related", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<List<Collection>>(response, ct).ConfigureAwait(false) ?? [];
    }

    public async Task<Collection?> CreateAsync(string title, string? description = null,
        bool? @private = null, CancellationToken ct = default)
    {
        var body = new Dictionary<string, object?> { ["title"] = title, ["description"] = description, ["private"] = @private };
        var content = JsonContent.Create(body, options: UnsplashJson.Options);
        var response = await client.PostAsync("collections", content, ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<Collection>(response, ct).ConfigureAwait(false);
    }

    public async Task<Collection?> UpdateAsync(int id, string? title = null, string? description = null,
        bool? @private = null, CancellationToken ct = default)
    {
        var body = new Dictionary<string, object?> { ["title"] = title, ["description"] = description, ["private"] = @private };
        var content = JsonContent.Create(body, options: UnsplashJson.Options);
        var response = await client.PutAsync($"collections/{id}", content, ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<Collection>(response, ct).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var response = await client.DeleteAsync($"collections/{id}", ct).ConfigureAwait(false);
        await ApiHelper.EnsureSuccess(response).ConfigureAwait(false);
    }

    public async Task<CollectionPhotoResult?> AddPhotoAsync(int collectionId, string photoId,
        CancellationToken ct = default)
    {
        var body = new Dictionary<string, object?> { ["photo_id"] = photoId };
        var content = JsonContent.Create(body, options: UnsplashJson.Options);
        var response = await client.PostAsync($"collections/{collectionId}/add", content, ct)
            .ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<CollectionPhotoResult>(response, ct).ConfigureAwait(false);
    }

    public async Task<CollectionPhotoResult?> RemovePhotoAsync(int collectionId, string photoId,
        CancellationToken ct = default)
    {
        var body = new Dictionary<string, object?> { ["photo_id"] = photoId };
        var content = JsonContent.Create(body, options: UnsplashJson.Options);
        var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Delete,
            $"collections/{collectionId}/remove") { Content = content }, ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<CollectionPhotoResult>(response, ct).ConfigureAwait(false);
    }
}
