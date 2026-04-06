using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rocket.Unsplash.Results;

namespace Rocket.Unsplash;

internal static class UnsplashJson
{
    public static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = false
    };
}

internal static class ApiHelper
{
    internal static async Task<T?> DeserializeAsync<T>(HttpResponseMessage response, CancellationToken ct)
    {
        await EnsureSuccess(response).ConfigureAwait(false);
        var stream = await response.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<T>(stream, UnsplashJson.Options, ct).ConfigureAwait(false);
    }

    internal static async Task EnsureSuccess(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return;

        var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        List<string>? errors = null;
        try
        {
            var errorObj = JsonSerializer.Deserialize<JsonElement>(body);
            if (errorObj.TryGetProperty("errors", out var errorsProp))
            {
                errors = errorsProp.EnumerateArray().Select(e => e.GetString() ?? "").ToList();
            }
        }
        catch { }

        throw new UnsplashApiException((int)response.StatusCode, errors ?? [body]);
    }

    internal static PaginatedResult<T> BuildPaginatedResult<T>(IReadOnlyList<T> items,
        HttpResponseMessage response)
    {
        var total = response.Headers.Contains("X-Total")
            ? int.Parse(response.Headers.GetValues("X-Total").First())
            : items.Count;

        var perPage = response.Headers.Contains("X-Per-Page")
            ? int.Parse(response.Headers.GetValues("X-Per-Page").First())
            : items.Count;

        var totalPages = perPage > 0 ? (int)Math.Ceiling((double)total / perPage) : 1;

        return new PaginatedResult<T>
        {
            Results = items,
            Total = total,
            TotalPages = totalPages,
            Page = 1,
            PerPage = perPage
        };
    }

    internal static string BuildQueryString(params (string Key, object? Value)[] parameters)
    {
        var parts = new List<string>();
        foreach (var (key, value) in parameters)
        {
            if (value is null) continue;
            var str = value switch
            {
                Enum e => e.GetType().GetMethod("ToApiString")?.Invoke(null, [e]) as string ?? e.ToString().ToLowerInvariant(),
                bool b => b.ToString().ToLowerInvariant(),
                _ => value.ToString()
            };
            if (str is not null)
                parts.Add($"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(str)}");
        }
        return parts.Count > 0 ? "?" + string.Join("&", parts) : "";
    }
}
