using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OfferService
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfferService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OfferDto> CreateOfferAsync(OfferDto OfferDto)
        {
            if (OfferDto == null)
                throw new ArgumentNullException("Offer Not Found");
            try
            {
                var offer = _mapper.Map<Offer>(OfferDto);
                await _unitOfWork.Offers.AddAsync(offer);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OfferDto>(offer);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        
        }

        public async Task<OfferDto> DeleteOfferAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var offer = await _unitOfWork.Offers.GetByIdAsync(Id);
                if (offer is null)
                    throw new Exception("Id is null");
                await _unitOfWork.Offers.DeleteAsync(offer);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OfferDto>(offer);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<OfferDto>> GetAllOfferAsync()
        {
            var Offers = await _unitOfWork.Offers.GetAllAsync();
            return _mapper.Map<IEnumerable<OfferDto>>(Offers);
        }

        public async Task<OfferDto> GetOfferByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var offer = await _unitOfWork.Offers.GetByIdAsync(Id);
                if (offer is null)
                    throw new Exception("offer Not Found");
                return _mapper.Map<OfferDto>(offer);
            }
            catch (Exception ex)
            {

                throw new Exception("Offer Not Found", ex);
            }
        }

        public async Task<OfferDto> UpdateOfferAsync(int? id, OfferDto OfferDto)
        {
            if (OfferDto == null)
                throw new ArgumentNullException(nameof(OfferDto), "OfferDto cannot be null.");
            try
            {
                var offer = await _unitOfWork.Offers.GetByIdAsync(id);
                if (offer == null)
                    throw new Exception($"offer with Id {id} not found.");
                _mapper.Map(OfferDto, offer);
                await _unitOfWork.Offers.UpdateAsync(offer);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<OfferDto>(offer);
            }
            catch (Exception ex)
            {

                throw new Exception("Offer Not Found", ex);
            }
        
        }
    }
}
