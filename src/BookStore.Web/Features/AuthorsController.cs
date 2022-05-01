namespace BookStore.Web.Features;

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Catalog.Authors.Commands.Create;
using Application.Catalog.Authors.Queries.Books;
using Microsoft.AspNetCore.Mvc;

public class AuthorsController : ApiController
{
    [HttpGet]
    [Route(Id + PathSeparator + nameof(Books))]
    public async Task<ActionResult<IEnumerable<AuthorBooksResponseModel>>> Books(
        [FromRoute] AuthorBooksQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        AuthorCreateCommand command)
        => await this.Send(command);
}