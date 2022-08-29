namespace BookStore.Domain.Sales.Events;

using Common;

public class OrderedBookEvent : IDomainEvent
{
    public OrderedBookEvent(int bookId, int quantity)
    {
        this.BookId = bookId;
        this.Quantity = quantity;
    }

    public int BookId { get; }

    public int Quantity { get; }
}