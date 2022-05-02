namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Catalog.Authors.Commands.Create;
using Application.Catalog.Authors.Commands.Delete;
using Application.Catalog.Authors.Queries.Details;
using Application.Catalog.Authors.Queries.Search;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class AuthorsController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<AuthorsSearchResponseModel>> Search(
        [FromQuery] AuthorsSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<AuthorDetailsResponseModel>> Details(
        [FromRoute] AuthorDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        AuthorCreateCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] AuthorDeleteCommand command)
        => await this.Send(command);
}