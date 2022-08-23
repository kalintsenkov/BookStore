namespace BookStore.Domain.Sales.Models.Orders;

using System;
using System.Collections.Generic;
using System.Linq;
using Books;
using Common;
using Common.Models;
using Customers;
using Exceptions;

public class Order : Entity<int>, IAggregateRoot
{
    private HashSet<OrderedBook> orderedBooks;

    internal Order(Customer customer)
    {
        this.Customer = customer;

        this.Date = DateTime.UtcNow;
        this.State = State.Pending;

        this.orderedBooks = new HashSet<OrderedBook>();
    }

    private Order(DateTime date)
    {
        this.Date = date;

        this.State = default!;
        this.Customer = default!;

        this.orderedBooks = new HashSet<OrderedBook>();
    }

    public DateTime Date { get; private set; }

    public State State { get; private set; }

    public Customer Customer { get; private set; }

    public decimal TotalPrice => this.orderedBooks.Sum(ob => ob.Quantity * ob.Book.Price);

    public IReadOnlyCollection<OrderedBook> OrderedBooks
    {
        get => this.orderedBooks.ToList().AsReadOnly();
        private set => this.orderedBooks = value.ToHashSet();
    }

    public Order MarkAsCanceled()
    {
        if (this.State != State.Pending)
        {
            throw new InvalidOrderException("Can't cancel an order that is not pending.");
        }

        this.State = State.Canceled;

        return this;
    }

    public Order MarkAsShipped()
    {
        if (this.State != State.Pending)
        {
            throw new InvalidOrderException("Can't mark as shipped an order that is not pending.");
        }

        this.State = State.Shipped;

        return this;
    }

    public Order OrderBook(Book book, int quantity)
    {
        this.orderedBooks.Add(new OrderedBook(book, quantity));

        var bookQuantity = book.Quantity;
        var orderQuantity = bookQuantity - quantity;

        book.UpdateQuantity(orderQuantity);

        return this;
    }
}