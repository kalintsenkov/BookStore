namespace BookStore.Infrastructure.Sales.Configurations;

using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class OrderedBookConfiguration : IEntityTypeConfiguration<OrderedBookData>
{
    public void Configure(EntityTypeBuilder<OrderedBookData> builder)
    {
        builder
            .HasKey(ob => ob.Id);

        builder
            .Property(ob => ob.Quantity)
            .IsRequired();

        builder
            .HasOne(ob => ob.Order)
            .WithMany(o => o.OrderedBooks)
            .HasForeignKey(o => o.OrderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(ob => ob.Book)
            .WithMany()
            .HasForeignKey(o => o.BookId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}