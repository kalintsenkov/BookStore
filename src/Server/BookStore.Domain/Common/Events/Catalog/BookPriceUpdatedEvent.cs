namespace BookStore.Domain.Common.Events.Catalog;

public class BookPriceUpdatedEvent : IDomainEvent
{
    public BookPriceUpdatedEvent(int id, decimal price)
    {
        this.Id = id;
        this.Price = price;
    }

    public int Id { get; }

    public decimal Price { get; }
}