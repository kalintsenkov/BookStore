namespace BookStore.Domain.Sales.Models.ShoppingCarts;

using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Models;
using Customers;
using Exceptions;
using Orders;

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
        var existingBook = this.books.SingleOrDefault(b => b.Book.Id == book.Id);

        if (existingBook is not null)
        {
            var existingBookQuantity = existingBook.Quantity;

            existingBook.UpdateQuantity(existingBookQuantity + quantity);

            return this;
        }

        this.books.Add(new ShoppingCartBook(book, quantity));

        return this;
    }

    public ShoppingCart RemoveBook(int bookId)
    {
        var bookToRemove = this.books.SingleOrDefault(b => b.Book.Id == bookId);

        if (bookToRemove is null)
        {
            throw new InvalidShoppingCartException("This book does not exist.");
        }

        this.books.Remove(bookToRemove);

        return this;
    }
}