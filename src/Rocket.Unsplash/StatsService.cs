using System.Text.Json;
using Rocket.Unsplash.Models;

namespace Rocket.Unsplash;

public sealed class StatsService(HttpClient client) : IStatsService
{
    public async Task<Totals?> GetTotalsAsync(CancellationToken ct = default)
    {
        var response = await client.GetAsync("stats/total", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<Totals>(response, ct).ConfigureAwait(false);
    }

    public async Task<MonthStats?> GetMonthAsync(CancellationToken ct = default)
    {
        var response = await client.GetAsync("stats/month", ct).ConfigureAwait(false);
        return await ApiHelper.DeserializeAsync<MonthStats>(response, ct).ConfigureAwait(false);
    }
}
