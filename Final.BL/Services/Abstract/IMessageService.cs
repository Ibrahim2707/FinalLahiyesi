using Final.BL.DTOs.Message;
using Final.BL.DTOs.Slider;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstract
{
    public interface IMessageService
    {
        Task<Message> CreateAsync(MessageCreateDTO dto);
        Task<Message> UpdateAsync(int id, MessageUpdateDTO dto);
        Task<IEnumerable<MessageGetDTO>> GetAllAsync();
        Task<MessageGetDTO> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
