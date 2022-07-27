namespace BookStore.Domain.Sales.Models.Orders;

using Common.Models;

public class Book : Entity<int>
{
    internal Book(
        string title,
        decimal price,
        int quantity)
    {
        this.Title = title;
        this.Price = price;
        this.Quantity = quantity;
    }

    public string Title { get; }

    public decimal Price { get; }

    public int Quantity { get; }

    public bool IsAvailable => this.Quantity is not 0;
}