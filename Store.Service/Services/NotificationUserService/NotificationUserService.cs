using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.NotificationUserService
{
    public class NotificationUserService : INotificationUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<NotificationUserDto> CreateNotificationUserAsync(NotificationUserDto NotificationUserDto)
        {
            if (NotificationUserDto == null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var Notification = _mapper.Map<NotificationUser>(NotificationUserDto);
                await _unitOfWork.NotificationUser.AddAsync(Notification);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<NotificationUserDto>(Notification);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<NotificationUserDto> DeleteNotificationUserAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var Notification = await _unitOfWork.NotificationUser.GetByIdAsync(Id);
                if (Notification is null)
                    throw new Exception("Id is null");
                await _unitOfWork.NotificationUser.DeleteAsync(Notification);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<NotificationUserDto>(Notification);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<NotificationUserDto>> GetAllNotificationUserAsync()
        {
            var Notification = await _unitOfWork.NotificationUser.GetAllAsync();
            return _mapper.Map<IEnumerable<NotificationUserDto>>(Notification);
        }

        

        public async Task<NotificationUserDto> GetNotificationUserByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var Notification = await _unitOfWork.NotificationUser.GetByIdAsync(Id);
                if (Notification is null)
                    throw new Exception("NotificationUser Not Found");
                return _mapper.Map<NotificationUserDto>(Notification);
            }
            catch (Exception ex)
            {

                throw new Exception("NotificationUser Not Found", ex);
            }
        }

        public async Task<NotificationUserDto> UpdateNotificationUserAsync(int? id, NotificationUserDto NotificationUserDto)
        {
            if (NotificationUserDto == null)
                throw new ArgumentNullException(nameof(NotificationUserDto), "NotificationId cannot be null.");

            try
            {
                var Notification = await _unitOfWork.NotificationUser.GetByIdAsync(id);
                if (Notification == null)
                    throw new Exception($"Notification with Id {id} not found.");
                _mapper.Map(NotificationUserDto, Notification);
                await _unitOfWork.NotificationUser.UpdateAsync(Notification);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<NotificationUserDto>(Notification);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed", ex);
            }


        }

       
    }
}
