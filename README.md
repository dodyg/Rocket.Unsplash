# Rocket.Unsplash

A modern, fully-typed .NET wrapper for the [Unsplash API](https://unsplash.com/documentation), built for .NET 10 with C# 14.

## Features

- **Full API coverage** — all documented endpoints including read and write operations
- **Modern C#** — record types, primary constructors, nullable reference types
- **Dependency injection** — `services.AddUnsplash()` with `IHttpClientFactory` integration
- **Pagination** — `PaginatedResult<T>` with metadata from response headers
- **Search** — photos, collections, and users with full filter support
- **Auth** — public (`Client-ID`) and user (`Bearer`) authentication
- **Error handling** — typed `UnsplashApiException` with status codes and error messages

## Installation

```
dotnet add package Rocket.Unsplash
```

## Quick Start

### Dependency Injection

```csharp
builder.Services.AddUnsplash(options =>
{
    options.AccessKey = "YOUR_ACCESS_KEY";
});

// For user-authenticated actions:
builder.Services.AddUnsplash(options =>
{
    options.AccessKey = "YOUR_ACCESS_KEY";
    options.BearerToken = "USER_BEARER_TOKEN";
});
```

### Standalone Usage

```csharp
var client = new UnsplashClient(new HttpClient
{
    BaseAddress = new Uri("https://api.unsplash.com")
});
```

### Inject and Use

```csharp
public class MyService(IUnsplashClient unsplash)
{
    public async Task DoWorkAsync()
    {
        var photos = await unsplash.Photos.ListAsync(page: 1, perPage: 20);
        var photo = await unsplash.Photos.GetAsync("Dwu85P9SOIk");
        var random = await unsplash.Photos.GetRandomAsync(query: "coffee", orientation: Orientation.Portrait);
        var many = await unsplash.Photos.GetRandomAsync(count: 5, query: "nature");

        var results = await unsplash.Search.SearchPhotosAsync("mountains", perPage: 15);
        var user = await unsplash.Users.GetProfileAsync("jimmyexample");
        var stats = await unsplash.Stats.GetTotalsAsync();
    }
}
```

## API Coverage

| Service | Endpoints |
|---|---|
| **Current User** | Get profile, update profile |
| **Users** | Get profile, list photos, list collections, get statistics |
| **Photos** | List, get, random (single & batch), statistics, track download, update |
| **Search** | Search photos, search collections, search users |
| **Collections** | List, get, get photos, get related, create, update, delete, add/remove photo |
| **Topics** | List, get, get topic photos |
| **Stats** | Totals, month |

## Examples

### Search Photos with Filters

```csharp
var results = await unsplash.Search.SearchPhotosAsync(
    query: "ocean",
    page: 2,
    perPage: 20,
    orderBy: SearchPhotosOrderBy.Latest,
    color: "blue",
    orientation: Orientation.Landscape,
    contentFilter: ContentFilter.High);
```

### Collections CRUD

```csharp
var collection = await unsplash.Collections.CreateAsync(
    title: "My Favorites",
    description: "Best photos",
    @private: false);

await unsplash.Collections.AddPhotoAsync(collection.Id!.Value, "Dwu85P9SOIk");
await unsplash.Collections.RemovePhotoAsync(collection.Id.Value, "Dwu85P9SOIk");
await unsplash.Collections.DeleteAsync(collection.Id.Value);
```

### Pagination

```csharp
var page1 = await unsplash.Photos.ListAsync(page: 1, perPage: 30);

Console.WriteLine($"Total: {page1.Total}");
Console.WriteLine($"Total Pages: {page1.TotalPages}");

foreach (var photo in page1.Results)
{
    Console.WriteLine($"{photo.Id}: {photo.Urls?.Regular}");
}
```

### Current User (requires Bearer token)

```csharp
var me = await unsplash.Me.GetCurrentUserAsync();

var updated = await unsplash.Me.UpdateCurrentUserAsync(
    new UpdateCurrentUserRequest
    {
        FirstName = "New Name",
        Bio = "Updated bio"
    });
```

### Error Handling

```csharp
try
{
    var photo = await unsplash.Photos.GetAsync("invalid_id");
}
catch (UnsplashApiException ex)
{
    Console.WriteLine($"Status: {ex.StatusCode}");
    Console.WriteLine($"Errors: {string.Join(", ", ex.Errors)}");
}
```

## Configuration

| Option | Default | Description |
|---|---|---|
| `AccessKey` | `null` | Your Unsplash application access key |
| `BearerToken` | `null` | User bearer token for authenticated actions |
| `BaseUrl` | `https://api.unsplash.com` | API base URL (can be overridden for testing) |

## Requirements

- .NET 10+
- [Unsplash API access key](https://unsplash.com/oauth/applications)

## License

MIT
