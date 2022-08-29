namespace BookStore.Domain.Sales.Models.ShoppingCarts;

using Common.Models;
using Exceptions;

using static ModelConstants.OrderedBook;

public class ShoppingCartBook : Entity<int>
{
    internal ShoppingCartBook(int bookId, int quantity)
    {
        this.Validate(quantity);

        this.BookId = bookId;
        this.Quantity = quantity;
    }

    public int BookId { get; private set; }

    public int Quantity { get; private set; }

    public ShoppingCartBook UpdateQuantity(int quantity)
    {
        this.Validate(quantity);

        this.Quantity = quantity;

        return this;
    }

    private void Validate(int quantity)
        => Guard.AgainstOutOfRange<InvalidShoppingCartException>(
            quantity,
            MinQuantityValue,
            MaxQuantityValue,
            nameof(this.Quantity));
}