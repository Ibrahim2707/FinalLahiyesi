using Final.BL.DTOs.Product;
using Final.BL.DTOs.Slider;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstract
{
    public interface IProductService
    {
            Task<Product> CreateAsync(ProductCreateDTO dto);
            Task<Product> UpdateAsync(int id, ProductUpdateDTO dto);
            Task<IEnumerable<ProductGetDTO>> GetAllAsync();
            Task<ProductGetDTO> GetAsync(int id);
            Task DeleteAsync(int id);
    }
}
