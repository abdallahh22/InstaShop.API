using Store.Services.Mapping.Dto_s;
using Store.Services.Mapping.UserDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.UserService
{
    public interface IUserService
    {
        Task<RegisterResultDto> Register(RegisterDto registerDto);
        Task<UserDto> Login(LoginDto loginDto);
        Task<bool> DeleteAccount(string userId);
    }
}
