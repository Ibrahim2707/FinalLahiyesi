using Final.Core.Entities;
using Final.Core.Repositories;
using Final.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Final.DAL.Repositories
{
    public class BasketRepository(FinalDbContext context) : GenericRepository<BasketItem>(context), IBasketRepository
    {
        public Task<BasketItem?> GetItemAsync(string basketKey, int productId) =>
            context.BasketItems.FirstOrDefaultAsync(x => x.BasketKey == basketKey && x.ProductId == productId);

        public async Task<IReadOnlyList<BasketItem>> GetItemsAsync(string basketKey) =>
            await context.BasketItems
                .AsNoTracking()
                .Include(x => x.Product)
                .Where(x => x.BasketKey == basketKey)
                .OrderByDescending(x => x.CreatedTime)
                .ToListAsync();

        public async Task ClearAsync(string basketKey)
        {
            await context.BasketItems
                .Where(x => x.BasketKey == basketKey)
                .ExecuteDeleteAsync();
        }
    }
}
