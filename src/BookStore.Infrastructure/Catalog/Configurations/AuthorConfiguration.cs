namespace BookStore.Infrastructure.Catalog.Configurations;

using Domain.Catalog.Models.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Catalog.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Name)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .Property(a => a.Description)
            .HasMaxLength(MaxDescriptionLength)
            .IsRequired();
    }
}