using Microsoft.AspNetCore.Identity;
using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using Store.Services.Mapping.Dto_s.EmailDto;
using Store.Services.Mapping.Dto_s.EmailDto_s;

namespace Store.Services.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public EmailService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task ForgetPassword(ForgetPasswordDto forgetpassword)
        {
            var user = _userManager.FindByEmailAsync(forgetpassword.Email);
            if (user == null)
                throw new Exception("User not found with the provided email address.");


            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user.Result);
                var resetLink = $"https://yourapp.com/reset-password?token={token}&email={forgetpassword.Email}";

                var email = new Email
                {
                    To = forgetpassword.Email,
                    Subject = "Password Reset Request",
                    Body = $"Please click the following link to reset your password: {resetLink}"
                };

                EmailSettings.SendEmail(email);

            }

               return;

        }

        public async Task ResetPassword(ResetPasswordDto resetPasswordDto)
        {
           var user = _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                throw new Exception("User not found with the provided email address.");
            if (user != null)
            {
                var resetResult = await _userManager.ResetPasswordAsync(user.Result, resetPasswordDto.Token, resetPasswordDto.NewPassword);
                if (!resetResult.Succeeded)
                {
                    throw new Exception("Failed to reset password. Please try again.");
                }
            }
            return;


        }
    }
}
