namespace BookStore.Infrastructure.Sales.Configurations;

using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class OrderConfiguration : IEntityTypeConfiguration<OrderData>
{
    public void Configure(EntityTypeBuilder<OrderData> builder)
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
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Ignore(o => o.TotalPrice);
    }
}