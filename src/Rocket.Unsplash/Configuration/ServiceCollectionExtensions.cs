using Microsoft.Extensions.DependencyInjection;
using Rocket.Unsplash.Http;

namespace Rocket.Unsplash.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUnsplash(this IServiceCollection services,
        Action<UnsplashOptions> configure)
    {
        var options = new UnsplashOptions();
        configure(options);

        services.AddSingleton(options);

        services.AddHttpClient<IUnsplashClient, UnsplashClient>(client =>
        {
            client.BaseAddress = new Uri(options.BaseUrl);
        })
        .AddHttpMessageHandler(_ => new UnsplashHttpHandler(options));

        return services;
    }
}
