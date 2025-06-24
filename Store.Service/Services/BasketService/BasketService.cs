using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BasketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BasketDto> AddProductToBasketAsync(int productId, int quantity)
        {
            var basket = _unitOfWork.Basket.AddProductToBasketAsync(productId, quantity);
            await _unitOfWork.SaveChanges();
            return _mapper.Map<BasketDto>(basket);
        }
        public async Task<BasketDto> CreateBasketAsync(BasketDto BasketDto)
        {
            try
            {
                var basket = _mapper.Map<BasketTemp>(BasketDto);
                await _unitOfWork.Basket.AddAsync(basket);
                await _unitOfWork.SaveChanges();

                return _mapper.Map<BasketDto>(basket);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the basket", ex);
            }
        }
        public async Task<BasketDto> DeleteBasketAsync(int? PlayerId)
        {
            try
            {
                var basket = await _unitOfWork.Basket.GetByIdAsync(PlayerId);
                if (basket == null)
                    throw new KeyNotFoundException("Basket not found");

                _unitOfWork.Basket.DeleteAsync(basket);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<BasketDto>(basket);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the basket", ex);
            }
        }
        public async Task<IEnumerable<BasketDto>> GetAllBasketAsync()
        {
            var baskets = await _unitOfWork.Basket.GetAllAsync();
            return _mapper.Map<IEnumerable<BasketDto>>(baskets);
        }
        public async Task<BasketDto> GetBasketByIdAsync(int? Id)
        {
            try
            {
                var basket = await _unitOfWork.Basket.GetByIdAsync(Id);
                if (basket == null)
                    throw new KeyNotFoundException("Basket not found");

                return _mapper.Map<BasketDto>(basket);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the basket by ID", ex);
            }
        }
        public async Task<BasketDto> RemoveProductFromBasketAsync(int productId)
        {
            var basket = _unitOfWork.Basket.RemoveProductFromBasketAsync(productId);    
            await _unitOfWork.SaveChanges();
            return _mapper.Map<BasketDto>(basket);
        }
        public async Task<BasketDto> UpdateBasketAsync(int? id, BasketDto BasketDto)
        {
            try
            {
                var basket = await _unitOfWork.Basket.GetByIdAsync(id);
                if (basket == null)
                    throw new KeyNotFoundException("Basket not found");

                _mapper.Map(BasketDto, basket);
                _unitOfWork.Basket.UpdateAsync(basket);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<BasketDto>(basket);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the basket", ex);
            }
        }
        public async Task<BasketDto> DeleteBasketByPlayerIdAsync(string playerId)
        {
            var basket = await _unitOfWork.Basket.GetBasketByPlayerIdAsync(playerId);
            if (basket == null)
                throw new KeyNotFoundException("PlayerId is null");
            await _unitOfWork.Basket.DeleteBasketByPlayerIdAsync(playerId);
            await _unitOfWork.SaveChanges();
            return _mapper.Map<BasketDto>(basket);
        }
        public async Task<List<BasketDto>> GetBasketByPlayerIdAsync(string playerId)
        {
            try
            {
                var basketItems = await _unitOfWork.Basket.GetBasketByPlayerIdAsync(playerId);
                if (basketItems == null || !basketItems.Any())
                {
                    throw new Exception("No basket items found for the specified PlayerId.");
                }

                var basketDtos = _mapper.Map<List<BasketDto>>(basketItems);
                return basketDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the basket", ex);
            }
        }
        public async Task<bool> CanProceedToCheckoutAsync(string playerId)
        {
            if (string.IsNullOrEmpty(playerId))
            {
                throw new UnauthorizedAccessException("Please SignIn to continue !");
            }

            var basketItems = await GetBasketByPlayerIdAsync(playerId);
            if (basketItems == null || !basketItems.Any())
            {
                throw new InvalidOperationException("Basket Empty , Please Add Products");
            }

            return true;
        }

    }
}
