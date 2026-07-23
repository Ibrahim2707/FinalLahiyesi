using Final.BL.DTOs.Basket;
using Final.BL.Exceptions;
using Final.BL.Services.Abstract;
using Final.Core.Entities;
using Final.Core.Repositories;

namespace Final.BL.Services.Implements
{
    public class BasketService(IBasketRepository basketRepository, IProductRepository productRepository) : IBasketService
    {
        public async Task<BasketGetDTO> GetAsync(string basketKey)
        {
            ValidateBasketKey(basketKey);
            var items = await basketRepository.GetItemsAsync(basketKey);
            return ToDto(basketKey, items);
        }

        public async Task<BasketGetDTO> AddAsync(string basketKey, BasketItemCreateDTO dto)
        {
            ValidateBasketKey(basketKey);
            var product = await productRepository.GetByIdAsync(dto.ProductId)
                ?? throw new NotFoundException<Product>();

            var item = await basketRepository.GetItemAsync(basketKey, dto.ProductId);
            var quantity = (item?.Quantity ?? 0) + dto.Quantity;
            EnsureStock(product, quantity);

            if (item is null)
            {
                await basketRepository.AddAsync(new BasketItem
                {
                    BasketKey = basketKey,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                });
            }
            else
            {
                item.Quantity = quantity;
            }

            await basketRepository.SaveAsync();
            return await GetAsync(basketKey);
        }

        public async Task<BasketGetDTO> UpdateAsync(string basketKey, int productId, BasketItemUpdateDTO dto)
        {
            ValidateBasketKey(basketKey);
            var item = await basketRepository.GetItemAsync(basketKey, productId)
                ?? throw new NotFoundException("Basket item not found.");

            if (dto.Quantity == 0)
            {
                basketRepository.Remove(item);
            }
            else
            {
                var product = await productRepository.GetByIdAsync(productId)
                    ?? throw new NotFoundException<Product>();
                EnsureStock(product, dto.Quantity);
                item.Quantity = dto.Quantity;
            }

            await basketRepository.SaveAsync();
            return await GetAsync(basketKey);
        }

        public async Task RemoveAsync(string basketKey, int productId)
        {
            ValidateBasketKey(basketKey);
            var item = await basketRepository.GetItemAsync(basketKey, productId)
                ?? throw new NotFoundException("Basket item not found.");
            basketRepository.Remove(item);
            await basketRepository.SaveAsync();
        }

        public async Task ClearAsync(string basketKey)
        {
            ValidateBasketKey(basketKey);
            await basketRepository.ClearAsync(basketKey);
        }

        private static void ValidateBasketKey(string basketKey)
        {
            if (string.IsNullOrWhiteSpace(basketKey) || basketKey.Length > 64)
                throw new ArgumentException("Basket key is required and must be at most 64 characters.");
        }

        private static void EnsureStock(Product product, int quantity)
        {
            if (quantity > product.Stock)
                throw new InvalidOperationException("Requested quantity exceeds product stock.");
        }

        private static BasketGetDTO ToDto(string basketKey, IReadOnlyList<BasketItem> items) => new()
        {
            BasketKey = basketKey,
            Items = items.Select(x => new BasketItemGetDTO
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                ProductImage = x.Product.Image,
                UnitPrice = x.Product.DiscountPrice ?? x.Product.Price,
                Quantity = x.Quantity
            }).ToList()
        };
    }
}
