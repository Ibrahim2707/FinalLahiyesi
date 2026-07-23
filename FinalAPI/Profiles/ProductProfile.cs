using AutoMapper;
using Final.BL.DTOs.Product;
using Final.BL.DTOs.Slider;
using Final.Core.Entities;

namespace FinalAPI.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<Product, ProductGetDTO>();
        }
    }
}
