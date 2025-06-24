using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class StoreTypeDto
    {

        public int TypeId { get; set; }
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public bool? IsActive { get; set; }
        public string? Icon_path { get; set; }
        public IFormFile Image { get; set; }

    }

}
