namespace BookStore.Infrastructure.Sales.Configurations;

using Data;
using Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;

internal class CustomerConfiguration : IEntityTypeConfiguration<CustomerData>
{
    public void Configure(EntityTypeBuilder<CustomerData> builder)
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
            .HasForeignKey<CustomerData>(c => c.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}