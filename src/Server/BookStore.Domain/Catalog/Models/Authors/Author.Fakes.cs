namespace BookStore.Domain.Catalog.Models.Authors;

using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Common.Models;
using FakeItEasy;

using static Common.Models.ModelConstants.Common;

public class AuthorFakes
{
    public class BetDummyFactory : IDummyFactory
    {
        public bool CanCreate(Type type) => type == typeof(Author);

        public object? Create(Type type) => Data.GetAuthor();

        public Priority Priority => Priority.Default;
    }

    public static class Data
    {
        public static IEnumerable<Author> GetAuthors(int count = 10)
            => Enumerable
                .Range(1, count)
                .Select(GetAuthor)
                .Concat(Enumerable
                    .Range(count + 1, count * 2)
                    .Select(GetAuthor))
                .ToList();

        public static Author GetAuthor(int id = 1)
            => new Faker<Author>()
                .CustomInstantiator(f => new Author(
                    f.Random.String2(MinNameLength, MaxNameLength),
                    f.Random.String2(MinDescriptionLength, MaxDescriptionLength)))
                .Generate()
                .SetId(id);
    }
}