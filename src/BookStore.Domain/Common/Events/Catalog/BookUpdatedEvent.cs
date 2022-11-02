namespace BookStore.Domain.Common.Events.Catalog;

public class BookUpdatedEvent : IDomainEvent
{
    public BookUpdatedEvent(
        int id,
        string title,
        decimal price,
        int quantity)
    {
        this.Id = id;
        this.Title = title;
        this.Price = price;
        this.Quantity = quantity;
    }

    public int Id { get; }

    public string Title { get; }

    public decimal Price { get; }

    public int Quantity { get; }
}