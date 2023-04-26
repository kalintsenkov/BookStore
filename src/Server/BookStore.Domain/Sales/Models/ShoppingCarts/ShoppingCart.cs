namespace BookStore.Domain.Sales.Models.ShoppingCarts;

using System.Collections.Generic;
using System.Linq;
using Books;
using Common;
using Common.Models;
using Customers;
using Exceptions;

public class ShoppingCart : Entity<int>, IAggregateRoot
{
    private readonly HashSet<ShoppingCartBook> books;

    internal ShoppingCart(Customer customer)
    {
        this.Customer = customer;

        this.books = new HashSet<ShoppingCartBook>();
    }

    private ShoppingCart()
    {
        this.Customer = default!;

        this.books = new HashSet<ShoppingCartBook>();
    }

    public Customer Customer { get; }

    public IReadOnlyCollection<ShoppingCartBook> Books => this.books.ToList().AsReadOnly();

    public ShoppingCart AddBook(Book book, int quantity)
    {
        var shoppingCartBook = this.FindBook(book.Id);

        if (shoppingCartBook is not null)
        {
            var shoppingCartBookQuantity = shoppingCartBook.Quantity;

            shoppingCartBook.UpdateQuantity(shoppingCartBookQuantity + quantity);

            return this;
        }

        this.books.Add(new ShoppingCartBook(book, quantity));

        return this;
    }

    public ShoppingCart EditBookQuantity(int bookId, int quantity)
    {
        var shoppingCartBook = this.FindBook(bookId);

        this.ValidateBook(shoppingCartBook);

        shoppingCartBook!.UpdateQuantity(quantity);

        return this;
    }

    private ShoppingCartBook? FindBook(int bookId)
        => this.books.SingleOrDefault(b => b.Book.Id == bookId);

    private void ValidateBook(ShoppingCartBook? book)
    {
        if (book is null)
        {
            throw new InvalidShoppingCartException("This book does not exist in the shopping cart.");
        }
    }
}