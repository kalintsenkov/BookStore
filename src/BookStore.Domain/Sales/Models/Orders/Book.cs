namespace BookStore.Domain.Sales.Models.Orders;

using Common.Models;

public class Book : Entity<int>
{
    internal Book(
        string title,
        decimal price,
        bool isAvailable)
    {
        this.Title = title;
        this.Price = price;
        this.IsAvailable = isAvailable;
    }

    public string Title { get; }

    public decimal Price { get; }

    public bool IsAvailable { get; }
}