namespace BookStore.Domain.Common.Models;

using System.Collections.Generic;
using Events;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> Events { get; }

    void ClearEvents();
}