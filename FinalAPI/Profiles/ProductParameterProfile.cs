using AutoMapper;
using Final.BL.DTOs.ProductParameter;
using Final.Core.Entities;

namespace FinalAPI.Profiles
{
    public class ProductParameterProfile : Profile
    {
        public ProductParameterProfile()
        {
            CreateMap<ProducParameterCreateDTO, ProductParameter>();

            CreateMap<ProductParameterUpdateDTO, ProductParameter>();

            CreateMap<ProductParameter, ProductParameterGetDTO>();
        }
    }
}