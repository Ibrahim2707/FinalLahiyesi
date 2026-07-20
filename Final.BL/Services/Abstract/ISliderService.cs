using Final.BL.DTOs.Slider;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstract
{
    public interface ISliderService
    {
        Task<Slider> CreateAsync(SliderCreateDTO dto);
        Task<Slider> UpdateAsync(int id, SliderUpdateDTO dto);
        Task<IEnumerable<SliderGetDTO>> GetAllAsync();
        Task<SliderGetDTO> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
