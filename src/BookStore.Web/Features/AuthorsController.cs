namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Catalog.Authors.Commands.Create;
using Application.Catalog.Authors.Queries.Details;
using Application.Catalog.Authors.Queries.Search;
using Microsoft.AspNetCore.Mvc;

public class AuthorsController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<AuthorsSearchResponseModel>> Search(
        [FromQuery] AuthorsSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<AuthorDetailsResponseModel>> Details(
        [FromRoute] AuthorDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        AuthorCreateCommand command)
        => await this.Send(command);
}