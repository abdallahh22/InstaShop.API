using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class ChatDto
    {
        public int ChatId { get; set; }
        public string? WhatsApp_Number { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
