namespace BookStore.Infrastructure.Catalog.Configurations;

using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Catalog.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

internal class AuthorConfiguration : IEntityTypeConfiguration<AuthorData>
{
    public void Configure(EntityTypeBuilder<AuthorData> builder)
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