namespace BookStore.Domain.Sales.Models.Orders;

using Common.Models;

public class State : Enumeration
{
    public static readonly State Canceled = new(1, nameof(Canceled));
    public static readonly State Pending = new(2, nameof(Pending));
    public static readonly State Shipped = new(3, nameof(Shipped));

    private State(int value)
        : this(value, FromValue<State>(value).Name)
    {
    }

    private State(int value, string name)
        : base(value, name)
    {
    }
}