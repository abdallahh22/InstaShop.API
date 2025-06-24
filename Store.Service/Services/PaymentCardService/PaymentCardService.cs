using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using Store.Services.Services.PaymentCardervice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.PaymentCardService
{
    public class PaymentCardService : IPaymentCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentCardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaymentCardDto> CreatePaymentCardAsync(PaymentCardDto PaymentCardDto)
        {
            if (PaymentCardDto == null)
                throw new ArgumentNullException("Creating Failed");
            try
            {
                var PaymentCard = _mapper.Map<PaymentCard>(PaymentCardDto);
                await _unitOfWork.PaymentCards.AddAsync(PaymentCard);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<PaymentCardDto>(PaymentCard);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }

        }

        public async Task<PaymentCardDto> DeletePaymentCardAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var PaymentCard = await _unitOfWork.PaymentCards.GetByIdAsync(Id);
                if (PaymentCard is null)
                    throw new Exception("Id is null");
                await _unitOfWork.PaymentCards.DeleteAsync(PaymentCard);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<PaymentCardDto>(PaymentCard);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed");
            }
        }

        public async Task<IEnumerable<PaymentCardDto>> GetAllPaymentCardAsync()
        {
            var PaymentCards = await _unitOfWork.PaymentCards.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentCardDto>>(PaymentCards);
        }

        public async Task<PaymentCardDto> GetPaymentCardByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var PaymentCard = await _unitOfWork.PaymentCards.GetByIdAsync(Id);
                if (PaymentCard is null)
                    throw new Exception("PaymentCard Id Not Found");
                return _mapper.Map<PaymentCardDto>(PaymentCard);
            }
            catch (Exception ex)
            {

                throw new Exception("PaymentCard Not Found", ex);
            }
        }

        public async Task<List<PaymentCardDto>> GetPaymentCardByUserIdAsync(string appUserId)
        {
            var card = await _unitOfWork.PaymentCards.GetByUserIdAsync(appUserId);
            return _mapper.Map<List<PaymentCardDto>>(card);
        }

        public async Task<PaymentCardDto> UpdatePaymentCardAsync(int? id, PaymentCardDto PaymentCardDto)
        {
            if (PaymentCardDto == null)
                throw new ArgumentNullException(nameof(PaymentCardDto), "PaymentCardDto cannot be null.");
            try
            {
                var PaymentCard = await _unitOfWork.PaymentCards.GetByIdAsync(id);
                if (PaymentCard == null)
                    throw new Exception($"PaymentCard with Id {id} not found.");
                _mapper.Map(PaymentCardDto, PaymentCard);
                await _unitOfWork.PaymentCards.UpdateAsync(PaymentCard);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<PaymentCardDto>(PaymentCard);
            }
            catch (Exception ex)
            {

                throw new Exception("Updated Failed");
            }
        }
    }
}
