namespace BookStore.Domain.Catalog.Models.Books;

using Common.Models;

public class Genre : Enumeration
{
    public static readonly Genre Horror = new(1, nameof(Horror));
    public static readonly Genre Fantasy = new(2, nameof(Fantasy));
    public static readonly Genre Mystery = new(3, nameof(Mystery));
    public static readonly Genre Romance = new(4, nameof(Romance));
    public static readonly Genre History = new(5, nameof(History));
    public static readonly Genre Biography = new(6, nameof(Biography));
    public static readonly Genre Fiction = new(7, nameof(Fiction));
    public static readonly Genre Drama = new(8, nameof(Drama));
    public static readonly Genre Dystopian = new(9, nameof(Dystopian));
    public static readonly Genre Adventure = new(10, nameof(Adventure));

    private Genre(int value)
        : this(value, FromValue<Genre>(value).Name)
    {
    }

    private Genre(int value, string name)
        : base(value, name)
    {
    }
}