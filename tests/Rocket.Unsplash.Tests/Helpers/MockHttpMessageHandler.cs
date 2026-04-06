using System.Net;

namespace Rocket.Unsplash.Tests.Helpers;

public sealed class MockHttpMessageHandler(string responseContent, HttpStatusCode statusCode = HttpStatusCode.OK)
    : HttpMessageHandler
{
    public HttpRequestMessage? LastRequest { get; private set; }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        LastRequest = request;
        var response = new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(responseContent, System.Text.Encoding.UTF8, "application/json")
        };

        response.Headers.Add("X-Total", "100");
        response.Headers.Add("X-Per-Page", "10");

        return Task.FromResult(response);
    }

    public static HttpClient CreateClient(string responseContent, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var handler = new MockHttpMessageHandler(responseContent, statusCode);
        var client = new HttpClient(handler) { BaseAddress = new Uri("https://api.unsplash.com") };
        return client;
    }
}
