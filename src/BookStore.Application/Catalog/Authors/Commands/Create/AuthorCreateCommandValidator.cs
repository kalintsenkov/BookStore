namespace BookStore.Application.Catalog.Authors.Commands.Create;

using FluentValidation;

using static Domain.Catalog.Models.ModelConstants.Common;

public class AuthorCreateCommandValidator : AbstractValidator<AuthorCreateCommand>
{
    public AuthorCreateCommandValidator()
    {
        this.RuleFor(b => b.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(b => b.Description)
            .MinimumLength(MinDescriptionLength)
            .MaximumLength(MaxDescriptionLength)
            .NotEmpty();
    }
}