using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.IContactUsService
{
    public class ContactUsService : IContactUsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactUsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ContactUsDto> CreateContactUsAsync(ContactUsDto ContactUsDto)
        {
            if (ContactUsDto == null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var ContactUs = _mapper.Map<ContactUs>(ContactUsDto);
                await _unitOfWork.ContactUs.AddAsync(ContactUs);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<ContactUsDto>(ContactUs);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<ContactUsDto> DeleteContactUsAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var ContactUs = await _unitOfWork.ContactUs.GetByIdAsync(Id);
                if (ContactUs is null)
                    throw new Exception("Id is null");
                await _unitOfWork.ContactUs.DeleteAsync(ContactUs);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<ContactUsDto>(ContactUs);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<ContactUsDto>> GetAllContactUsAsync()
        {
            var ContactUs = await _unitOfWork.ContactUs.GetAllAsync();
            return _mapper.Map<IEnumerable<ContactUsDto>>(ContactUs);
        }


        public async Task<ContactUsDto> GetContactUsByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var ContactUs = await _unitOfWork.ContactUs.GetByIdAsync(Id);
                if (ContactUs is null)
                    throw new Exception("ContactUs Not Found");
                return _mapper.Map<ContactUsDto>(ContactUs);
            }
            catch (Exception ex)
            {

                throw new Exception("ContactUs Not Found", ex);
            }
        }

        public async Task<ContactUsDto> UpdateContactUsAsync(int? id, ContactUsDto ContactUsDto)
        {
            if (ContactUsDto == null)
                throw new ArgumentNullException(nameof(ContactUsDto), "ContactUs cannot be null.");

            try
            {
                var ContactUs = await _unitOfWork.ContactUs.GetByIdAsync(id);
                if (ContactUs == null)
                    throw new Exception($"ContactUs with Id {id} not found.");
                _mapper.Map(ContactUsDto, ContactUs);
                await _unitOfWork.ContactUs.UpdateAsync(ContactUs);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<ContactUsDto>(ContactUs);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed", ex);
            }


        }
    }
}
