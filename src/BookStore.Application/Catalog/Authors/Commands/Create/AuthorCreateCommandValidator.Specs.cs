namespace BookStore.Application.Catalog.Authors.Commands.Create;

using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

using static Domain.Catalog.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class AuthorCreateCommandValidatorSpecs
{
    private readonly AuthorCreateCommandValidator validator = new();

    private static readonly string InvalidMinNameLength = new('t', MinNameLength - 1);
    private static readonly string InvalidMinDescriptionLength = new('t', MinDescriptionLength - 1);

    private static readonly string InvalidMaxNameLength = new('t', MaxNameLength + 1);
    private static readonly string InvalidMaxDescriptionLength = new('t', MaxDescriptionLength + 1);

    private static readonly string ValidMinNameLength = new('t', MinNameLength);
    private static readonly string ValidMinDescriptionLength = new('t', MinDescriptionLength);

    private static readonly string ValidMaxNameLength = new('t', MaxNameLength);
    private static readonly string ValidMaxDescriptionLength = new('t', MaxDescriptionLength);

    [Theory]
    [MemberData(nameof(InvalidData))]
    public void ShouldHaveValidationErrorIfNameAndDescriptionHaveInvalidLength(
        string name,
        string description)
    {
        var testResult = this.validator.TestValidate(new AuthorCreateCommand
        {
            Name = name,
            Description = description
        });

        testResult.IsValid.Should().BeFalse();
        testResult.ShouldHaveValidationErrorFor(a => a.Name);
        testResult.ShouldHaveValidationErrorFor(a => a.Description);
    }

    [Theory]
    [MemberData(nameof(ValidData))]
    public void ShouldNotHaveValidationErrorIfNameAndDescriptionHaveValidLength(
        string name,
        string description)
    {
        var testResult = this.validator.TestValidate(new AuthorCreateCommand
        {
            Name = name,
            Description = description
        });

        testResult.IsValid.Should().BeTrue();
        testResult.ShouldNotHaveValidationErrorFor(a => a.Name);
        testResult.ShouldNotHaveValidationErrorFor(a => a.Description);
    }

    public static IEnumerable<object[]> InvalidData()
    {
        yield return new object[] { InvalidMinNameLength, InvalidMinDescriptionLength };
        yield return new object[] { InvalidMaxNameLength, InvalidMaxDescriptionLength };
    }

    public static IEnumerable<object[]> ValidData()
    {
        yield return new object[] { ValidMinNameLength, ValidMinDescriptionLength };
        yield return new object[] { ValidMaxNameLength, ValidMaxDescriptionLength };
    }
}