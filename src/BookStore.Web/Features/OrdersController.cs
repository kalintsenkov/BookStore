namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Common;
using Application.Sales.Orders.Commands.Cancel;
using Application.Sales.Orders.Commands.Complete;
using Application.Sales.Orders.Commands.Create;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class OrdersController : ApiController
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(
        [FromRoute] OrderCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [AuthorizeAdministrator]
    [Route(Id + PathSeparator + nameof(Cancel))]
    public async Task<ActionResult<int>> Cancel(
        int id, OrderCancelCommand command)
        => await this.Send(command.SetId(id));

    [HttpPut]
    [AuthorizeAdministrator]
    [Route(Id + PathSeparator + nameof(Complete))]
    public async Task<ActionResult<int>> Complete(
        int id, OrderCompleteCommand command)
        => await this.Send(command.SetId(id));
}