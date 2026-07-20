using AutoMapper;
using Final.BL.DTOs.Slider;
using Final.Core.Entities;

namespace FinalAPI.Profiles
{
    public class SliderProfile :Profile
    {
        public SliderProfile()
        {
            CreateMap<SliderCreateDTO, Slider>();
            CreateMap<SliderUpdateDTO, Slider>();
            CreateMap<Slider, SliderGetDTO>();
        }
    }
}
