﻿namespace BookStore.Application.Books.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using Domain.Books.Factories.Books;
using Domain.Books.Models.Books;
using MediatR;

public class BookDetailsQuery : IRequest<Book>
{
    public class BookDetailsQueryHandler : IRequestHandler<BookDetailsQuery, Book>
    {
        private readonly IBookFactory bookFactory;

        public BookDetailsQueryHandler(IBookFactory bookFactory)
            => this.bookFactory = bookFactory;

        public Task<Book> Handle(
            BookDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var book = this.bookFactory
                .WithTitle("Some Title")
                .WithPrice(15.5m)
                .WithGenre(new Genre(
                    "Cool Genre",
                    "Some description"))
                .Build();

            return Task.FromResult(book);
        }
    }
}