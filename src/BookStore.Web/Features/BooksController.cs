namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Catalog.Books.Queries.Details;
using Domain.Catalog.Models.Books;
using Microsoft.AspNetCore.Mvc;

public class BooksController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<Book>> Details(
        BookDetailsQuery query)
        => await this.Send(query);
}