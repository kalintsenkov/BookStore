namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Common;
using Application.Sales.Orders.Commands.Cancel;
using Application.Sales.Orders.Commands.Create;
using Application.Sales.Orders.Commands.Ship;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class OrdersController : ApiController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<int>> Create(
        [FromRoute] OrderCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id + PathSeparator + nameof(Ship))]
    public async Task<ActionResult> Ship(
        int id, OrderShipCommand command)
        => await this.Send(command.SetId(id));

    [HttpPut]
    [Route(Id + PathSeparator + nameof(Cancel))]
    public async Task<ActionResult> Cancel(
        int id, OrderCancelCommand command)
        => await this.Send(command.SetId(id));
}