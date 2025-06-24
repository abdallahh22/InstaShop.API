using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.IChatService
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ChatDto> CreateChatAsync(ChatDto ChatDto)
        {
            if (ChatDto == null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var Chat = _mapper.Map<Chat>(ChatDto);
                await _unitOfWork.Chat.AddAsync(Chat);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<ChatDto>(Chat);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<ChatDto> DeleteChatAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var Chat = await _unitOfWork.Chat.GetByIdAsync(Id);
                if (Chat is null)
                    throw new Exception("Id is null");
                await _unitOfWork.Chat.DeleteAsync(Chat);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<ChatDto>(Chat);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<ChatDto>> GetAllChatAsync()
        {
            var Chat = await _unitOfWork.Chat.GetAllAsync();
            return _mapper.Map<IEnumerable<ChatDto>>(Chat);
        }


        public async Task<ChatDto> GetChatByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var Chat = await _unitOfWork.Chat.GetByIdAsync(Id);
                if (Chat is null)
                    throw new Exception("Chat Not Found");
                return _mapper.Map<ChatDto>(Chat);
            }
            catch (Exception ex)
            {

                throw new Exception("Chat Not Found", ex);
            }
        }

        public async Task<ChatDto> UpdateChatAsync(int? id, ChatDto ChatDto)
        {
            if (ChatDto == null)
                throw new ArgumentNullException(nameof(ChatDto), "Chat cannot be null.");

            try
            {
                var Chat = await _unitOfWork.Chat.GetByIdAsync(id);
                if (Chat == null)
                    throw new Exception($"Chat with Id {id} not found.");
                _mapper.Map(ChatDto, Chat);
                await _unitOfWork.Chat.UpdateAsync(Chat);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<ChatDto>(Chat);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed", ex);
            }


        }
    }
}
