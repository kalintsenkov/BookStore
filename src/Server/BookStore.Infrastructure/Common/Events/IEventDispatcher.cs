namespace BookStore.Infrastructure.Common.Events;

using System.Threading.Tasks;
using BookStore.Domain.Common.Events;

internal interface IEventDispatcher
{
    Task Dispatch(IDomainEvent domainEvent);
}