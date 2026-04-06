using Rocket.Unsplash.Enums;
using Rocket.Unsplash.Models;
using Rocket.Unsplash.Results;

namespace Rocket.Unsplash;

public interface ITopicsService
{
    Task<PaginatedResult<Topic>> ListAsync(string? ids = null, int page = 1, int perPage = 10,
        TopicsOrderBy? orderBy = null, CancellationToken ct = default);
    Task<Topic?> GetAsync(string idOrSlug, CancellationToken ct = default);
    Task<PaginatedResult<Photo>> GetPhotosAsync(string idOrSlug, int page = 1, int perPage = 10,
        Orientation? orientation = null, TopicPhotosOrderBy? orderBy = null,
        CancellationToken ct = default);
}
