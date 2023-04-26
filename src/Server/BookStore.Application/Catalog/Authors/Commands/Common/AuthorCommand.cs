namespace BookStore.Application.Catalog.Authors.Commands.Common;

using Application.Common;

public abstract class AuthorCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string Name { get; init; } = default!;

    public string Description { get; init; } = default!;
}