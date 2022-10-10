namespace BookStore.Domain.Common.Events.Catalog;

public class BookUpdatedEvent : IDomainEvent
{
    public BookUpdatedEvent(
        int id,
        string title,
        decimal price,
        int quantity)
    {
        Id = id;
        Title = title;
        Price = price;
        Quantity = quantity;
    }

    public int Id { get; }

    public string Title { get; }

    public decimal Price { get; }

    public int Quantity { get; }
}