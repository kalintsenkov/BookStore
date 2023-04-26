namespace BookStore.Application.Catalog.Books.Commands.Edit;

using Common;
using FluentValidation;

public class BookEditCommandValidator : AbstractValidator<BookEditCommand>
{
    public BookEditCommandValidator()
        => this.Include(new BookCommandValidator<BookEditCommand>());
}