using AutoMapper;
using Final.BL.DTOs.ProductImage;
using Final.BL.Exceptions;
using Final.BL.ExternalServices.Abstracts;
using Final.BL.Services.Abstract;
using Final.Core.Entities;
using Final.Core.Repositories;

namespace Final.BL.Services.Implements
{
    public class ProductImageService(
        IProductImageRepository _repo,
        IFileService _file,
        IMapper _mapper) : IProductImageService
    {
        public async Task<ProductImage> CreateAsync(ProductImageCreateDTO dto)
        {
            string imageUrl = null;

            try
            {
                if (dto.Image != null)
                {
                    imageUrl = await _file.SaveImageAsync(dto.Image, "ProductImages");
                }

                var data = new ProductImage
                {
                    Image = imageUrl,
                    ProductId = dto.ProductId
                };

                await _repo.AddAsync(data);
                await _repo.SaveAsync();

                return data;
            }
            catch
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    await _file.DeleteImageAsync(imageUrl);
                }

                throw;
            }
        }

        public async Task<IEnumerable<ProductImageGetDTO>> GetAllAsync()
        {
            var data = _repo.GetAll();

            return _mapper.Map<IEnumerable<ProductImageGetDTO>>(data);
        }

        public async Task<ProductImageGetDTO> GetAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("ProductImage tapılmadı.");

            return _mapper.Map<ProductImageGetDTO>(data);
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("ProductImage tapılmadı.");

            if (!string.IsNullOrEmpty(data.Image))
            {
                await _file.DeleteImageAsync(data.Image);
            }

            _repo.Remove(data);

            await _repo.SaveAsync();
        }
    }
}