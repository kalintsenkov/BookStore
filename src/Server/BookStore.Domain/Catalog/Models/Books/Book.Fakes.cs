namespace BookStore.Domain.Catalog.Models.Books;

using System;
using Bogus;
using System.Collections.Generic;
using System.Linq;
using Authors;
using Common.Models;
using FakeItEasy;

using static Common.Models.ModelConstants.Book;
using static Common.Models.ModelConstants.Common;

public class BookFakes
{
    public class BetDummyFactory : IDummyFactory
    {
        public bool CanCreate(Type type) => type == typeof(Book);

        public object? Create(Type type) => Data.GetBook();

        public Priority Priority => Priority.Default;
    }

    public static class Data
    {
        public static IEnumerable<Book> GetBooks(int count = 10)
            => Enumerable
                .Range(1, count)
                .Select(GetBook)
                .Concat(Enumerable
                    .Range(count + 1, count * 2)
                    .Select(GetBook))
                .ToList();

        public static Book GetBook(int id = 1)
            => new Faker<Book>()
                .CustomInstantiator(f => new Book(
                    f.Random.String2(MinNameLength, MaxNameLength),
                    f.Random.Decimal(MinPriceValue, MaxPriceValue),
                    f.Random.Int(MinQuantityValue, MaxQuantityValue),
                    f.Image.LoremFlickrUrl(),
                    f.Random.String2(MinDescriptionLength, MaxDescriptionLength),
                    Genre.Adventure,
                    new Author(
                        f.Random.String2(MinNameLength, MaxNameLength),
                        f.Random.String2(MinDescriptionLength, MaxDescriptionLength))))
                .Generate()
                .SetId(id);
    }
}