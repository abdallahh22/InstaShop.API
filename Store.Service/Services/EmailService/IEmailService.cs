using Store.Services.Mapping.Dto_s;
using Store.Services.Mapping.Dto_s.EmailDto;
using Store.Services.Mapping.Dto_s.EmailDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.EmailService
{
    public interface IEmailService
    {
        Task ForgetPassword(ForgetPasswordDto forgetpassword);
        Task ResetPassword(ResetPasswordDto resetPasswordDto);
    }
}
