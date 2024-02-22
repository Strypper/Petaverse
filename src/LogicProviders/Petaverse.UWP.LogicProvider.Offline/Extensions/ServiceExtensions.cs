using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Petaverse.UWP.LogicProvider.Offline;

public static class ServiceExtensions
{
    //https://github.com/dotnet/efcore/issues/11666
    public static IServiceCollection RegisterLogicProvider(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IHomeService, HomeService>();
        services.AddTransient<IFaunaService, FaunaService>();
        services.AddTransient<IBlackListService, BlackListService>();
        services.AddTransient<IFosterCenterService, FosterCenterService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();

        services.AddDbContext<PetaverseLocalDbContext>(options =>
            options.UseInMemoryDatabase("PetaverseLocalDb"));



        return services;
    }
}
