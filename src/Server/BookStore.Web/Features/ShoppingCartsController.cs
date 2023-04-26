namespace BookStore.Web.Features;

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Sales.ShoppingCarts.Commands.AddBook;
using Application.Sales.ShoppingCarts.Commands.EditQuantity;
using Application.Sales.ShoppingCarts.Commands.RemoveBook;
using Application.Sales.ShoppingCarts.Queries.GetBooks;
using Application.Sales.ShoppingCarts.Queries.TotalBooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class ShoppingCartsController : ApiController
{
    [HttpGet]
    [Route(nameof(Mine))]
    public async Task<ActionResult<IEnumerable<GetShoppingCartBookResponseModel>>> Mine(
        [FromQuery] GetShoppingCartBooksQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(nameof(TotalBooks))]
    public async Task<ActionResult<int>> TotalBooks(
        [FromQuery] GetShoppingCartTotalBooksQuery query)
        => await this.Send(query);

    [HttpPost]
    [Route(nameof(AddBook))]
    public async Task<ActionResult> AddBook(
        ShoppingCartAddBookCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(nameof(EditQuantity))]
    public async Task<ActionResult> EditQuantity(
        ShoppingCartEditQuantityCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Route(nameof(RemoveBook))]
    public async Task<ActionResult> RemoveBook(
        ShoppingCartRemoveBookCommand command)
        => await this.Send(command);
}