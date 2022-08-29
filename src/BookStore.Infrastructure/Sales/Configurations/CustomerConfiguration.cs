namespace BookStore.Infrastructure.Sales.Configurations;

using Domain.Sales.Models.Customers;
using Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Name)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.Address)
            .WithOne()
            .HasForeignKey<Customer>("AddressId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}