using AutoMapper;
using Final.BL.DTOs.AboutUs;
using Final.BL.DTOs.Slider;
using Final.Core.Entities;

namespace FinalAPI.Profiles
{
    public class AboutUsProfile:Profile
    {
        public AboutUsProfile()
        {
            CreateMap<AboutUsCreateDTO, AboutUs>();
            CreateMap<AboutUsUpdateDTO, AboutUs>();
            CreateMap<AboutUs, AboutUsGetDTO>();
        }
    }
}
