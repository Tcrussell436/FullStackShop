using FullStackShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullStackShop.EF.EntityConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property<decimal?>("_price")
            .HasColumnType("decimal(5,2)");

        builder.Property<string>("_name")
            .HasMaxLength(64)
            .IsRequired();

        builder.Property<string?>("_description")
            .HasMaxLength(2048)
            .IsRequired(false);

        builder.HasOne<ProductCategory>("_category")
            .WithMany()
            .HasForeignKey("_categoryId")
            .IsRequired();
    }
}

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property<string>("_name")
            .HasMaxLength(32)
            .IsRequired();
    }
}