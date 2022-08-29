namespace BookStore.Infrastructure.Catalog.Configurations;

using Domain.Catalog.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Catalog.Models.ModelConstants.Common;
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

        builder
            .Property(b => b.Description)
            .HasMaxLength(MaxDescriptionLength)
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
            .WithMany()
            .HasForeignKey("AuthorId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}