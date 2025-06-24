using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IPaymentCardRepository : IGenericRepository<PaymentCard>
    {
        Task<IEnumerable<PaymentCard>> GetByUserIdAsync(string userId);

    }
}
