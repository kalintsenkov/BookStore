namespace BookStore.Infrastructure.Orders.Configurations;

using Domain.Orders.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;
using static Domain.Orders.Models.ModelConstants.Address;
using static Domain.Orders.Models.ModelConstants.PhoneNumber;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.FirstName)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .Property(c => c.LastName)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .Property(c => c.UserId)
            .IsRequired();

        builder
            .OwnsOne(c => c.Address, address =>
            {
                address
                    .WithOwner();

                address
                    .Property(a => a.BillingAddress)
                    .HasMaxLength(MaxAddressLength)
                    .IsRequired();

                address
                    .Property(a => a.DeliveryAddress)
                    .HasMaxLength(MaxAddressLength)
                    .IsRequired();
            });

        builder
            .OwnsOne(c => c.PhoneNumber, phoneNumber =>
            {
                phoneNumber
                    .WithOwner();

                phoneNumber
                    .Property(pn => pn.Number)
                    .HasMaxLength(MaxPhoneNumberLength)
                    .IsRequired();
            });
    }
}