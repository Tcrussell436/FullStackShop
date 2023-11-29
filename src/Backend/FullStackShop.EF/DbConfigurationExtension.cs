using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackShop.EF;

public static class DbConfigurationExtension
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration config)
    {
        var cs = config.GetConnectionString("DefaultConnection");
        if (cs == null) throw new Exception("Database connection string not found!");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            // Using Postgres and the EFCore.NamingConventions package to map model's table names
            // to snake case, this greatly simplifies manual queries since postgres is case-sensitive
            options.UseNpgsql(cs)
                .UseSnakeCaseNamingConvention();

        });
        

        return services;
    }
}