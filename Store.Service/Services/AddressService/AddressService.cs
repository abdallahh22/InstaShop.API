using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<AddressDto> CreateAddressAsync(AddressDto AddressDto)
        {
            try
            {
                var Address = _mapper.Map<Address>(AddressDto);
                await _unitOfWork.Addresses.AddAsync(Address);
                await _unitOfWork.SaveChanges();

                return _mapper.Map<AddressDto>(Address);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the Address", ex);
            }
        }
        public async Task<AddressDto> DeleteAddressAsync(int? PlayerId)
        {
            try
            {
                var Address = await _unitOfWork.Addresses.GetByIdAsync(PlayerId);
                if (Address == null)
                    throw new KeyNotFoundException("Address not found");

                _unitOfWork.Addresses.DeleteAsync(Address);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<AddressDto>(Address);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the Address", ex);
            }
        }
        public async Task<IEnumerable<AddressDto>> GetAllAddressAsync()
        {
            var Addresss = await _unitOfWork.Addresses.GetAllAsync();
            return _mapper.Map<IEnumerable<AddressDto>>(Addresss);
        }
        public async Task<AddressDto> GetAddressByIdAsync(int? Id)
        {
            try
            {
                var Address = await _unitOfWork.Addresses.GetByIdAsync(Id);
                if (Address == null)
                    throw new KeyNotFoundException("Address not found");

                return _mapper.Map<AddressDto>(Address);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the Address by ID", ex);
            }
        }
        public async Task<List<AddressDto>> GetAddressByUserId(string UserId)
        {
            var user = await _unitOfWork.Addresses.GetAddressByUserId(UserId);
            if (user == null)
                throw new KeyNotFoundException("UserId Not Found");
            return _mapper.Map<List<AddressDto>>(user); 
        }
        public async Task<AddressDto> UpdateAddressAsync(int? id, AddressDto AddressDto)
        {
            try
            {
                var address = await _unitOfWork.Addresses.GetByIdAsync(id);
                if (address == null)
                    throw new KeyNotFoundException("Address Not Found");

                _mapper.Map(AddressDto, address);
                _unitOfWork.Addresses.UpdateAsync(address);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<AddressDto>(address);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the address", ex);
            }
        }
    }
}
