using FullStackShop.Domain.Models;
using FullStackShop.EF;
using Microsoft.EntityFrameworkCore;

namespace FullStackShop.API;

public static class SeedData
{
    public static void AddFssSeedData(ShopContext dbContext)
    {
        dbContext.Database.Migrate();
        AddProductCategories(dbContext);
    }

    public static void AddProductCategories(ShopContext dbContext)
    {
        if (!dbContext.ProductsCategories.Any())
        {
            dbContext.ProductsCategories.AddRange(Categories);
            dbContext.SaveChanges();
        }
    }

    // New collection expression C#12 syntax!
    public static List<ProductCategory> Categories =>
    [
        new ProductCategory("Web Component"),
        new ProductCategory("Themes"),
        new ProductCategory("Templates")
    ];
}