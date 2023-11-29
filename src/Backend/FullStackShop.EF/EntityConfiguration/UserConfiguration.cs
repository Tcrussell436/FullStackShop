using FullStackShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullStackShop.EF.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey("_id");

        builder.Property<string>("_id")
            .HasMaxLength(256)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(u => u.CreatedOn)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property<string>("_email")
            .HasMaxLength(64)
            .IsRequired();
    }
}