namespace BookStore.Infrastructure.Sales.Configurations;

using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Sales.Models.ModelConstants.Address;
using static Domain.Sales.Models.ModelConstants.PhoneNumber;

internal class AddressConfiguration : IEntityTypeConfiguration<AddressData>
{
    public void Configure(EntityTypeBuilder<AddressData> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.City)
            .HasMaxLength(MaxCityLength)
            .IsRequired();

        builder
            .Property(a => a.State)
            .HasMaxLength(MaxStateLength)
            .IsRequired();

        builder
            .Property(a => a.PostalCode)
            .HasMaxLength(MaxPostalCodeLength)
            .IsRequired();

        builder
            .Property(a => a.Description)
            .HasMaxLength(MaxDescriptionLength)
            .IsRequired();

        builder
            .OwnsOne(a => a.PhoneNumber, phoneNumber =>
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