using Final.Core.Entities;

namespace Final.Core.Repositories
{
    public interface IBasketRepository : IGenericRepository<BasketItem>
    {
        Task<BasketItem?> GetItemAsync(string basketKey, int productId);
        Task<IReadOnlyList<BasketItem>> GetItemsAsync(string basketKey);
        Task ClearAsync(string basketKey);
    }
}
