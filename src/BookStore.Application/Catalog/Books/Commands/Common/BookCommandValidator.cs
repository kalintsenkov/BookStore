namespace BookStore.Application.Catalog.Books.Commands.Common;

using System;
using Application.Common;
using Domain.Catalog.Models.Books;
using Domain.Common.Models;
using FluentValidation;

using static Domain.Catalog.Models.ModelConstants.Common;
using static Domain.Catalog.Models.ModelConstants.Book;
using static Domain.Common.Models.ModelConstants.Common;

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

        this.RuleFor(b => b.Quantity)
            .GreaterThanOrEqualTo(MinQuantityValue)
            .LessThan(MaxQuantityValue)
            .NotEmpty();

        this.RuleFor(b => b.ImageUrl)
            .MaximumLength(MaxUrlLength)
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("'{PropertyName}' must be a valid url.")
            .NotEmpty();

        this.RuleFor(b => b.Description)
            .MinimumLength(MinDescriptionLength)
            .MaximumLength(MaxDescriptionLength)
            .NotEmpty();
        
        this.RuleFor(c => c.Genre)
            .Must(Enumeration.HasValue<Genre>)
            .WithMessage("'{PropertyName}' is not valid.");

        this.RuleFor(b => b.Author)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
    }
}