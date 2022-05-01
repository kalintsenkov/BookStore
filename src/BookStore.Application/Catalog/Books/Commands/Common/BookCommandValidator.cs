namespace BookStore.Application.Catalog.Books.Commands.Common;

using Application.Common;
using FluentValidation;

using static Domain.Catalog.Models.ModelConstants.Common;
using static Domain.Catalog.Models.ModelConstants.Book;

public class BookCommandValidator<TCommand> : AbstractValidator<BookCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public BookCommandValidator()
    {
        this.RuleFor(b => b.Title)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(b => b.Price)
            .GreaterThanOrEqualTo(MinPriceValue)
            .LessThan(MaxPriceValue)
            .NotEmpty();

        this.RuleFor(b => b.Author)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
    }
}