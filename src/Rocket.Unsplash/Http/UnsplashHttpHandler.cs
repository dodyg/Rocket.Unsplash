using System.Net.Http.Headers;
using Rocket.Unsplash.Configuration;

namespace Rocket.Unsplash.Http;

public sealed class UnsplashHttpHandler(UnsplashOptions options) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(options.BearerToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", options.BearerToken);
        }
        else if (!string.IsNullOrWhiteSpace(options.AccessKey))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Client-ID", options.AccessKey);
        }

        request.Headers.Accept.ParseAdd("application/json");
        request.Headers.TryAddWithoutValidation("Accept-Version", "v1");

        return base.SendAsync(request, cancellationToken);
    }
}
