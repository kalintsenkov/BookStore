namespace BookStore.Domain.Sales.Models.Orders;

using Common.Models;

public class Book : Entity<int>
{
    internal Book(
        string title,
        decimal price,
        int quantity,
        bool isAvailable)
    {
        this.Title = title;
        this.Price = price;
        this.Quantity = quantity;
        this.IsAvailable = isAvailable;
    }

    public string Title { get; }

    public decimal Price { get; }

    public int Quantity { get; }

    public bool IsAvailable { get; }
}