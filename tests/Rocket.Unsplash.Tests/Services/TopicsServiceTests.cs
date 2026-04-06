using Rocket.Unsplash.Models;
using Rocket.Unsplash.Tests.Helpers;

namespace Rocket.Unsplash.Tests.Services;

public sealed class TopicsServiceTests
{
    private static readonly string TopicJson = """
    {
        "id": "bo8jQKTaE0Y",
        "slug": "wallpapers",
        "title": "Wallpapers",
        "description": "From epic drone shots to inspiring moments in nature...",
        "published_at": "2020-04-17T02:31:04Z",
        "updated_at": "2020-09-22T07:37:55-04:00",
        "featured": true,
        "total_photos": 5296,
        "status": "open",
        "links": {
            "self": "https://api.unsplash.com/topics/wallpapers",
            "html": "https://unsplash.com/t/wallpapers",
            "photos": "https://api.unsplash.com/topics/wallpapers/photos"
        }
    }
    """;

    [Test]
    public async Task GetAsync_ReturnsTopic()
    {
        var http = MockHttpMessageHandler.CreateClient(TopicJson);
        var service = new TopicsService(http);

        var topic = await service.GetAsync("wallpapers");

        await Assert.That(topic).IsNotNull();
        await Assert.That(topic!.Slug).IsEqualTo("wallpapers");
        await Assert.That(topic.Title).IsEqualTo("Wallpapers");
        await Assert.That(topic.TotalPhotos).IsEqualTo(5296);
        await Assert.That(topic.Featured).IsTrue();
    }

    [Test]
    public async Task ListAsync_ReturnsPaginatedResult()
    {
        var json = $"[{TopicJson}]";
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new TopicsService(http);

        var result = await service.ListAsync();

        await Assert.That(result.Results).HasCount().EqualTo(1);
        await Assert.That(result.Results[0].Slug).IsEqualTo("wallpapers");
    }

    [Test]
    public async Task GetPhotosAsync_ReturnsPaginatedPhotos()
    {
        var json = """
        [
            {
                "id": "abc123",
                "width": 4000,
                "height": 3000,
                "description": "A wallpaper photo",
                "urls": { "raw": "https://images.unsplash.com/photo", "full": "", "regular": "", "small": "", "thumb": "" }
            }
        ]
        """;
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new TopicsService(http);

        var result = await service.GetPhotosAsync("wallpapers");

        await Assert.That(result.Results).HasCount().EqualTo(1);
        await Assert.That(result.Results[0].Id).IsEqualTo("abc123");
    }
}
