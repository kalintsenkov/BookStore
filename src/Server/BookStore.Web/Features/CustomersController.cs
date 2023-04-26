namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Common;
using Application.Sales.Customers.Commands.Edit;
using Application.Sales.Customers.Queries.Details;
using Application.Sales.Customers.Queries.Search;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class CustomersController : ApiController
{
    [HttpGet]
    [AuthorizeAdministrator]
    public async Task<ActionResult<CustomersSearchResponseModel>> Search(
        [FromQuery] CustomersSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<CustomerDetailsResponseModel?>> Details(
        [FromRoute] CustomerDetailsQuery query)
        => await this.Send(query);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, CustomerEditCommand command)
        => await this.Send(command.SetId(id));
}