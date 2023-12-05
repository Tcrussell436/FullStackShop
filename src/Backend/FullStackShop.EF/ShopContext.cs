using FullStackShop.Domain.Interfaces;
using FullStackShop.Domain.Models;
using FullStackShop.EF.EntityConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullStackShop.EF;

public class ShopContext : IdentityDbContext<User>, IUnitOfWork
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductsCategories => Set<ProductCategory>();
    
    public ShopContext(DbContextOptions options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // In development this will allow query data to be transparent in logs
#if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
#endif
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Call the base since we inherit from IdentityDbContext
        base.OnModelCreating(modelBuilder);
        
        // Model configuration to configure the database tables for the model.
        // located in ./EntityConfiguration
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        // SnakeCase convention does not apply to IdentityDbContext models
        // Manually setting the entities table names to snake case.
        modelBuilder.Entity<User>().ToTable("asp_net_users");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("asp_net_user_tokens");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("asp_net_user_logins");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("asp_net_user_claims");
        modelBuilder.Entity<IdentityRole>().ToTable("asp_net_roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("asp_net_user_roles");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("asp_net_role_claims");
        
        
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        // Handle events before save
        
        _ = await base.SaveChangesAsync(cancellationToken);
        
        // Handle events after save

        return true;
    }
}