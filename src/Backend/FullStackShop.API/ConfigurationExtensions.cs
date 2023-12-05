using FullStackShop.Domain.Models;
using FullStackShop.Domain.Models.Repositories;
using FullStackShop.EF;
using FullStackShop.EF.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FullStackShop.API;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.BearerScheme;
        }).AddBearerToken(IdentityConstants.BearerScheme);
        //services.AddIdentityApiEndpoints<>()

        services.AddIdentityCore<User>(options =>
        {
            options.SignIn.RequireConfirmedEmail = true;
        }).AddEntityFrameworkStores<ShopContext>()
            .AddApiEndpoints()
            .AddSignInManager<User>()
            .AddDefaultTokenProviders();
        
       // services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();
            

        return services;
    }

    public static WebApplication UseIdentityServices(this WebApplication app)
    {
        app.UseAuthorization();
        //app.UseAntiforgery();
        
        app.MapIdentityApi<User>();

        return app;
    }
}