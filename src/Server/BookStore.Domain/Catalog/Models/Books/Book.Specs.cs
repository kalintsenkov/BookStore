namespace BookStore.Domain.Catalog.Models.Books;

using System;
using Authors;
using Exceptions;
using FakeItEasy;
using FluentAssertions;
using Xunit;

public class BookSpecs
{
    private const string ValidTitle = "Test Title";
    private const decimal ValidPrice = 10;
    private const int ValidQuantity = 1;
    private const string ValidImageUrl = "https://test@test.com";
    private const string ValidDescription = "Test description";

    [Fact]
    public void ValidBookShouldNotThrowException()
    {
        var author = A.Dummy<Author>();

        Action act = () => new Book(ValidTitle, ValidPrice, ValidQuantity, ValidImageUrl, ValidDescription, Genre.Adventure, author);

        act.Should().NotThrow<InvalidBookException>();
    }

    [Theory]
    [InlineData("t")]
    [InlineData("")]
    [InlineData("   ")]
    public void InvalidBookTitleShouldThrowException(string title)
    {
        var author = A.Dummy<Author>();

        Action act = () => new Book(title, ValidPrice, ValidQuantity, ValidImageUrl, ValidDescription, Genre.Adventure, author);

        act.Should().Throw<InvalidBookException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(0.1)]
    public void InvalidBookPriceShouldThrowException(decimal price)
    {
        var author = A.Dummy<Author>();

        Action act = () => new Book(ValidTitle, price, ValidQuantity, ValidImageUrl, ValidDescription, Genre.Adventure, author);

        act.Should().Throw<InvalidBookException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void InvalidBookQuantityShouldThrowException(int quantity)
    {
        var author = A.Dummy<Author>();

        Action act = () => new Book(ValidTitle, ValidPrice, quantity, ValidImageUrl, ValidDescription, Genre.Adventure, author);

        act.Should().Throw<InvalidBookException>();
    }

    [Theory]
    [InlineData("test@test.com")]
    [InlineData("")]
    [InlineData("   ")]
    public void InvalidBookImageUrlShouldThrowException(string imageUrl)
    {
        var author = A.Dummy<Author>();

        Action act = () => new Book(ValidTitle, ValidPrice, ValidQuantity, imageUrl, ValidDescription, Genre.Adventure, author);

        act.Should().Throw<InvalidBookException>();
    }

    [Theory]
    [InlineData("t")]
    [InlineData("")]
    [InlineData("   ")]
    public void InvalidBookDescriptionShouldThrowException(string description)
    {
        var author = A.Dummy<Author>();

        Action act = () => new Book(ValidTitle, ValidPrice, ValidQuantity, ValidImageUrl, description, Genre.Adventure, author);

        act.Should().Throw<InvalidBookException>();
    }
}