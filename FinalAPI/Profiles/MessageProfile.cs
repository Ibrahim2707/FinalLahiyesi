using AutoMapper;
using Final.BL.DTOs.Message;
using Final.BL.DTOs.Slider;
using Final.Core.Entities;

namespace FinalAPI.Profiles
{
    public class MessageProfile:Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageCreateDTO, Message>();
            CreateMap<MessageUpdateDTO, Message>();
            CreateMap<Message, MessageGetDTO>();
        }
    }
}
