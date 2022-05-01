namespace BookStore.Application.Catalog.Books.Commands.Create;

using Common;
using FluentValidation;

public class BookCreateCommandValidator : AbstractValidator<BookCreateCommand>
{
    public BookCreateCommandValidator()
        => this.Include(new BookCommandValidator<BookCreateCommand>());
}