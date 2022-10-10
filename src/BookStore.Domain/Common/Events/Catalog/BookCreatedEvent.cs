namespace BookStore.Domain.Common.Events.Catalog;

public class BookCreatedEvent : IDomainEvent
{
    public BookCreatedEvent(
        string title,
        decimal price,
        int quantity)
    {
        Title = title;
        Price = price;
        Quantity = quantity;
    }

    public string Title { get; }

    public decimal Price { get; }

    public int Quantity { get; }
}