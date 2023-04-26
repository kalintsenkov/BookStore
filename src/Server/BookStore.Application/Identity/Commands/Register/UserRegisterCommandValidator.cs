namespace BookStore.Application.Identity.Commands.Register;

using FluentValidation;

using static Domain.Common.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Identity;

public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
{
    public UserRegisterCommandValidator()
    {
        this.RuleFor(u => u.FullName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(u => u.Email)
            .MinimumLength(MinEmailLength)
            .MaximumLength(MaxEmailLength)
            .EmailAddress()
            .NotEmpty();

        this.RuleFor(u => u.Password)
            .MinimumLength(MinPasswordLength)
            .MaximumLength(MaxPasswordLength)
            .NotEmpty();

        this.RuleFor(u => u.ConfirmPassword)
            .Equal(u => u.Password)
            .WithMessage("The password and confirmation password do not match.")
            .NotEmpty();
    }
}