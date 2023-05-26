namespace BookStore.Infrastructure.Common.Extensions;

using System.Linq;
using System.Reflection;
using Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

internal static class ModelBuilderExtensions
{
    private static readonly MethodInfo? SetIsDeletedQueryFilterMethod
        = typeof(ModelBuilderExtensions).GetMethod(
            nameof(SetIsDeletedQueryFilter),
            BindingFlags.NonPublic | BindingFlags.Static);

    public static void ApplyIndexesConfigurations(
        this ModelBuilder modelBuilder)
        => modelBuilder
            .Model
            .GetEntityTypes()
            .Where(entityType => typeof(IEntity)
                .IsAssignableFrom(entityType.ClrType))
            .ForEach(entityType =>
            {
                var clrType = entityType.ClrType;

                modelBuilder.Entity(clrType).HasIndex(nameof(IEntity.IsDeleted));

                var method = SetIsDeletedQueryFilterMethod?.MakeGenericMethod(clrType);

                method?.Invoke(null, new object?[] { modelBuilder });
            });

    private static void SetIsDeletedQueryFilter<TEntity>(
        ModelBuilder builder)
        where TEntity : class, IEntity
        => builder
            .Entity<TEntity>()
            .HasQueryFilter(e => !e.IsDeleted);
}