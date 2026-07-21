using AutoMapper;
using Final.BL.DTOs.AboutUs;
using Final.BL.Exceptions;
using Final.BL.ExternalServices.Abstracts;
using Final.BL.Services.Abstract;
using Final.Core.Entities;
using Final.Core.Repositories;

namespace Final.BL.Services.Implements
{
    public class AboutUsService(IAboutUsRepository _repo, IFileService _file, IMapper _mapper) : IAboutUsService
    {
    
        public async Task<AboutUs> CreateAsync(AboutUsCreateDTO dto)
        {
            string ImageURL = null;
            try
            {
                if (dto.Image != null)
                {
                    ImageURL = await _file.SaveImageAsync(dto.Image, "AboutUs");
                }
                var data = _mapper.Map<AboutUs>(dto);
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
                throw new NotFoundException<AboutUs>();

            if (!string.IsNullOrEmpty(data.Image))
            {
                await _file.DeleteImageAsync(data.Image);
            }

            _repo.Remove(data);

            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<AboutUsGetDTO>> GetAllAsync()
        {
            var aboutUs = _repo.GetAll();

            return _mapper.Map<IEnumerable<AboutUsGetDTO>>(aboutUs);
        }

        public async Task<AboutUsGetDTO> GetAsync(int id)
        {
            var aboutUs = await _repo.GetByIdAsync(id);

            if (aboutUs == null)
                throw new NotFoundException<AboutUs>();

            return _mapper.Map<AboutUsGetDTO>(aboutUs);
        }

        public async Task<AboutUs> UpdateAsync(int id, AboutUsUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException<AboutUs>();

            string oldImage = data.Image;

            try
            {
                if (dto.Image != null)
                {
                    if (!string.IsNullOrEmpty(data.Image))
                    {
                        await _file.DeleteImageAsync(data.Image);
                    }

                    data.Image = await _file.SaveImageAsync(dto.Image, "AboutUs");
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
