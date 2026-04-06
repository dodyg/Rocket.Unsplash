using Rocket.Unsplash.Models;
using Rocket.Unsplash.Tests.Helpers;

namespace Rocket.Unsplash.Tests.Services;

public sealed class StatsServiceTests
{
    [Test]
    public async Task GetTotalsAsync_ReturnsStats()
    {
        var json = """
        {
            "photos": 10000,
            "downloads": 2000,
            "views": 5000,
            "photographers": 100,
            "pixels": 200000,
            "downloads_per_second": 10,
            "views_per_second": 20,
            "developers": 20,
            "applications": 50,
            "requests": 8000
        }
        """;
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new StatsService(http);

        var totals = await service.GetTotalsAsync();

        await Assert.That(totals).IsNotNull();
        await Assert.That(totals!.Photos).IsEqualTo(10000);
        await Assert.That(totals.Downloads).IsEqualTo(2000);
        await Assert.That(totals.Photographers).IsEqualTo(100);
        await Assert.That(totals.Developers).IsEqualTo(20);
    }

    [Test]
    public async Task GetMonthAsync_ReturnsStats()
    {
        var json = """
        {
            "downloads": 20,
            "views": 200,
            "new_photos": 10,
            "new_photographers": 5,
            "new_pixels": 2000,
            "new_developers": 8,
            "new_applications": 5,
            "new_requests": 100
        }
        """;
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new StatsService(http);

        var month = await service.GetMonthAsync();

        await Assert.That(month).IsNotNull();
        await Assert.That(month!.Downloads).IsEqualTo(20);
        await Assert.That(month.NewPhotos).IsEqualTo(10);
        await Assert.That(month.NewDevelopers).IsEqualTo(8);
    }
}
