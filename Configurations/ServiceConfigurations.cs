using Catansy.API.Services;
using Catansy.API.Services.Interfaces;

namespace Catansy.API.Configurations;

public static class ServiceConfigurations
{
    public static void AddServices(this IServiceCollection services) 
        => services
            .AddScoped<IUsersService, UsersService>()
            .AddScoped<IAuthService, AuthService>()
            .AddTransient<IPasswordHasher, PasswordHasher>()
        ;
}