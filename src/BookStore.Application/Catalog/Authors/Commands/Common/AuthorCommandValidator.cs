namespace BookStore.Application.Catalog.Authors.Commands.Common;

using Application.Common;
using FluentValidation;

using static Domain.Catalog.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class AuthorCommandValidator<TCommand> : AbstractValidator<AuthorCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public AuthorCommandValidator()
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