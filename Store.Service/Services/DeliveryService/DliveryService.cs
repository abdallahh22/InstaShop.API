using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.DeliveryService
{
    public class DliveryService : IDliveryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DliveryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DriverDto> CreateDriverAsync(DriverDto DriverDto)
        {
            if (DriverDto == null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var driver = _mapper.Map<DeliveryDriver>(DriverDto);
                await _unitOfWork.Delivery.AddAsync(driver);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<DriverDto>(driver);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            } 
        }

        public async Task<DriverDto> DeleteDriverAsync(int? Id)
        {
            if(Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var driver = await _unitOfWork.Delivery.GetByIdAsync(Id);
                if (driver is null)
                    throw new Exception("Id is null");
                await _unitOfWork.Delivery.DeleteAsync(driver);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<DriverDto>(driver);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed",ex);
            }
        }

        public async Task<IEnumerable<DriverDto>> GetAllDriverAsync()
        {
            var driver = await _unitOfWork.Delivery.GetAllAsync();
            return _mapper.Map<IEnumerable<DriverDto>>(driver);
        }


        public async Task<DriverDto> GetDriverByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var driver = await _unitOfWork.Delivery.GetByIdAsync(Id);
                if (driver is null)
                    throw new Exception("Driver Not Found");
                return _mapper.Map<DriverDto>(driver);
            }
            catch (Exception ex)
            {

                throw new Exception("Driver Not Found", ex);
            }
        }

       

        public async Task<DriverDto> UpdateDriverAsync(int? id, DriverDto DriverDto)
        {
            if (DriverDto == null)
                throw new ArgumentNullException(nameof(DriverDto), "DriverId cannot be null.");

            try
            {
                var driver = await _unitOfWork.Delivery.GetByIdAsync(id);
                if (driver == null)
                    throw new Exception($"Driver with Id {id} not found.");
                _mapper.Map(DriverDto, driver);
                await _unitOfWork.Delivery.UpdateAsync(driver);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<DriverDto>(driver);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed", ex);
            }



            

           

        }
    }
}
