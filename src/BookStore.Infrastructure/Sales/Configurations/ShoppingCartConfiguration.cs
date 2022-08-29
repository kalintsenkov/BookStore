namespace BookStore.Infrastructure.Sales.Configurations;

using Domain.Sales.Models.ShoppingCarts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder
            .HasKey(sc => sc.Id);

        builder
            .HasOne(sc => sc.Customer)
            .WithOne()
            .HasForeignKey<ShoppingCart>("CustomerId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(o => o.Books)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict)
            .Metadata
            .PrincipalToDependent!
            .SetField("books");
    }
}