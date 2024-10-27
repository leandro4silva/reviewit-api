using ReviewIt.Infraestructure.Extensions;
using ReviewIt.Infraestructure.Configuration;
using ReviewIt.Infraestructure;
using ReviewIt.Infra.Data.DynamoDB;
using ReviewIt.Application;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Amazon.DynamoDBv2;

namespace ReviewIt;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container
    [Obsolete]
    public void ConfigureServices(IServiceCollection services)
    {
        var builder = WebApplication.CreateBuilder();

        var appConfigs = builder.AddAppConfigs();

        services.AddInfraServices(builder.Configuration);
        services.AddDynamoDb(appConfigs);
        services.AddApplication();

        services.AddControllers()
            .AddFluentValidation(x => x.AutomaticValidationEnabled = false)
            .AddCustomJsonOptions()
            .ConfigureApiBehaviorOptions(options =>
                options.SuppressInferBindingSourcesForParameters = true
            );

        services.AddAppConnections(builder.Configuration);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(setup => {
            setup.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Review It",
                Version = "v1"
            });
            setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header
            });
            var scheme = new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            setup.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                { scheme, Array.Empty<string>() }
            });
        });

        services
            .AddApiVersioning();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}