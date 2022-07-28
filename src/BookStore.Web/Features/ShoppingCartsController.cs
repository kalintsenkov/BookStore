namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Sales.ShoppingCarts.Commands.AddBook;
using Application.Sales.ShoppingCarts.Commands.EditQuantity;
using Application.Sales.ShoppingCarts.Commands.RemoveBook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class ShoppingCartsController : ApiController
{
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