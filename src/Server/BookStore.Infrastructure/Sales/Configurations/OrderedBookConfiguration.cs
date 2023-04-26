namespace BookStore.Infrastructure.Sales.Configurations;

using Domain.Sales.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class OrderedBookConfiguration : IEntityTypeConfiguration<OrderedBook>
{
    public void Configure(EntityTypeBuilder<OrderedBook> builder)
    {
        builder
            .HasKey(ob => ob.Id);

        builder
            .Property(ob => ob.Quantity)
            .IsRequired();

        builder
            .HasOne(ob => ob.Book)
            .WithMany()
            .HasForeignKey("BookId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}