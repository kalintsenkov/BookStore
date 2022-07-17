namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Common;
using Application.Sales.Customers.Commands.Edit;
using Application.Sales.Customers.Queries.Common;
using Application.Sales.Customers.Queries.Details;
using Application.Sales.Customers.Queries.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class CustomersController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<CustomersSearchResponseModel>> Search(
        [FromQuery] CustomersSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<CustomerResponseModel?>> Details(
        [FromRoute] CustomerDetailsQuery query)
        => await this.Send(query);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, CustomerEditCommand command)
        => await this.Send(command.SetId(id));
}