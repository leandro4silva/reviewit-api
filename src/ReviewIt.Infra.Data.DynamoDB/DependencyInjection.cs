using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.DependencyInjection;
using ReviewIt.Domain.Repository;
using ReviewIt.Infra.Data.DynamoDB.Repositories;
using ReviewIt.Infraestructure.Configuration;

namespace ReviewIt.Infra.Data.DynamoDB;

public static class DependencyInjection
{
    public static IServiceCollection AddDynamoDb(this IServiceCollection services, AppConfiguration appConfigs)
    {
        services.AddDependency();
        services.ConfigureDynamoDb(appConfigs);

        return services;
    }

    private static IServiceCollection AddDependency(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

        return services;
    }

    private static IServiceCollection ConfigureDynamoDb(this IServiceCollection services, AppConfiguration appConfigs)
    {
        if(appConfigs.IsDevelopment || appConfigs.IsStaging)
        {
            var config = new AmazonDynamoDBConfig
            {
                ServiceURL = appConfigs.DynamoDb!.LocalServiceUrl,
                UseHttp = appConfigs.DynamoDb.UseHttp,
                AuthenticationRegion = appConfigs.DynamoDb.AuthenticationRegion,
            };

            var amazonDynamoDbClient = new AmazonDynamoDBClient(config);

            services.AddSingleton<IAmazonDynamoDB>(amazonDynamoDbClient);      
        }
        else
        {
            services.AddSingleton<IAmazonDynamoDB, AmazonDynamoDBClient>();
        }

        return services;
    }
}
