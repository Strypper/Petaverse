using Microsoft.Extensions.DependencyInjection;

namespace Petaverse.UWP.LogicProvider.Offline;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterLogicProvider(this IServiceCollection services)
    {
        services.AddTransient<IHomeService, HomeService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
