using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.PaymentCardervice
{
    public interface IPaymentCardService
    {
        Task<List<PaymentCardDto>> GetPaymentCardByUserIdAsync(string appUserId);
        Task<PaymentCardDto> CreatePaymentCardAsync(PaymentCardDto PaymentCardDto);
        Task<PaymentCardDto> UpdatePaymentCardAsync(int? id, PaymentCardDto PaymentCardDto);
        Task<PaymentCardDto> DeletePaymentCardAsync(int? Id);
        Task<PaymentCardDto> GetPaymentCardByIdAsync(int? Id);
        Task<IEnumerable<PaymentCardDto>> GetAllPaymentCardAsync();
    }
}
