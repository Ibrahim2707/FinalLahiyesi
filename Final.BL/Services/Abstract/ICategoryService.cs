using Final.BL.DTOs.Category;
using Final.Core.Entities;

namespace Final.BL.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(CategoryCreateDTO dto);

        Task<Category> UpdateAsync(int id, CategoryUpdateDTO dto);

        Task<IEnumerable<CategoryGetDTO>> GetAllAsync();

        Task<CategoryGetDTO> GetAsync(int id);

        Task DeleteAsync(int id);
    }
}