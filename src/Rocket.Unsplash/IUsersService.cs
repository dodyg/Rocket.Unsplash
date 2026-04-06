using Rocket.Unsplash.Enums;
using Rocket.Unsplash.Models;
using Rocket.Unsplash.Results;

namespace Rocket.Unsplash;

public interface IUsersService
{
    Task<User?> GetProfileAsync(string username, CancellationToken ct = default);
    Task<PaginatedResult<Photo>> ListPhotosAsync(string username, int page = 1, int perPage = 10,
        PhotosOrderBy? orderBy = null, Orientation? orientation = null, bool stats = false,
        string? resolution = null, int? quantity = null, CancellationToken ct = default);
    Task<PaginatedResult<Collection>> ListCollectionsAsync(string username, int page = 1, int perPage = 10,
        CancellationToken ct = default);
    Task<UserStatistics?> GetStatisticsAsync(string username, string? resolution = null, int? quantity = null,
        CancellationToken ct = default);
}
