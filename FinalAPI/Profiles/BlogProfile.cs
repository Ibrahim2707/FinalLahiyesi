using AutoMapper;
using Final.BL.DTOs.Blog;
using Final.Core.Entities;

namespace FinalAPI.Profiles
{
    public class BlogProfile: Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogCreateDTO, Blog>();
            CreateMap<BlogUpdateDTO, Blog>();
            CreateMap<Blog, BlogGetDTO>();

        }
       
    }
}
