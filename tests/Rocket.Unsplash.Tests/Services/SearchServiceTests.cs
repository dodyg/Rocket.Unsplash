using Rocket.Unsplash.Models;
using Rocket.Unsplash.Tests.Helpers;

namespace Rocket.Unsplash.Tests.Services;

public sealed class SearchServiceTests
{
    [Test]
    public async Task SearchPhotosAsync_ReturnsResults()
    {
        var json = """
        {
            "total": 133,
            "total_pages": 7,
            "results": [
                {
                    "id": "eOLpJytrbsQ",
                    "created_at": "2014-11-18T14:35:36-05:00",
                    "width": 4000,
                    "height": 3000,
                    "color": "#A7A2A1",
                    "blur_hash": "LaLXMa9Fx[D%~q%MtQM|kDRjtRIU",
                    "description": "A man drinking coffee.",
                    "user": { "id": "Ul0QVz12Goo", "username": "ugmonk", "name": "Jeff Sheldon" },
                    "urls": { "raw": "https://images.unsplash.com/photo", "full": "", "regular": "", "small": "", "thumb": "" }
                }
            ]
        }
        """;
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new SearchService(http);

        var result = await service.SearchPhotosAsync("coffee");

        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Total).IsEqualTo(133);
        await Assert.That(result.TotalPages).IsEqualTo(7);
        await Assert.That(result.Results).IsNotNull();
        await Assert.That(result.Results!.Count).IsEqualTo(1);
        await Assert.That(result.Results![0].Id).IsEqualTo("eOLpJytrbsQ");
    }

    [Test]
    public async Task SearchCollectionsAsync_ReturnsResults()
    {
        var json = """
        {
            "total": 237,
            "total_pages": 12,
            "results": [
                {
                    "id": 193913,
                    "title": "Office",
                    "description": null,
                    "total_photos": 60,
                    "private": false,
                    "featured": true
                }
            ]
        }
        """;
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new SearchService(http);

        var result = await service.SearchCollectionsAsync("office");

        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Total).IsEqualTo(237);
        await Assert.That(result.Results!.Count).IsEqualTo(1);
        await Assert.That(result.Results![0].Title).IsEqualTo("Office");
    }

    [Test]
    public async Task SearchUsersAsync_ReturnsResults()
    {
        var json = """
        {
            "total": 14,
            "total_pages": 1,
            "results": [
                {
                    "id": "e_gYNc2Fs0s",
                    "username": "solase",
                    "name": "Aase H. Tjelland"
                }
            ]
        }
        """;
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new SearchService(http);

        var result = await service.SearchUsersAsync("solase");

        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Total).IsEqualTo(14);
        await Assert.That(result.Results![0].Username).IsEqualTo("solase");
    }
}
