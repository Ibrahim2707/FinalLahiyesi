using Final.BL.DTOs.Product;
using Final.BL.DTOs.ProductParameter;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstract
{
    public interface IProductParameterService
    {
        Task<ProductParameter> CreateAsync(ProducParameterCreateDTO dto);
        Task<ProductParameter> UpdateAsync(int id, ProductParameterUpdateDTO dto);
        Task<IEnumerable<ProductParameterGetDTO>> GetAllAsync();
        Task<ProductParameterGetDTO> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
