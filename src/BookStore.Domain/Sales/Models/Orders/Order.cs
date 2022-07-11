namespace BookStore.Domain.Sales.Models.Orders;

using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Models;
using Customers;
using Exceptions;

public class Order : Entity<int>, IAggregateRoot
{
    private readonly HashSet<OrderedBook> orderedBooks;

    internal Order(
        DateTime date,
        State state,
        Customer customer)
    {
        this.Date = date;
        this.State = state;
        this.Customer = customer;

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

    public decimal TotalPrice => this.orderedBooks.Sum(o => o.Quantity * o.Book.Price);

    public IReadOnlyCollection<OrderedBook> OrderedBooks => this.orderedBooks.ToList().AsReadOnly();

    public Order Cancel()
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

        return this;
    }
}