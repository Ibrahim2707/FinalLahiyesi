using Final.BL.DTOs.Blog;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstract
{
    public interface IBlogService
    {
        Task<Blog> CreateAsync(BlogCreateDTO dto);
        Task<Blog>UpdateAsync(int id, BlogUpdateDTO dto);
        Task<IEnumerable<BlogGetDTO>> GetAllAsync();
        Task<BlogGetDTO>GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
