using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<NotificationDto> CreateNotificationAsync(NotificationDto NotificationDto)
        {
            if (NotificationDto == null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var Notification = _mapper.Map<Notification>(NotificationDto);
                await _unitOfWork.Notifications.AddAsync(Notification);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<NotificationDto>(Notification);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<NotificationDto> DeleteNotificationAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var Notification = await _unitOfWork.Notifications.GetByIdAsync(Id);
                if (Notification is null)
                    throw new Exception("Id is null");
                await _unitOfWork.Notifications.DeleteAsync(Notification);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<NotificationDto>(Notification);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<NotificationDto>> GetAllNotificationAsync()
        {
            var Notification = await _unitOfWork.Notifications.GetAllAsync();
            return _mapper.Map<IEnumerable<NotificationDto>>(Notification);
        }


        public async Task<NotificationDto> GetNotificationByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var Notification = await _unitOfWork.Notifications.GetByIdAsync(Id);
                if (Notification is null)
                    throw new Exception("Notification Not Found");
                return _mapper.Map<NotificationDto>(Notification);
            }
            catch (Exception ex)
            {

                throw new Exception("Notification Not Found", ex);
            }
        }

        public async Task<NotificationDto> UpdateNotificationAsync(int? id, NotificationDto NotificationDto)
        {
            if (NotificationDto == null)
                throw new ArgumentNullException(nameof(NotificationDto), "NotificationId cannot be null.");

            try
            {
                var Notification = await _unitOfWork.Notifications.GetByIdAsync(id);
                if (Notification == null)
                    throw new Exception($"Notification with Id {id} not found.");
                _mapper.Map(NotificationDto, Notification);
                await _unitOfWork.Notifications.UpdateAsync(Notification);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<NotificationDto>(Notification);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed", ex);
            }


        }
    }
}
