using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.NotificationUserService
{
    public interface INotificationUserService
    {
        Task<NotificationUserDto> CreateNotificationUserAsync(NotificationUserDto NotificationUserDto);
        Task<NotificationUserDto> UpdateNotificationUserAsync(int? id, NotificationUserDto NotificationUserDto);
        Task<NotificationUserDto> DeleteNotificationUserAsync(int? Id);
        Task<NotificationUserDto> GetNotificationUserByIdAsync(int? Id);
        Task<IEnumerable<NotificationUserDto>> GetAllNotificationUserAsync();
    }
}
