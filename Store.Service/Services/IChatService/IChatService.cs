using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.IChatService
{
    public interface IChatService
    {
        Task<ChatDto> CreateChatAsync(ChatDto ChatDto);
        Task<ChatDto> UpdateChatAsync(int? id, ChatDto ChatDto);
        Task<ChatDto> DeleteChatAsync(int? Id);
        Task<ChatDto> GetChatByIdAsync(int? Id);
        Task<IEnumerable<ChatDto>> GetAllChatAsync();
    }
}
