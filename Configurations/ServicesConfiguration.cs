using CatansyAPI.Services;
using CatansyAPI.Services.Interfaces;

namespace CatansyAPI.Configurations;

public static class ServicesConfiguration
{
    public static void AddServices(this IServiceCollection service) 
        => service.AddScoped<IUsersService, UsersService>();
}