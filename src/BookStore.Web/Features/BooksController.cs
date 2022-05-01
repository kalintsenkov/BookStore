namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Catalog.Books.Commands.ChangeAvailability;
using Application.Catalog.Books.Commands.Create;
using Application.Catalog.Books.Commands.Delete;
using Application.Catalog.Books.Commands.Edit;
using Application.Catalog.Books.Queries.Details;
using Application.Common;
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

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, BookEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpPut]
    [Route(Id + PathSeparator + nameof(ChangeAvailability))]
    public async Task<ActionResult> ChangeAvailability(
        [FromRoute] BookChangeAvailabilityCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] BookDeleteCommand command)
        => await this.Send(command);
}