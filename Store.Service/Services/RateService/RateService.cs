using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.RateService
{
    public class RateService : IRateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<RateDto> CreateRateAsync(RateDto RateDto)
        {

            if (RateDto == null)
                throw new ArgumentNullException(nameof(RateDto));
            try
            {
                var rate = _mapper.Map<Rate>(RateDto);
                await _unitOfWork.Rates.AddAsync(rate);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<RateDto>(rate);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<RateDto> DeleteRateAsync(int? Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id), "rate Id cannot be null.");

            var rate = await _unitOfWork.Rates.GetByIdAsync(Id);
            if (rate is null)
                throw new ArgumentException($"rate with Id {Id} not found.");
            await _unitOfWork.Rates.DeleteAsync(rate);
            await _unitOfWork.SaveChanges();
            return _mapper.Map<RateDto>(rate);
        }

        public async Task<IEnumerable<RateDto>> GetAllRateAsync()
        {
            var rate = await _unitOfWork.Rates.GetAllAsync();
            return _mapper.Map<IEnumerable<RateDto>>(rate);
        }

        public async Task<RateDto> GetRateByIdAsync(int? Id)
        {
            var rate = await _unitOfWork.Rates.GetByIdAsync(Id);
            return _mapper.Map<RateDto>(rate);
        }

        public async Task<IEnumerable<RateDto>> GetRatesByUserIdAsync(string userId)
        {
            var rates = await _unitOfWork.Rates.GetRatesByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<RateDto>>(rates);
        }

        public async Task<RateDto> UpdateRateAsync(int? id, RateDto RateDto)
        {
            var rate = await _unitOfWork.Rates.GetByIdAsync(id);
            if (rate is null)
                throw new Exception("rate Not Found");
            _mapper.Map(RateDto, rate);
            await _unitOfWork.Rates.UpdateAsync(rate);
            await _unitOfWork.SaveChanges();
            return _mapper.Map<RateDto>(rate);
        }
    }
}

