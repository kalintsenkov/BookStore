namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Catalog.Authors.Commands.Create;
using Microsoft.AspNetCore.Mvc;

public class AuthorsController : ApiController
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(
        AuthorCreateCommand command)
        => await this.Send(command);
}