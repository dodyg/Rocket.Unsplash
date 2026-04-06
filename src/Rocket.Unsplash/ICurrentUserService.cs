using Rocket.Unsplash.Models;
using Rocket.Unsplash.Requests;

namespace Rocket.Unsplash;

public interface ICurrentUserService
{
    Task<User?> GetCurrentUserAsync(CancellationToken ct = default);
    Task<User?> UpdateCurrentUserAsync(UpdateCurrentUserRequest request, CancellationToken ct = default);
}
