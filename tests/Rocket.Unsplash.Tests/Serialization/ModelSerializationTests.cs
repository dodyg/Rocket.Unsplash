using System.Text.Json;
using Rocket.Unsplash.Models;

namespace Rocket.Unsplash.Tests.Serialization;

public sealed class ModelSerializationTests
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    [Test]
    public async Task User_RoundTrips()
    {
        var json = """
        {
            "id": "pXhwzz1JtQU",
            "username": "jimmyexample",
            "name": "James Example",
            "first_name": "James",
            "last_name": "Example",
            "bio": "Bio text",
            "location": "Montreal",
            "total_collections": 5,
            "downloads": 100,
            "links": {
                "self": "https://api.unsplash.com/users/jimmyexample",
                "html": "https://unsplash.com/jimmyexample",
                "photos": "https://api.unsplash.com/users/jimmyexample/photos",
                "portfolio": "https://example.com"
            },
            "profile_image": {
                "small": "https://img/small",
                "medium": "https://img/medium",
                "large": "https://img/large"
            }
        }
        """;

        var user = JsonSerializer.Deserialize<User>(json, Options);

        await Assert.That(user).IsNotNull();
        await Assert.That(user!.Id).IsEqualTo("pXhwzz1JtQU");
        await Assert.That(user.Username).IsEqualTo("jimmyexample");
        await Assert.That(user.ProfileImage!.Small).IsEqualTo("https://img/small");
        await Assert.That(user.Links!.Portfolio).IsEqualTo("https://example.com");

        var serialized = JsonSerializer.Serialize(user, Options);
        var deserialized = JsonSerializer.Deserialize<User>(serialized, Options);
        await Assert.That(deserialized!.Id).IsEqualTo(user.Id);
    }

    [Test]
    public async Task Photo_WithAllFields_RoundTrips()
    {
        var json = """
        {
            "id": "Dwu85P9SOIk",
            "created_at": "2016-05-03T11:00:28-04:00",
            "width": 2448,
            "height": 3264,
            "color": "#6E633A",
            "blur_hash": "LFC$yHwc8^$yIAS$%M%00KxukYIp",
            "description": "A coffee photo",
            "alt_description": "Coffee on table",
            "downloads": 1345,
            "exif": {
                "make": "Canon",
                "model": "Canon EOS 40D",
                "iso": 100
            },
            "location": {
                "city": "Montreal",
                "country": "Canada",
                "position": { "latitude": 45.473298, "longitude": -73.638488 }
            },
            "tags": [{ "title": "man" }, { "title": "coffee" }],
            "urls": {
                "raw": "https://images.unsplash.com/raw",
                "full": "https://images.unsplash.com/full",
                "regular": "https://images.unsplash.com/regular",
                "small": "https://images.unsplash.com/small",
                "thumb": "https://images.unsplash.com/thumb"
            },
            "user": { "id": "u1", "username": "testuser" }
        }
        """;

        var photo = JsonSerializer.Deserialize<Photo>(json, Options);

        await Assert.That(photo).IsNotNull();
        await Assert.That(photo!.Id).IsEqualTo("Dwu85P9SOIk");
        await Assert.That(photo.Width).IsEqualTo(2448);
        await Assert.That(photo.Exif!.Iso).IsEqualTo(100);
        await Assert.That(photo.Location!.Position!.Latitude).IsEqualTo(45.473298);
        await Assert.That(photo.Tags!.Count).IsEqualTo(2);
        await Assert.That(photo.Urls!.Raw).IsEqualTo("https://images.unsplash.com/raw");
    }

    [Test]
    public async Task Collection_RoundTrips()
    {
        var json = """
        {
            "id": 296,
            "title": "Beards",
            "description": "Beard collection",
            "total_photos": 12,
            "private": false,
            "featured": true,
            "links": {
                "self": "https://api.unsplash.com/collections/296",
                "html": "https://unsplash.com/collections/296",
                "photos": "https://api.unsplash.com/collections/296/photos",
                "related": "https://api.unsplash.com/collections/296/related"
            }
        }
        """;

        var collection = JsonSerializer.Deserialize<Collection>(json, Options);

        await Assert.That(collection).IsNotNull();
        await Assert.That(collection!.Id).IsEqualTo(296);
        await Assert.That(collection.Featured).IsTrue();
        await Assert.That(collection.Links!.Related).IsEqualTo("https://api.unsplash.com/collections/296/related");
    }

    [Test]
    public async Task SearchPhotosResult_RoundTrips()
    {
        var json = """
        {
            "total": 42,
            "total_pages": 5,
            "results": [
                { "id": "photo1", "description": "First" },
                { "id": "photo2", "description": "Second" }
            ]
        }
        """;

        var result = JsonSerializer.Deserialize<SearchPhotosResult>(json, Options);

        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Total).IsEqualTo(42);
        await Assert.That(result.TotalPages).IsEqualTo(5);
        await Assert.That(result.Results!.Count).IsEqualTo(2);
    }

    [Test]
    public async Task Totals_RoundTrips()
    {
        var json = """
        {
            "photos": 3000000,
            "downloads": 500000000,
            "views": 1000000000,
            "photographers": 250000,
            "pixels": 5000000000000,
            "downloads_per_second": 42,
            "views_per_second": 100,
            "developers": 100000,
            "applications": 50000,
            "requests": 2000000000
        }
        """;

        var totals = JsonSerializer.Deserialize<Totals>(json, Options);

        await Assert.That(totals).IsNotNull();
        await Assert.That(totals!.Photos).IsEqualTo(3_000_000);
        await Assert.That(totals.Requests).IsEqualTo(2_000_000_000);
    }
}
