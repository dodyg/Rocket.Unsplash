using Rocket.Unsplash.Enums;
using Rocket.Unsplash.Models;
using Rocket.Unsplash.Requests;
using Rocket.Unsplash.Results;

namespace Rocket.Unsplash;

public interface IPhotosService
{
    Task<PaginatedResult<Photo>> ListAsync(int page = 1, int perPage = 10, CancellationToken ct = default);
    Task<Photo?> GetAsync(string id, CancellationToken ct = default);
    Task<Photo?> GetRandomAsync(string? collections = null, string? topics = null,
        string? username = null, string? query = null, Orientation? orientation = null,
        ContentFilter? contentFilter = null, CancellationToken ct = default);
    Task<IReadOnlyList<Photo>> GetRandomAsync(int count, string? collections = null, string? topics = null,
        string? username = null, string? query = null, Orientation? orientation = null,
        ContentFilter? contentFilter = null, CancellationToken ct = default);
    Task<PhotoStatistics?> GetStatisticsAsync(string id, string? resolution = null, int? quantity = null,
        CancellationToken ct = default);
    Task<DownloadResult?> TrackDownloadAsync(string id, CancellationToken ct = default);
    Task<Photo?> UpdateAsync(string id, UpdatePhotoRequest request, CancellationToken ct = default);
}
