using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FullStackShop.EF;

public class ShopContextFactory : IDesignTimeDbContextFactory<ShopContext>
{
    // The IDesignTimeDbContextFactory interface will be found when executing EF migrations
    // It will use this method to initialize the ShopContext during design time so the connection string
    // can be different. This will not be used during runtime.
    public ShopContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
        optionsBuilder.UseNpgsql("host=localhost;port=5432;user id=postgres;password=P4ssw0rd");
        optionsBuilder.UseSnakeCaseNamingConvention();
        return new ShopContext(optionsBuilder.Options);
    }
}