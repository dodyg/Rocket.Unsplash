using Rocket.Unsplash.Models;

namespace Rocket.Unsplash;

public interface IStatsService
{
    Task<Totals?> GetTotalsAsync(CancellationToken ct = default);
    Task<MonthStats?> GetMonthAsync(CancellationToken ct = default);
}
