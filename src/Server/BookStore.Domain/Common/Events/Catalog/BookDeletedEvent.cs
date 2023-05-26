namespace BookStore.Domain.Common.Events.Catalog;

public class BookDeletedEvent : IDomainEvent
{
    public BookDeletedEvent(int id) => this.Id = id;

    public int Id { get; }
}