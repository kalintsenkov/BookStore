namespace BookStore.Infrastructure.Sales.Configurations;

using Domain.Sales.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(o => o.Id);

        builder
            .Property(o => o.Date)
            .IsRequired();

        builder
            .OwnsOne(o => o.Status, state =>
            {
                state
                    .WithOwner();

                state
                    .Property(g => g.Value)
                    .IsRequired();
            });

        builder
            .HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey("CustomerId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(o => o.OrderedBooks)
            .WithOne()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict)
            .Metadata
            .PrincipalToDependent!
            .SetField("orderedBooks");
    }
}