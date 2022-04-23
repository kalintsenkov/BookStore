namespace BookStore.Application.Catalog.Books.Commands.Create;

using FluentValidation;

using static Domain.Catalog.Models.ModelConstants.Common;
using static Domain.Catalog.Models.ModelConstants.Book;

public class BookCreateCommandValidator : AbstractValidator<BookCreateCommand>
{
    public BookCreateCommandValidator()
    {
        this.RuleFor(b => b.Title)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(b => b.Price)
            .InclusiveBetween(MinPriceValue, MaxPriceValue)
            .NotEmpty();
    }
}