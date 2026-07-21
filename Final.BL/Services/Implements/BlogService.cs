using AutoMapper;
using Final.BL.DTOs.Blog;
using Final.BL.DTOs.Category;
using Final.BL.Exceptions;
using Final.BL.ExternalServices.Abstracts;
using Final.BL.Services.Abstract;
using Final.Core.Entities;
using Final.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Implements
{
    public class BlogService(IBlogRepository _repo,IFileService _file,IMapper _mapper):IBlogService
    {
        public  async Task<Blog> CreateAsync(BlogCreateDTO dto)
        {
            string ImageURL = null;
            try
            {

                if (dto.Image != null)
                {
                    ImageURL = await _file.SaveImageAsync(dto.Image, "Blog");
                }
                var data = _mapper.Map<Blog>(dto);
                data.Image = ImageURL;
                await _repo.AddAsync(data);
                await _repo.SaveAsync();
                return data;
            }
            catch 
            {

                await _file.DeleteImageAsync(ImageURL);

                throw;
            }
            
        }
        public async Task DeleteAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("Blog tapılmadı.");

            if (!string.IsNullOrEmpty(data.Image))
            {
                await _file.DeleteImageAsync(data.Image);
            }

            _repo.Remove(data);

            await _repo.SaveAsync();
        }
        public async Task<IEnumerable<BlogGetDTO>> GetAllAsync()
        {
            var blogs = _repo.GetAll();

            return _mapper.Map<IEnumerable<BlogGetDTO>>(blogs);
        }
        public async Task<BlogGetDTO> GetAsync(int id)
        {
            var blog = await _repo.GetByIdAsync(id);

            if (blog == null)
                throw new NotFoundException("not found");

            return _mapper.Map<BlogGetDTO>(blog);
        }
        public async Task<Blog> UpdateAsync(int id, BlogUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException<Blog>();

            string oldImage = data.Image;

            try
            {
                if (dto.Image != null)
                {
                    if (!string.IsNullOrEmpty(data.Image))
                    {
                        await _file.DeleteImageAsync(data.Image);
                    }

                    data.Image = await _file.SaveImageAsync(dto.Image, "Blog");
                }

                data.Title = dto.Title;
                data.Description = dto.Description;
               

                await _repo.SaveAsync();

                return data;
            }
            catch
            {
                if (!string.IsNullOrEmpty(data.Image) && data.Image != oldImage)
                {
                    await _file.DeleteImageAsync(data.Image);
                }

                throw;
            }
        }
    }
}
