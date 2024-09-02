using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Catansy.API.Configurations;

public static class FluentValidationConfigurations
{
    public static void AddFluentValidationConfiguration(this IServiceCollection services) =>
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
}