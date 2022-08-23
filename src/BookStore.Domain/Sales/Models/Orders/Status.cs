namespace BookStore.Domain.Sales.Models.Orders;

using Common.Models;

public class Status : Enumeration
{
    public static readonly Status Cancelled = new(1, nameof(Cancelled));
    public static readonly Status Pending = new(2, nameof(Pending));
    public static readonly Status Completed = new(3, nameof(Completed));

    private Status(int value)
        : this(value, FromValue<Status>(value).Name)
    {
    }

    private Status(int value, string name)
        : base(value, name)
    {
    }
}