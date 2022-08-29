namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Catalog.Books.Commands.Create;
using Application.Catalog.Books.Commands.Delete;
using Application.Catalog.Books.Commands.Edit;
using Application.Catalog.Books.Queries.Common;
using Application.Catalog.Books.Queries.Details;
using Application.Catalog.Books.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class BooksController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<BooksSearchResponseModel>> Search(
        [FromQuery] BooksSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<BookResponseModel?>> Details(
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

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] BookDeleteCommand command)
        => await this.Send(command);
}