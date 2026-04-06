using System.Net;
using Rocket.Unsplash.Models;
using Rocket.Unsplash.Tests.Helpers;

namespace Rocket.Unsplash.Tests.Services;

public sealed class CollectionsServiceTests
{
    private static readonly string CollectionJson = """
    {
        "id": 296,
        "title": "I like a man with a beard.",
        "description": "Yeah even Santa...",
        "published_at": "2016-01-27T18:47:13-05:00",
        "last_collected_at": "2016-06-02T13:10:03-04:00",
        "updated_at": "2016-07-10T11:00:01-05:00",
        "total_photos": 12,
        "private": false,
        "share_key": "312d188df257b957f8b86d2ce20e4766",
        "links": {
            "self": "https://api.unsplash.com/collections/296",
            "html": "https://unsplash.com/collections/296",
            "photos": "https://api.unsplash.com/collections/296/photos",
            "related": "https://api.unsplash.com/collections/296/related"
        }
    }
    """;

    [Test]
    public async Task GetAsync_ReturnsCollection()
    {
        var http = MockHttpMessageHandler.CreateClient(CollectionJson);
        var service = new CollectionsService(http);

        var collection = await service.GetAsync(296);

        await Assert.That(collection).IsNotNull();
        await Assert.That(collection!.Id).IsEqualTo(296);
        await Assert.That(collection.Title).IsEqualTo("I like a man with a beard.");
        await Assert.That(collection.TotalPhotos).IsEqualTo(12);
    }

    [Test]
    public async Task ListAsync_ReturnsPaginatedResult()
    {
        var json = $"[{CollectionJson}]";
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new CollectionsService(http);

        var result = await service.ListAsync();

        await Assert.That(result.Results).HasCount().EqualTo(1);
        await Assert.That(result.Total).IsEqualTo(100);
    }

    [Test]
    public async Task CreateAsync_SendsPostWithCorrectData()
    {
        var handler = new MockHttpMessageHandler(CollectionJson);
        var http = new HttpClient(handler) { BaseAddress = new Uri("https://api.unsplash.com") };
        var service = new CollectionsService(http);

        var collection = await service.CreateAsync("Test Collection", "A test");

        await Assert.That(collection).IsNotNull();
        await Assert.That(handler.LastRequest!.Method).IsEqualTo(HttpMethod.Post);
    }

    [Test]
    public async Task DeleteAsync_SendsDeleteRequest()
    {
        var handler = new MockHttpMessageHandler("", HttpStatusCode.NoContent);
        var http = new HttpClient(handler) { BaseAddress = new Uri("https://api.unsplash.com") };
        var service = new CollectionsService(http);

        await service.DeleteAsync(296);

        await Assert.That(handler.LastRequest!.Method).IsEqualTo(HttpMethod.Delete);
    }

    [Test]
    public async Task GetRelatedAsync_ReturnsCollectionsList()
    {
        var json = $"[{CollectionJson}]";
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new CollectionsService(http);

        var related = await service.GetRelatedAsync(296);

        await Assert.That(related).HasCount().EqualTo(1);
    }
}
