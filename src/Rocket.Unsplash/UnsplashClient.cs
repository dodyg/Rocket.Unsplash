using Rocket.Unsplash.Configuration;

namespace Rocket.Unsplash;

public interface IUnsplashClient
{
    ICurrentUserService Me { get; }
    IUsersService Users { get; }
    IPhotosService Photos { get; }
    ISearchService Search { get; }
    ICollectionsService Collections { get; }
    ITopicsService Topics { get; }
    IStatsService Stats { get; }
}

public sealed class UnsplashClient : IUnsplashClient
{
    public ICurrentUserService Me { get; }
    public IUsersService Users { get; }
    public IPhotosService Photos { get; }
    public ISearchService Search { get; }
    public ICollectionsService Collections { get; }
    public ITopicsService Topics { get; }
    public IStatsService Stats { get; }

    public UnsplashClient(HttpClient httpClient)
    {
        Me = new CurrentUserService(httpClient);
        Users = new UsersService(httpClient);
        Photos = new PhotosService(httpClient);
        Search = new SearchService(httpClient);
        Collections = new CollectionsService(httpClient);
        Topics = new TopicsService(httpClient);
        Stats = new StatsService(httpClient);
    }
}
