namespace BookStore.Domain.Catalog.Models.Authors;

using System;
using Bogus;
using Common.Models;
using FakeItEasy;
using static Common.Models.ModelConstants.Common;

public class AuthorFakes
{
    public class AuthorDummyFactory : IDummyFactory
    {
        public Priority Priority => Priority.Default;

        public bool CanCreate(Type type) => type == typeof(Author);

        public object? Create(Type type) => Data.GetAuthor();
    }

    public static class Data
    {
        public static Author GetAuthor(int id = 1)
            => new Faker<Author>()
                .CustomInstantiator(f => new Author(
                    f.Random.String2(MinNameLength, MaxNameLength),
                    f.Random.String2(MinDescriptionLength, MaxDescriptionLength)))
                .Generate()
                .SetId(id);
    }
}