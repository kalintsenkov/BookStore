﻿namespace BookStore.Application.Catalog.Books.Commands.Common;

using Application.Common;

public abstract class BookCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string Title { get; init; } = default!;

    public decimal Price { get; init; }

    public string Genre { get; init; } = default!;

    public string Author { get; init; } = default!;
}