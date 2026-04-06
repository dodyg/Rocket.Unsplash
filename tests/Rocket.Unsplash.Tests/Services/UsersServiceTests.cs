using Rocket.Unsplash.Models;
using Rocket.Unsplash.Tests.Helpers;

namespace Rocket.Unsplash.Tests.Services;

public sealed class UsersServiceTests
{
    private static readonly string UserProfileJson = """
    {
        "id": "pXhwzz1JtQU",
        "username": "jimmyexample",
        "name": "James Example",
        "first_name": "James",
        "last_name": "Example",
        "bio": "The user's bio",
        "location": "Montreal, Qc",
        "total_collections": 5,
        "downloads": 225974,
        "links": {
            "self": "https://api.unsplash.com/users/jimmyexample",
            "html": "https://unsplash.com/jimmyexample",
            "photos": "https://api.unsplash.com/users/jimmyexample/photos"
        }
    }
    """;

    [Test]
    public async Task GetProfileAsync_ReturnsUser()
    {
        var http = MockHttpMessageHandler.CreateClient(UserProfileJson);
        var service = new UsersService(http);

        var user = await service.GetProfileAsync("jimmyexample");

        await Assert.That(user).IsNotNull();
        await Assert.That(user!.Username).IsEqualTo("jimmyexample");
        await Assert.That(user.Name).IsEqualTo("James Example");
    }

    [Test]
    public async Task ListPhotosAsync_ReturnsPaginatedResult()
    {
        var json = """
        [
            {
                "id": "LBI7cgq3pbM",
                "created_at": "2016-05-03T11:00:28-04:00",
                "width": 5245,
                "height": 3497,
                "color": "#60544D",
                "blur_hash": "LoC%a7IoIVxZ_NM|M{s:%hRjWAo0",
                "description": "A man drinking a coffee.",
                "urls": {
                    "raw": "https://images.unsplash.com/photo",
                    "full": "https://images.unsplash.com/photo?fm=jpg",
                    "regular": "https://images.unsplash.com/photo?w=1080",
                    "small": "https://images.unsplash.com/photo?w=400",
                    "thumb": "https://images.unsplash.com/photo?w=200"
                },
                "user": { "id": "pXhwzz1JtQU", "username": "poorkane", "name": "Gilbert Kane" }
            }
        ]
        """;
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new UsersService(http);

        var result = await service.ListPhotosAsync("poorkane");

        await Assert.That(result.Results.Count).IsEqualTo(1);
        await Assert.That(result.Results[0].Id).IsEqualTo("LBI7cgq3pbM");
        await Assert.That(result.Total).IsEqualTo(100);
    }

    [Test]
    public async Task GetStatisticsAsync_ReturnsStatistics()
    {
        var json = """
        {
            "username": "jimmyexample",
            "downloads": {
                "total": 15687,
                "historical": {
                    "change": 608,
                    "average": 20,
                    "resolution": "days",
                    "quantity": 30,
                    "values": [{ "date": "2017-02-25", "value": 8 }]
                }
            },
            "views": {
                "total": 2374826,
                "historical": {
                    "change": 30252,
                    "average": 1008,
                    "resolution": "days",
                    "quantity": 30,
                    "values": [{ "date": "2017-02-25", "value": 2196 }]
                }
            }
        }
        """;
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new UsersService(http);

        var stats = await service.GetStatisticsAsync("jimmyexample");

        await Assert.That(stats).IsNotNull();
        await Assert.That(stats!.Username).IsEqualTo("jimmyexample");
        await Assert.That(stats.Downloads!.Total).IsEqualTo(15687);
        await Assert.That(stats.Views!.Total).IsEqualTo(2374826);
    }
}
