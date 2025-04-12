using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CartController(ICartService cartService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCartById(string id)
        {
            ShoppingCart? cart = await cartService.GetCartAsync(id);
            return Ok(cart ?? new ShoppingCart { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> updateCart(ShoppingCart cart)
        {
            ShoppingCart? updatedCart = await cartService.SetCartAsync(cart);

            if (updatedCart == null) return BadRequest("Problem with cart.");

            return updatedCart;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCart(string id)
        {
            var result = await cartService.DeleteCartAsync(id);

            if (!result) return BadRequest("Problem with deleting cart.");

            return Ok();
        }
    }
}
