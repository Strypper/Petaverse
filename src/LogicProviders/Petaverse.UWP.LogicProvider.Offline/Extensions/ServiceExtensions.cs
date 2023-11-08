using Microsoft.Extensions.DependencyInjection;

namespace Petaverse.UWP.LogicProvider.Offline;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterLogicProvider(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IHomeService, HomeService>();
        services.AddTransient<IFosterCenterService, FosterCenterService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IBlackListService, BlackListService>();
        return services;
    }
}
