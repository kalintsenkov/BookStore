namespace BookStore.Application.Catalog.Books.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly IBookQueryRepository bookRepository;

        public BooksSearchQueryHandler(IBookQueryRepository bookRepository)
            => this.bookRepository = bookRepository;

        public async Task<BooksSearchResponseModel> Handle(
            BooksSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetBookSpecification(request);

            var searchOrder = new BooksSearchSortOrder(
                request.SortBy,
                request.Order);

            var skip = (request.Page - 1) * BooksPerPage;

            var booksListing = await this.bookRepository.GetBooksListing(
                specification,
                searchOrder,
                skip,
                take: BooksPerPage,
                cancellationToken);

            var totalBooks = await this.bookRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalBooks / BooksPerPage);

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