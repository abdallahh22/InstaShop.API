using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.WalletService
{
    public class WalletService : IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WalletService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<WalletDto> CreateWalletAsync(WalletDto WalletDto)
        {
            if (WalletDto == null)
                throw new ArgumentNullException("Wallet Not Found");
            try
            {
                var Wallet = _mapper.Map<Wallet>(WalletDto);
                await _unitOfWork.Wallets.AddAsync(Wallet);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<WalletDto>(Wallet);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<WalletDto> DeleteWalletAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var wallet = await _unitOfWork.Wallets.GetByIdAsync(Id);
                if (wallet is null)
                    throw new Exception("Id is null");
                await _unitOfWork.Wallets.DeleteAsync(wallet);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<WalletDto>(wallet);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<WalletDto>> GetAllWalletAsync()
        {
            var Wallets = await _unitOfWork.Wallets.GetAllAsync();
            return _mapper.Map<IEnumerable<WalletDto>>(Wallets);
        }

        public async Task<WalletDto> GetWalletByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var wallet = await _unitOfWork.Wallets.GetByIdAsync(Id);
                if (wallet is null)
                    throw new Exception("Not Found");
                return _mapper.Map<WalletDto>(wallet);
            }
            catch (Exception ex)
            {

                throw new Exception("Wallet Not Found");
            }
        }

        public async Task<WalletDto> GetWalletByUserIdAsync(string userId)
        {
            if(userId  is null)
                throw new ArgumentNullException("userId Not Found!");
            try
            {
                var wallet = await _unitOfWork.Wallets.GetWalletByUserIdAsync(userId);
                return _mapper.Map<WalletDto>(wallet);
            }
            catch (Exception ex)
            {

                throw new Exception("Wallet User Not Found", ex);
            }
        }

        public async Task<WalletDto> UpdateWalletAsync(int? id, WalletDto WalletDto)
        {
            if (WalletDto == null)
                throw new ArgumentNullException(nameof(WalletDto), "WalletDto cannot be null.");
            try
            {
                var wallet = await _unitOfWork.Wallets.GetByIdAsync(id);
                if (wallet == null)
                    throw new Exception($"wallet with Id {id} not found.");
                _mapper.Map(WalletDto, wallet);
                await _unitOfWork.Wallets.UpdateAsync(wallet);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<WalletDto>(wallet);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed", ex);
            }
        }
    }
}
