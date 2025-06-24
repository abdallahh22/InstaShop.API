using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.IContactUsService
{
    public interface IContactUsService
    {
        Task<ContactUsDto> CreateContactUsAsync(ContactUsDto ContactUsDto);
        Task<ContactUsDto> UpdateContactUsAsync(int? id, ContactUsDto ContactUsDto);
        Task<ContactUsDto> DeleteContactUsAsync(int? Id);
        Task<ContactUsDto> GetContactUsByIdAsync(int? Id);
        Task<IEnumerable<ContactUsDto>> GetAllContactUsAsync();
    }
}
