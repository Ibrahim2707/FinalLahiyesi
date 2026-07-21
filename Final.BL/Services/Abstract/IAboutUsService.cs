using Final.BL.DTOs.AboutUs;
using Final.BL.DTOs.Slider;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstract
{
    public interface IAboutUsService
    {
        Task<AboutUs> CreateAsync(AboutUsCreateDTO dto);
        Task<AboutUs> UpdateAsync(int id, AboutUsUpdateDTO dto);
        Task<IEnumerable<AboutUsGetDTO>> GetAllAsync();
        Task<AboutUsGetDTO> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
