namespace BookStore.Domain.Common.Events.Catalog;

public class BookCreatedEvent : IDomainEvent
{
    public BookCreatedEvent(
        string title,
        decimal price,
        int quantity,
        string imageUrl)
    {
        this.Title = title;
        this.Price = price;
        this.Quantity = quantity;
        this.ImageUrl = imageUrl;
    }

    public string Title { get; }

    public decimal Price { get; }

    public int Quantity { get; }

    public string ImageUrl { get; }
}