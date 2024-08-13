using CatansyAPI.Repositories;
using CatansyAPI.Repositories.Interfaces;

namespace CatansyAPI.Configurations;

public static class RepositoriesConfiguration
{
    public static void AddRepositories(this IServiceCollection service) 
        => service.AddScoped<IUsersReadOnlyRepository, UsersReadOnlyRepository>();
}