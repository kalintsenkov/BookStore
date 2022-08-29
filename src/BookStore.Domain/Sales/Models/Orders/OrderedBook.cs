namespace BookStore.Domain.Sales.Models.Orders;

using Common.Models;
using Exceptions;

using static ModelConstants.OrderedBook;

public class OrderedBook : Entity<int>
{
    internal OrderedBook(int bookId, int quantity)
    {
        this.Validate(quantity);

        this.BookId = bookId;
        this.Quantity = quantity;
    }

    public int BookId { get; }

    public int Quantity { get; }

    public override int GetHashCode() => (this.Id, this.BookId).GetHashCode();

    private void Validate(int quantity)
        => Guard.AgainstOutOfRange<InvalidOrderException>(
            quantity,
            MinQuantityValue,
            MaxQuantityValue,
            nameof(this.Quantity));
}