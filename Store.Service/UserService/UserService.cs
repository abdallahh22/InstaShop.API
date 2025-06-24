using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using Store.Services.Mapping.UserDto_s;
using Store.Services.TokenService;

namespace Store.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public UserService(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            ITokenService tokenService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
           var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                throw new Exception("User Not Found");
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                throw new Exception("Login Failed");
            return new UserDto
            {
                Email = loginDto.Email,
                UserName = user.FullName,
                Token =  _tokenService.GenerateToken(user)
            };
        }

        public async Task<RegisterResultDto> Register(RegisterDto registerDto)
        {
            var user = await _userManager.FindByEmailAsync(registerDto.Email);
            if (user != null)
                throw new Exception("Email is already taken!");

            var existingUser = await _userManager.FindByNameAsync(registerDto.UserName);
            if (existingUser != null)
                throw new Exception("Username is already taken!");

            var existingUserWithPhone = await _userManager.Users
                      .AnyAsync(u => u.PhoneNumber == registerDto.PhoneNumber);
            if (existingUserWithPhone)
                throw new Exception("Phone number is already taken!");

            var appuser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                FullName = registerDto.UserName
            };

            var result = await _userManager.CreateAsync(appuser, registerDto.Password);
            if (!result.Succeeded)
                throw new Exception("Register Failed");

            return new RegisterResultDto
            {
                Email = appuser.Email,
                UserName = appuser.FullName
            };
        }





        public async Task<bool> DeleteAccount(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found!");
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                throw new Exception("Failed to delete account!");

            return true;
        }

    }
}
