using FullStackShop.Domain.Interfaces;
using FullStackShop.Domain.Models;
using FullStackShop.EF.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace FullStackShop.EF;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductsCategories => Set<ProductCategory>();
    public DbSet<User> Users => Set<User>();
    
    public ApplicationDbContext(DbContextOptions options) : base(options)
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
        // Model configuration to configure the database tables for the model.
        // located in ./EntityConfiguration
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        // Handle events before save
        
        _ = await base.SaveChangesAsync(cancellationToken);
        
        // Handle events after save

        return true;
    }
}