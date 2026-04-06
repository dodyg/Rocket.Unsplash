# AGENTS.md

## Project Overview

Rocket.Unsplash is a .NET 10 wrapper library for the Unsplash API, written in C# 14.

## Solution Structure

```
src/Rocket.Unsplash/          # Library
  Configuration/              # DI extension, options
  Enums/                      # Orientation, ContentFilter, order-by enums
  Http/                       # Auth handler (UnsplashHttpHandler)
  Models/                     # Immutable record types for API responses
  Requests/                   # Request bodies for write operations
  Results/                    # PaginatedResult<T>
  Service interfaces (I*.cs)  # One per API area
  Service implementations     # Same name without I prefix
  UnsplashClient.cs           # Main facade (IUnsplashClient)
  UnsplashApiException.cs     # Error type
  ApiHelper.cs                # Shared HTTP/JSON/pagination utilities

tests/Rocket.Unsplash.Tests/  # TUnit tests
  Helpers/                    # MockHttpMessageHandler
  Serialization/              # JSON round-trip tests
  Services/                   # One test file per service
```

## Build & Run Commands

```bash
dotnet build Rocket.Unsplash.sln
dotnet test Rocket.Unsplash.sln --verbosity normal
```

## Conventions

- **Models**: `sealed record` types with `[JsonPropertyName("snake_case")]` attributes, all in `Rocket.Unsplash.Models` namespace
- **Enums**: Pure enums in `Rocket.Unsplash.Enums` with `ToApiString()` extension methods in `EnumExtensions.cs`
- **JSON serialization**: `System.Text.Json` with `SnakeCaseLower` naming policy via `UnsplashJson.Options`
- **Services**: Primary constructors receiving `HttpClient`, one interface + one implementation per API area
- **No comments** in code
- **Nullability**: nullable reference types enabled; all model properties are nullable (`?`)
- **Target framework**: `net10.0`, language version `preview`

## Key Patterns

- All HTTP calls go through `ApiHelper.DeserializeAsync<T>()` which handles error checking
- Pagination uses `ApiHelper.BuildPaginatedResult<T>()` reading `X-Total` and `X-Per-Page` headers
- Query strings built via `ApiHelper.BuildQueryString()` which auto-converts enums via `ToApiString()`
- Auth headers injected by `UnsplashHttpHandler` (supports `Client-ID` and `Bearer`)
- DI registration via `ServiceCollectionExtensions.AddUnsplash()`
