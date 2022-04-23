namespace BookStore.Infrastructure.Catalog.Configurations;

using Domain.Catalog.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Catalog.Models.ModelConstants.Common;

internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder
            .HasKey(g => g.Id);

        builder
            .Property(g => g.Name)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .Property(g => g.Description)
            .HasMaxLength(MaxDescriptionLength)
            .IsRequired();
    }
}