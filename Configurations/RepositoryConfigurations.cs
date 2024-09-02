using Catansy.API.Repositories;
using Catansy.API.Repositories.Interfaces;

namespace Catansy.API.Configurations;

public static class RepositoryConfigurations
{
    public static void AddRepositories(this IServiceCollection services) 
        => services
            .AddScoped<IUsersReadOnlyRepository, UsersReadOnlyRepository>()
            .AddScoped<IUsersTransactionalRepository, UsersTransactionalRepository>();
}