using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReviewIt.Infra.Notifications;
using System.Diagnostics.CodeAnalysis;

namespace ReviewIt.Infraestructure;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<INotificacaoService, NotificacaoService>();

        return services;
    }
}
