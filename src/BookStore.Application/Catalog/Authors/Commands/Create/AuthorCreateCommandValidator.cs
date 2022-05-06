namespace BookStore.Application.Catalog.Authors.Commands.Create;

using Common;
using FluentValidation;

public class AuthorCreateCommandValidator : AbstractValidator<AuthorCreateCommand>
{
    public AuthorCreateCommandValidator()
        => this.Include(new AuthorCommandValidator<AuthorCreateCommand>());
}