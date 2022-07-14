namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Sales.Customers.Queries.Search;
using Microsoft.AspNetCore.Mvc;

public class CustomersController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<CustomersSearchResponseModel>> Search(
        [FromQuery] CustomersSearchQuery query)
        => await this.Send(query);
}