using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string? WhatsApp { get; set; }
        public string? Phone { get; set; }
        public string? Name { get; set; }
        public string? Message { get; set; }
    }
}
