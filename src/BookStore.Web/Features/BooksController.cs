namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Books.Queries.Details;
using Domain.Books.Models.Books;
using Microsoft.AspNetCore.Mvc;

public class BooksController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<Book>> Details(
        BookDetailsQuery query)
        => await this.Send(query);
}