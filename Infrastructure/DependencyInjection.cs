using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager config
    )
    {
        services.AddDbContext<WebServiceDbContext>((options) =>
            options.UseNpgsql(GetConnectionString(config))
        );

        return services;
    }

    private static string GetConnectionString(ConfigurationManager config)
    {
        var dbSettings = config.GetConnectionString("PostgreConnectionString");

        if (!string.IsNullOrWhiteSpace(dbSettings))
            return dbSettings;

        throw new Exception("Connection string is not specified!");
    }
}
