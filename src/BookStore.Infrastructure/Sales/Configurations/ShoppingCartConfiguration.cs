namespace BookStore.Infrastructure.Sales.Configurations;

using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCartData>
{
    public void Configure(EntityTypeBuilder<ShoppingCartData> builder)
    {
        builder
            .HasKey(sc => sc.Id);

        builder
            .HasOne(sc => sc.Customer)
            .WithOne()
            .HasForeignKey<ShoppingCartData>(sc => sc.CustomerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}