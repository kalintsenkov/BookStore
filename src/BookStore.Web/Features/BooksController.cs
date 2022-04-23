namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Catalog.Books.Commands.Create;
using Application.Catalog.Books.Queries.Details;
using Microsoft.AspNetCore.Mvc;

public class BooksController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<BookDetailsResponseModel>> Details(
        [FromRoute] BookDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        BookCreateCommand command)
        => await this.Send(command);
}