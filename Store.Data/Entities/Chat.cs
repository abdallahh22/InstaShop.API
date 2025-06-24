using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public string? WhatsApp_Number { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
