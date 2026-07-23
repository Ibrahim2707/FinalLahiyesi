using Final.BL.DTOs.ProductImage;
using Final.Core.Entities;

namespace Final.BL.Services.Abstract
{
    public interface IProductImageService
    {
        Task<ProductImage> CreateAsync(ProductImageCreateDTO dto);

        Task<IEnumerable<ProductImageGetDTO>> GetAllAsync();

        Task<ProductImageGetDTO> GetAsync(int id);

        Task DeleteAsync(int id);
    }
}