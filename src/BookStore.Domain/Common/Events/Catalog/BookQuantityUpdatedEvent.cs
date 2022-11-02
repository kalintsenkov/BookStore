namespace BookStore.Domain.Common.Events.Catalog;

public class BookQuantityUpdatedEvent : IDomainEvent
{
    public BookQuantityUpdatedEvent(int id, int quantity)
    {
        this.Id = id;
        this.Quantity = quantity;
    }

    public int Id { get; }

    public int Quantity { get; }
}