using Microsoft.Extensions.DependencyInjection;
using ReviewIt.Application.Features.User.Abstraction;
using ReviewIt.Application.Features.User.Mappers;
using ReviewIt.Application.Features.User.Services;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ReviewIt.Application;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region definitions

        services.AddServices();
        services.AddAutoMapperProfiles();
        services.AddValidators();

        #endregion

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserService, CreateUserService>();
        return services;
    }

    private static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));
        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        return services;
    }
}
