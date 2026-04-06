using System.Net.Http.Json;
using System.Text.Json;
using Rocket.Unsplash.Models;
using Rocket.Unsplash.Requests;

namespace Rocket.Unsplash;

public sealed class CurrentUserService(HttpClient client) : ICurrentUserService
{
    public async Task<User?> GetCurrentUserAsync(CancellationToken ct = default)
    {
        var response = await client.GetAsync("me", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<User>(response, ct).ConfigureAwait(false);
    }

    public async Task<User?> UpdateCurrentUserAsync(UpdateCurrentUserRequest request, CancellationToken ct = default)
    {
        var content = JsonContent.Create(request, options: UnsplashJson.Options);
        var response = await client.PutAsync("me", content, ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<User>(response, ct).ConfigureAwait(false);
    }
}
