namespace BookStore.Domain.Sales.Models.ShoppingCarts;

using Books;
using Common.Models;
using Exceptions;

using static ModelConstants.OrderedBook;

public class ShoppingCartBook : Entity<int>
{
    internal ShoppingCartBook(Book book, int quantity)
    {
        this.Validate(quantity);

        this.Book = book;
        this.Quantity = quantity;
    }

    private ShoppingCartBook(int quantity)
    {
        this.Book = default!;

        this.Quantity = quantity;
    }

    public Book Book { get; private set; }

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