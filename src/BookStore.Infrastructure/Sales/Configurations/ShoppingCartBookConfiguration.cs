namespace BookStore.Infrastructure.Sales.Configurations;

using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ShoppingCartBookConfiguration : IEntityTypeConfiguration<ShoppingCartBookData>
{
    public void Configure(EntityTypeBuilder<ShoppingCartBookData> builder)
    {
        builder
            .HasKey(cb => cb.Id);

        builder
            .Property(cb => cb.Quantity)
            .IsRequired();

        builder
            .HasOne(cb => cb.ShoppingCart)
            .WithMany(c => c.Books)
            .HasForeignKey(cb => cb.ShoppingCartId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(cb => cb.Book)
            .WithMany()
            .HasForeignKey(cb => cb.BookId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}