using Rocket.Unsplash.Enums;
using Rocket.Unsplash.Models;
using Rocket.Unsplash.Results;

namespace Rocket.Unsplash;

public interface ICollectionsService
{
    Task<PaginatedResult<Collection>> ListAsync(int page = 1, int perPage = 10, CancellationToken ct = default);
    Task<Collection?> GetAsync(int id, CancellationToken ct = default);
    Task<PaginatedResult<Photo>> GetPhotosAsync(int id, int page = 1, int perPage = 10,
        Orientation? orientation = null, CancellationToken ct = default);
    Task<IReadOnlyList<Collection>> GetRelatedAsync(int id, CancellationToken ct = default);
    Task<Collection?> CreateAsync(string title, string? description = null, bool? @private = null,
        CancellationToken ct = default);
    Task<Collection?> UpdateAsync(int id, string? title = null, string? description = null,
        bool? @private = null, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
    Task<CollectionPhotoResult?> AddPhotoAsync(int collectionId, string photoId, CancellationToken ct = default);
    Task<CollectionPhotoResult?> RemovePhotoAsync(int collectionId, string photoId, CancellationToken ct = default);
}
