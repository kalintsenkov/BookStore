namespace BookStore.Application.Catalog.Books.Commands.Common;

using Application.Common;

public abstract class BookCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public required string Title { get; init; }

    public required decimal Price { get; init; }

    public required int Quantity { get; init; }

    public required string ImageUrl { get; init; } 

    public required string Description { get; init; }

    public required int Genre { get; init; }

    public required string Author { get; init; }
}