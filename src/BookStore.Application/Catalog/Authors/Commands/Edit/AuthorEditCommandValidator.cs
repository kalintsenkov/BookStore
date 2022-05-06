namespace BookStore.Application.Catalog.Authors.Commands.Edit;

using Common;
using FluentValidation;

public class AuthorEditCommandValidator : AbstractValidator<AuthorEditCommand>
{
    public AuthorEditCommandValidator()
        => this.Include(new AuthorCommandValidator<AuthorEditCommand>());
}