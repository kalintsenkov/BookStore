namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Sales.Orders.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class OrdersController : ApiController
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(
        [FromRoute] OrderCreateCommand command)
        => await this.Send(command);
}