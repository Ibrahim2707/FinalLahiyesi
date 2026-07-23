using Final.BL.DTOs.Basket;

namespace Final.BL.Services.Abstract
{
    public interface IBasketService
    {
        Task<BasketGetDTO> GetAsync(string basketKey);
        Task<BasketGetDTO> AddAsync(string basketKey, BasketItemCreateDTO dto);
        Task<BasketGetDTO> UpdateAsync(string basketKey, int productId, BasketItemUpdateDTO dto);
        Task RemoveAsync(string basketKey, int productId);
        Task ClearAsync(string basketKey);
    }
}
