using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class ContactUsDto
    {
        public int ContactUsId { get; set; }
        public string Name { get; set; }
        public string? WhatsApp { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
