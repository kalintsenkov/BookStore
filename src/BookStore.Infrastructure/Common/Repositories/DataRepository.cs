namespace BookStore.Infrastructure.Common.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Common;
using Domain.Common.Models;
using Events;
using Microsoft.EntityFrameworkCore;
using Persistence;

internal abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
    where TDbContext : IDbContext
    where TEntity : class, IEntity, IAggregateRoot
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

    protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

    protected IQueryable<TEntity> AllAsNoTracking() => this.All().AsNoTracking();

    public async Task Save(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        this.Data.Update(entity);

        await this.DispatchEvents(entity);

        await this.Data.SaveChangesAsync(cancellationToken);
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