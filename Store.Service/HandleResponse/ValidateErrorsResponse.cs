using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.HandleResponse
{
    public class ValidateErrorsResponse : CustomExceptions
    {
        public ValidateErrorsResponse()
            : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
