namespace BookStore.Application.Catalog.Books.Queries.Search;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Common;
using Domain.Catalog.Models.Books;
using Domain.Catalog.Specifications.Books;
using Domain.Common;
using MediatR;

public class BooksSearchQuery : IRequest<BooksSearchResponseModel>
{
    private const int BooksPerPage = 10;

    public string? Title { get; init; }

    public decimal? MinPrice { get; init; }

    public decimal? MaxPrice { get; init; }

    public int? Genre { get; init; }

    public string? Author { get; init; }

    public string? SortBy { get; init; }

    public string? Order { get; init; }

    public int Page { get; init; } = 1;

    public class BooksSearchQueryHandler : IRequestHandler<BooksSearchQuery, BooksSearchResponseModel>
    {
        private readonly IMemoryDatabase memoryDatabase;
        private readonly IBookQueryRepository bookRepository;

        public BooksSearchQueryHandler(
            IMemoryDatabase memoryDatabase,
            IBookQueryRepository bookRepository)
        {
            this.memoryDatabase = memoryDatabase;
            this.bookRepository = bookRepository;
        }

        public async Task<BooksSearchResponseModel> Handle(
            BooksSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetBookSpecification(request);

            var searchOrder = new BooksSearchSortOrder(
                request.SortBy,
                request.Order);

            var totalBooks = await this.bookRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalBooks / BooksPerPage);

            var isDefaultQuery = request is
            {
                Page: 1,
                Title: null,
                MinPrice: null,
                MaxPrice: null,
                Genre: null,
                Author: null,
                SortBy: null,
                Order: null
            };

            if (isDefaultQuery)
            {
                var cachedBooks = await this.memoryDatabase.Get<List<BookResponseModel>>("books:search");

                if (cachedBooks is not null && cachedBooks.Any())
                {
                    return new BooksSearchResponseModel(cachedBooks, request.Page, totalPages);
                }
            }

            var skip = (request.Page - 1) * BooksPerPage;

            var booksListing = await this.bookRepository.GetBooksListing(
                specification,
                searchOrder,
                skip,
                take: BooksPerPage,
                cancellationToken);

            if (isDefaultQuery)
            {
                await this.memoryDatabase.AddOrUpdate("books:search", booksListing);
            }

            return new BooksSearchResponseModel(booksListing, request.Page, totalPages);
        }

        private Specification<Book> GetBookSpecification(
            BooksSearchQuery request)
            => new BookByTitleSpecification(request.Title)
                .And(new BookByPriceSpecification(request.MinPrice, request.MaxPrice))
                .And(new BookByGenreSpecification(request.Genre))
                .And(new BookByAuthorSpecification(request.Author));
    }
}