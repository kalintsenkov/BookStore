namespace BookStore.Infrastructure.Common.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Common;
using Domain.Common.Models;
using Events;
using Microsoft.EntityFrameworkCore;
using Persistence;

internal abstract class DataRepository<TDbContext, TEntity, TEntityData> : IDomainRepository<TEntity>
    where TDbContext : IDbContext
    where TEntity : class, IEntity, IAggregateRoot
    where TEntityData : class, IMapFrom<TEntity>
{
    private readonly IEventDispatcher eventDispatcher;

    protected DataRepository(
        TDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
    {
        this.Data = db;
        this.Mapper = mapper;
        this.eventDispatcher = eventDispatcher;
    }

    protected TDbContext Data { get; }

    protected IMapper Mapper { get; }

    protected IQueryable<TEntityData> All() => this.Data.Set<TEntityData>();

    protected IQueryable<TEntityData> AllAsNoTracking() => this.All().AsNoTracking();

    public async Task<TEntity> Save(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        var entityData = this.Mapper.Map<TEntityData>(entity);

        this.Data.Update(entityData);

        await this.DispatchEvents(entity);

        await this.Data.SaveChangesAsync(cancellationToken);

        this.Data.ChangeTracker.Clear();

        return this.Mapper.Map<TEntity>(entityData);
    }

    private async Task DispatchEvents(TEntity entity)
    {
        var events = entity.Events.ToArray();

        entity.ClearEvents();

        foreach (var domainEvent in events)
        {
            await this.eventDispatcher.Dispatch(domainEvent);
        }
    }
}