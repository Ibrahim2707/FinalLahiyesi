using Final.BL.DTOs.Basket;
using Final.BL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers
{
    [ApiController]
    [Route("api/baskets/{basketKey}")]
    public class BasketController(IBasketService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string basketKey) => Ok(await service.GetAsync(basketKey));

        [HttpPost("items")]
        public async Task<IActionResult> Add(string basketKey, BasketItemCreateDTO dto) =>
            Ok(await service.AddAsync(basketKey, dto));

        [HttpPut("items/{productId:int}")]
        public async Task<IActionResult> Update(string basketKey, int productId, BasketItemUpdateDTO dto) =>
            Ok(await service.UpdateAsync(basketKey, productId, dto));

        [HttpDelete("items/{productId:int}")]
        public async Task<IActionResult> Remove(string basketKey, int productId)
        {
            await service.RemoveAsync(basketKey, productId);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Clear(string basketKey)
        {
            await service.ClearAsync(basketKey);
            return NoContent();
        }
    }
}
