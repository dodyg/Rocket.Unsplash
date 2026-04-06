using Rocket.Unsplash.Models;
using Rocket.Unsplash.Tests.Helpers;

namespace Rocket.Unsplash.Tests.Services;

public sealed class CurrentUserServiceTests
{
    private static readonly string UserJson = """
    {
        "id": "pXhwzz1JtQU",
        "updated_at": "2016-07-10T11:00:01-05:00",
        "username": "jimmyexample",
        "first_name": "James",
        "last_name": "Example",
        "twitter_username": "jimmy",
        "portfolio_url": null,
        "bio": "The user's bio",
        "location": "Montreal, Qc",
        "total_collections": 5,
        "downloads": 4321,
        "uploads_remaining": 4,
        "instagram_username": "james-example",
        "email": "jim@example.com",
        "links": {
            "self": "https://api.unsplash.com/users/jimmyexample",
            "html": "https://unsplash.com/jimmyexample",
            "photos": "https://api.unsplash.com/users/jimmyexample/photos"
        }
    }
    """;

    [Test]
    public async Task GetCurrentUserAsync_ReturnsUser()
    {
        var handler = new MockHttpMessageHandler(UserJson);
        var http = new HttpClient(handler) { BaseAddress = new Uri("https://api.unsplash.com") };
        var service = new CurrentUserService(http);

        var user = await service.GetCurrentUserAsync();

        await Assert.That(user).IsNotNull();
        await Assert.That(user!.Id).IsEqualTo("pXhwzz1JtQU");
        await Assert.That(user.Username).IsEqualTo("jimmyexample");
        await Assert.That(user.FirstName).IsEqualTo("James");
        await Assert.That(user.LastName).IsEqualTo("Example");
        await Assert.That(user.Email).IsEqualTo("jim@example.com");
        await Assert.That(handler.LastRequest!.RequestUri!.AbsolutePath).IsEqualTo("/me");
    }

    [Test]
    public async Task UpdateCurrentUserAsync_SendsPutRequest()
    {
        var handler = new MockHttpMessageHandler(UserJson);
        var http = new HttpClient(handler) { BaseAddress = new Uri("https://api.unsplash.com") };
        var service = new CurrentUserService(http);

        var request = new Requests.UpdateCurrentUserRequest { FirstName = "Updated" };
        var user = await service.UpdateCurrentUserAsync(request);

        await Assert.That(user).IsNotNull();
        await Assert.That(user!.Username).IsEqualTo("jimmyexample");
        await Assert.That(handler.LastRequest!.Method).IsEqualTo(HttpMethod.Put);
    }
}
