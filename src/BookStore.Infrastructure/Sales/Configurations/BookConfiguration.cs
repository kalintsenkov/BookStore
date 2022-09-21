namespace BookStore.Infrastructure.Sales.Configurations;

using Domain.Sales.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.Title)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .Property(b => b.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .Property(b => b.Quantity)
            .IsRequired();
    }
}