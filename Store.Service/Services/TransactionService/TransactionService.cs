using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TransactionsDto> CreateTransactionAsync(TransactionsDto TransactionsDto)
        {
            if (TransactionsDto == null)
                throw new ArgumentNullException("Creating Failed");
            try
            {
                var transaction = _mapper.Map<Transaction>(TransactionsDto);
                await _unitOfWork.Transactions.AddAsync(transaction);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<TransactionsDto>(transaction);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }

        }

        public async Task<TransactionsDto> DeleteTransactionAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var transaction = await _unitOfWork.Transactions.GetByIdAsync(Id);
                if (transaction is null)
                    throw new Exception("Id is null");
                await _unitOfWork.Transactions.DeleteAsync(transaction);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<TransactionsDto>(transaction);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed");
            }
        }

        public async Task<IEnumerable<TransactionsDto>> GetAllTransactionAsync()
        {
            var transactions = await _unitOfWork.Transactions.GetAllAsync();
            return _mapper.Map<IEnumerable<TransactionsDto>>(transactions);
        }

        public async Task<TransactionsDto> GetTransactionByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var transaction = await _unitOfWork.Transactions.GetByIdAsync(Id);
                if (transaction is null)
                    throw new Exception("Transaction Id Not Found");
                return _mapper.Map<TransactionsDto>(transaction);
            }
            catch (Exception ex)
            {

                throw new Exception("Transaction Not Found", ex);
            }
        }

        public async Task<List<TransactionsDto>> GetTransactionsByCardIdAsync(int paymentCardId)
        {
            var transactions = await _unitOfWork.Transactions.GetTransactionsByCardIdAsync(paymentCardId);
            return _mapper.Map<List<TransactionsDto>>(transactions);
        }

        public async Task<List<TransactionsDto>> GetTransactionsByWalletIdAsync(int walletId)
        {
            var transactions = await _unitOfWork.Transactions.GetTransactionsByWalletIdAsync(walletId);
            return _mapper.Map<List<TransactionsDto>>(transactions);
        }

        public async Task<TransactionsDto> UpdateTransactionAsync(int? id, TransactionsDto TransactionsDto)
        {
            if (TransactionsDto == null)
                throw new ArgumentNullException(nameof(TransactionsDto), "TransactionsDto cannot be null.");
            try
            {
                var transaction = await _unitOfWork.Transactions.GetByIdAsync(id);
                if (transaction == null)
                    throw new Exception($"Transaction with Id {id} not found.");
                _mapper.Map(TransactionsDto, transaction);
                await _unitOfWork.Transactions.UpdateAsync(transaction);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<TransactionsDto>(transaction);
            }
            catch (Exception ex)
            {

                throw new Exception("Updated Failed");
            }
        }
    }
}
