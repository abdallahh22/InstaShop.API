using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.NotificationService
{
    public interface INotificationService
    {
        Task<NotificationDto> CreateNotificationAsync(NotificationDto NotificationDto);
        Task<NotificationDto> UpdateNotificationAsync(int? id, NotificationDto NotificationDto);
        Task<NotificationDto> DeleteNotificationAsync(int? Id);
        Task<NotificationDto> GetNotificationByIdAsync(int? Id);
        Task<IEnumerable<NotificationDto>> GetAllNotificationAsync();

    }
}
