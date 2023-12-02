using FullStackShop.Domain.Models.Repositories;
using FullStackShop.EF.Repositories;

namespace FullStackShop.API;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}