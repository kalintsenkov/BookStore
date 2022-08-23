namespace BookStore.Application.Catalog.Books.Commands.Create;

using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

using static Domain.Catalog.Models.ModelConstants.Common;
using static Domain.Catalog.Models.ModelConstants.Book;
using static Domain.Common.Models.ModelConstants.Common;

public class BookCreateCommandValidatorSpecs
{
    private readonly BookCreateCommandValidator validator = new();

    private static readonly string InvalidMinTitleLength = new('t', MinNameLength - 1);
    private static readonly string InvalidMinDescriptionLength = new('t', MinDescriptionLength - 1);
    private static readonly string InvalidMinAuthorLength = new('t', MinNameLength - 1);

    private static readonly string InvalidMaxTitleLength = new('t', MaxNameLength + 1);
    private static readonly string InvalidMaxDescriptionLength = new('t', MaxDescriptionLength + 1);
    private static readonly string InvalidMaxAuthorLength = new('t', MaxNameLength + 1);

    private static readonly string ValidMinTitleLength = new('t', MinNameLength);
    private static readonly string ValidMinDescriptionLength = new('t', MinDescriptionLength);
    private static readonly string ValidMinAuthorLength = new('t', MinNameLength);

    private static readonly string ValidMaxTitleLength = new('t', MaxNameLength);
    private static readonly string ValidMaxDescriptionLength = new('t', MaxDescriptionLength);
    private static readonly string ValidMaxAuthorLength = new('t', MaxNameLength);

    [Theory]
    [MemberData(nameof(InvalidData))]
    public void ShouldHaveValidationErrorIfNameAndDescriptionHaveInvalidLength(
        string title,
        decimal price,
        int quantity,
        string description,
        string author)
    {
        var testResult = this.validator.TestValidate(new BookCreateCommand
        {
            Title = title,
            Price = price,
            Quantity = quantity,
            Description = description,
            Author = author
        });

        testResult.IsValid.Should().BeFalse();
        testResult.ShouldHaveValidationErrorFor(b => b.Title);
        testResult.ShouldHaveValidationErrorFor(b => b.Price);
        testResult.ShouldHaveValidationErrorFor(b => b.Quantity);
        testResult.ShouldHaveValidationErrorFor(b => b.Description);
        testResult.ShouldHaveValidationErrorFor(b => b.Author);
    }

    [Theory]
    [MemberData(nameof(ValidData))]
    public void ShouldNotHaveValidationErrorIfNameAndDescriptionHaveValidLength(
        string title,
        decimal price,
        int quantity,
        string description,
        string author)
    {
        var testResult = this.validator.TestValidate(new BookCreateCommand
        {
            Title = title,
            Price = price,
            Quantity = quantity,
            Description = description,
            Author = author
        });

        testResult.IsValid.Should().BeTrue();
        testResult.ShouldNotHaveValidationErrorFor(b => b.Title);
        testResult.ShouldNotHaveValidationErrorFor(b => b.Price);
        testResult.ShouldNotHaveValidationErrorFor(b => b.Quantity);
        testResult.ShouldNotHaveValidationErrorFor(b => b.Description);
        testResult.ShouldNotHaveValidationErrorFor(b => b.Author);
    }

    public static IEnumerable<object[]> InvalidData()
    {
        yield return new object[] { InvalidMinTitleLength, MinPriceValue - 1, MinQuantityValue - 1, InvalidMinDescriptionLength, InvalidMinAuthorLength };
        yield return new object[] { InvalidMaxTitleLength, MaxPriceValue, MaxQuantityValue, InvalidMaxDescriptionLength, InvalidMaxAuthorLength };
    }

    public static IEnumerable<object[]> ValidData()
    {
        yield return new object[] { ValidMinTitleLength, MinPriceValue, MinQuantityValue, ValidMinDescriptionLength, ValidMinAuthorLength };
        yield return new object[] { ValidMaxTitleLength, MaxPriceValue - 1, MaxQuantityValue - 1, ValidMaxDescriptionLength, ValidMaxAuthorLength };
    }
}