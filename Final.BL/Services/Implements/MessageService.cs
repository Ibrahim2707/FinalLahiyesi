using AutoMapper;
using Final.BL.DTOs.Message;
using Final.BL.Exceptions;
using Final.BL.Services.Abstract;
using Final.Core.Entities;
using Final.Core.Repositories;
using Final.DAL.Repositories;

namespace Final.BL.Services.Implements
{
    public class MessageService(IMessageRepository _repo, IMapper _mapper) : IMessageService
    {
        public async Task<Message> CreateAsync(MessageCreateDTO dto)
        {
            var data = _mapper.Map<Message>(dto);

            await _repo.AddAsync(data);
            await _repo.SaveAsync();

            return data;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("Message tapılmadı.");

            _repo.Remove(data);

            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<MessageGetDTO>> GetAllAsync()
        {
            var messages = _repo.GetAll();

            return _mapper.Map<IEnumerable<MessageGetDTO>>(messages);
        }

        public async Task<MessageGetDTO> GetAsync(int id)
        {
            var message = await _repo.GetByIdAsync(id);

            if (message == null)
                throw new NotFoundException("Message tapılmadı.");

            return _mapper.Map<MessageGetDTO>(message);
        }

        public async Task<Message> UpdateAsync(int id, MessageUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("Message tapılmadı.");

            data.Title = dto.Title;
            data.Email = dto.Email;

            await _repo.SaveAsync();

            return data;
        }
    }
}