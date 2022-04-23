namespace BookStore.Infrastructure.Catalog.Configurations;

using Domain.Catalog.Models.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Catalog.Models.ModelConstants.Common;

internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(g => g.Name)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .Property(g => g.Description)
            .HasMaxLength(MaxDescriptionLength)
            .IsRequired();

        builder
            .HasMany(a => a.Books)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired()
            .Metadata
            .PrincipalToDependent!
            .SetField("books");
    }
}