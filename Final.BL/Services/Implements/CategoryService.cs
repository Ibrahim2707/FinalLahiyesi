using AutoMapper;
using Final.BL.DTOs.Category;
using Final.BL.DTOs.Slider;
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
    public class CategoryService(ICategoryRepository _repo ,IFileService _file,IMapper _mapper):ICategoryService
    {
        public async Task<Category> CreateAsync(CategoryCreateDTO dto)
        {
            string ImageURL = null;
            try
            {
                if (dto.Image != null)
                {
                    ImageURL = await _file.SaveImageAsync(dto.Image, "Category");
                }
                var data = _mapper.Map<Category>(dto);
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
                throw new NotFoundException("Category tapılmadı.");

            if (!string.IsNullOrEmpty(data.Image))
            {
                await _file.DeleteImageAsync(data.Image);
            }

            _repo.Remove(data);

            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<CategoryGetDTO>> GetAllAsync()
        {
            var categories = _repo.GetAll();

            return _mapper.Map<IEnumerable<CategoryGetDTO>>(categories);
        }

        public async Task<CategoryGetDTO> GetAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);

            if (category == null)
                throw new NotFoundException("not found");

            return _mapper.Map<CategoryGetDTO>(category);
        }

        public async Task<Category> UpdateAsync(int id, CategoryUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException<Category>();

            string oldImage = data.Image;

            try
            {
                if (dto.Image != null)
                {
                    if (!string.IsNullOrEmpty(data.Image))
                    {
                        await _file.DeleteImageAsync(data.Image);
                    }

                    data.Image = await _file.SaveImageAsync(dto.Image, "Category");
                }

                data.Title = dto.Title;
                data.SubTitle = dto.SubTitle;

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
