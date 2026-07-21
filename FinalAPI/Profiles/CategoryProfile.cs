using AutoMapper;
using Final.BL.DTOs.Category;
using Final.Core.Entities;

namespace FinalAPI.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<Category, CategoryGetDTO>();
        }
    }
}
