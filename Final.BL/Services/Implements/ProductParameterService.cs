using AutoMapper;
using Final.BL.DTOs.ProductParameter;
using Final.BL.Exceptions;
using Final.BL.Services.Abstract;
using Final.Core.Entities;
using Final.Core.Repositories;

namespace Final.BL.Services.Implements
{
    internal class ProductParameterService(
        IProductParameterRepository _repo,
        IMapper _mapper) : IProductParameterService
    {
        public async Task<ProductParameter> CreateAsync(ProducParameterCreateDTO dto)
        {
            var data = _mapper.Map<ProductParameter>(dto);

            await _repo.AddAsync(data);
            await _repo.SaveAsync();

            return data;
        }


        public async Task DeleteAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("ProductParameter tapılmadı.");

            _repo.Remove(data);

            await _repo.SaveAsync();
        }


        public async Task<IEnumerable<ProductParameterGetDTO>> GetAllAsync()
        {
            var parameters = _repo.GetAll();

            return _mapper.Map<IEnumerable<ProductParameterGetDTO>>(parameters);
        }


        public async Task<ProductParameterGetDTO> GetAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("ProductParameter tapılmadı.");

            return _mapper.Map<ProductParameterGetDTO>(data);
        }


        public async Task<ProductParameter> UpdateAsync(int id, ProductParameterUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("ProductParameter tapılmadı.");

            data.Name = dto.Name;
            data.Value = dto.Value;

            await _repo.SaveAsync();

            return data;
        }
    }
}