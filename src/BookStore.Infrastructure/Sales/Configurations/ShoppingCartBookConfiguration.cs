namespace BookStore.Infrastructure.Sales.Configurations;

using Domain.Sales.Models.ShoppingCarts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ShoppingCartBookConfiguration : IEntityTypeConfiguration<ShoppingCartBook>
{
    public void Configure(EntityTypeBuilder<ShoppingCartBook> builder)
    {
        builder
            .HasKey(cb => cb.Id);

        builder
            .Property(cb => cb.Quantity)
            .IsRequired();

        builder
            .HasOne(cb => cb.Book)
            .WithMany()
            .HasForeignKey("BookId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}