namespace BookStore.Infrastructure.Catalog.Configurations;

using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Catalog.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

internal class BookConfiguration : IEntityTypeConfiguration<BookData>
{
    public void Configure(EntityTypeBuilder<BookData> builder)
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

        builder
            .Property(b => b.Description)
            .HasMaxLength(MaxDescriptionLength)
            .IsRequired();

        builder
            .Property(b => b.IsAvailable)
            .IsRequired();

        builder
            .OwnsOne(b => b.Genre, genre =>
            {
                genre
                    .WithOwner();

                genre
                    .Property(g => g.Value)
                    .IsRequired();
            });

        builder
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}