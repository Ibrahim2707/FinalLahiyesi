using Final.BL.DTOs.Slider;
using Final.BL.ExternalServices.Abstracts;
using Final.BL.Services.Abstract;
using Final.Core.Entities;
using AutoMapper;
using CloudinaryDotNet;
using Final.Core.Repositories;
using Final.BL.Exceptions;

namespace Final.BL.Services.Implements
{
    public class SliderService(ISliderRepository _repo, IFileService _file, IMapper _mapper) : ISliderService
    {
        public async Task<Slider> CreateAsync(SliderCreateDTO dto)
        {
            string ImageURL = null;
            try
            {
                if (dto.Image != null)
                {
                    ImageURL = await _file.SaveImageAsync(dto.Image, "Sliders");
                }
                var data = _mapper.Map<Slider>(dto);
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
                throw new NotFoundException("Slider tapılmadı.");

            if (!string.IsNullOrEmpty(data.Image))
            {
                await _file.DeleteImageAsync(data.Image);
            }

            _repo.Remove(data);

            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<SliderGetDTO>> GetAllAsync()
        {
            var sliders = _repo.GetAll();

            return _mapper.Map<IEnumerable<SliderGetDTO>>(sliders);
        }

        public async Task<SliderGetDTO> GetAsync(int id)
        {
            var slider = await _repo.GetByIdAsync(id);

            if (slider == null)
                throw new NotFoundException("not found");

            return _mapper.Map<SliderGetDTO>(slider);
        }

        public async Task<Slider> UpdateAsync(int id, SliderUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("not found");

            string oldImage = data.Image;

            try
            {
                if (dto.Image != null)
                {
                    if (!string.IsNullOrEmpty(data.Image))
                    {
                        await _file.DeleteImageAsync(data.Image);
                    }

                    data.Image = await _file.SaveImageAsync(dto.Image, "Sliders");
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
