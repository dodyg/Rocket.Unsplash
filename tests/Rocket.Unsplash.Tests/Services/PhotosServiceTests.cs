using Rocket.Unsplash.Models;
using Rocket.Unsplash.Tests.Helpers;

namespace Rocket.Unsplash.Tests.Services;

public sealed class PhotosServiceTests
{
    private static readonly string PhotoJson = """
    {
        "id": "Dwu85P9SOIk",
        "created_at": "2016-05-03T11:00:28-04:00",
        "updated_at": "2016-07-10T11:00:01-05:00",
        "width": 2448,
        "height": 3264,
        "color": "#6E633A",
        "blur_hash": "LFC$yHwc8^$yIAS$%M%00KxukYIp",
        "downloads": 1345,
        "public_domain": false,
        "description": "A man drinking a coffee.",
        "exif": {
            "make": "Canon",
            "model": "Canon EOS 40D",
            "name": "Canon, EOS 40D",
            "exposure_time": "0.011111111111111112",
            "aperture": "4.970854",
            "focal_length": "37",
            "iso": 100
        },
        "location": {
            "city": "Montreal",
            "country": "Canada",
            "position": { "latitude": 45.473298, "longitude": -73.638488 }
        },
        "tags": [{ "title": "man" }, { "title": "drinking" }],
        "urls": {
            "raw": "https://images.unsplash.com/photo-1417325384643-aac51acc9e5d",
            "full": "https://images.unsplash.com/photo-1417325384643-aac51acc9e5d?q=75&fm=jpg",
            "regular": "https://images.unsplash.com/photo-1417325384643-aac51acc9e5d?w=1080",
            "small": "https://images.unsplash.com/photo-1417325384643-aac51acc9e5d?w=400",
            "thumb": "https://images.unsplash.com/photo-1417325384643-aac51acc9e5d?w=200"
        },
        "links": {
            "self": "https://api.unsplash.com/photos/Dwu85P9SOIk",
            "html": "https://unsplash.com/photos/Dwu85P9SOIk",
            "download": "https://unsplash.com/photos/Dwu85P9SOIk/download",
            "download_location": "https://api.unsplash.com/photos/Dwu85P9SOIk/download"
        },
        "user": {
            "id": "QPxL2MGqfrw",
            "username": "exampleuser",
            "name": "Joe Example"
        }
    }
    """;

    [Test]
    public async Task GetAsync_ReturnsPhoto()
    {
        var http = MockHttpMessageHandler.CreateClient(PhotoJson);
        var service = new PhotosService(http);

        var photo = await service.GetAsync("Dwu85P9SOIk");

        await Assert.That(photo).IsNotNull();
        await Assert.That(photo!.Id).IsEqualTo("Dwu85P9SOIk");
        await Assert.That(photo.Width).IsEqualTo(2448);
        await Assert.That(photo.Height).IsEqualTo(3264);
        await Assert.That(photo.Description).IsEqualTo("A man drinking a coffee.");
        await Assert.That(photo.Exif!.Make).IsEqualTo("Canon");
        await Assert.That(photo.Location!.City).IsEqualTo("Montreal");
        await Assert.That(photo.Tags).IsNotNull();
        await Assert.That(photo.Tags!).HasCount().EqualTo(2);
    }

    [Test]
    public async Task GetRandomAsync_ReturnsPhoto()
    {
        var http = MockHttpMessageHandler.CreateClient(PhotoJson);
        var service = new PhotosService(http);

        var photo = await service.GetRandomAsync();

        await Assert.That(photo).IsNotNull();
        await Assert.That(photo!.Id).IsEqualTo("Dwu85P9SOIk");
    }

    [Test]
    public async Task GetRandomAsync_WithCount_ReturnsList()
    {
        var json = $"[{PhotoJson},{PhotoJson}]";
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new PhotosService(http);

        var photos = await service.GetRandomAsync(2);

        await Assert.That(photos).HasCount().EqualTo(2);
    }

    [Test]
    public async Task ListAsync_ReturnsPaginatedResult()
    {
        var json = $"[{PhotoJson}]";
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new PhotosService(http);

        var result = await service.ListAsync();

        await Assert.That(result.Results).HasCount().EqualTo(1);
        await Assert.That(result.Total).IsEqualTo(100);
    }

    [Test]
    public async Task TrackDownloadAsync_ReturnsUrl()
    {
        var json = """{ "url": "https://image.unsplash.com/example" }""";
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new PhotosService(http);

        var result = await service.TrackDownloadAsync("Dwu85P9SOIk");

        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Url).IsEqualTo("https://image.unsplash.com/example");
    }

    [Test]
    public async Task GetStatisticsAsync_ReturnsStats()
    {
        var json = """
        {
            "id": "LF8gK8-HGSg",
            "downloads": { "total": 49771, "historical": { "change": 1474, "resolution": "days", "quantity": 30, "values": [] } },
            "views": { "total": 5165988, "historical": { "change": 165009, "resolution": "days", "quantity": 30, "values": [] } }
        }
        """;
        var http = MockHttpMessageHandler.CreateClient(json);
        var service = new PhotosService(http);

        var stats = await service.GetStatisticsAsync("LF8gK8-HGSg");

        await Assert.That(stats).IsNotNull();
        await Assert.That(stats!.Downloads!.Total).IsEqualTo(49771);
        await Assert.That(stats.Views!.Total).IsEqualTo(5165988);
    }
}
