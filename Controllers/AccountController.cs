using Microsoft.AspNetCore.Mvc;
using Store.Services.Mapping.Dto_s;
using Store.Services.Mapping.Dto_s.EmailDto;
using Store.Services.Mapping.Dto_s.EmailDto_s;
using Store.Services.Services.EmailService;
using Store.Services.UserService;
using System.Security.Claims;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AccountController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }


        [HttpPost("SignIn")]
        public async Task<ActionResult<UserDto>> SignIn(RegisterDto registerDto)
        {
            var user = await _userService.Register(registerDto);
            if (user is null)
                throw new Exception("Email Already Exist!");
            return Ok(user);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userService.Login(loginDto);
            if (user == null)
                throw new Exception("Login Failed");
            return Ok(user);
        }


        [HttpDelete("delete-account")]
        public async Task<IActionResult> DeleteAccount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return BadRequest(new { Message = "User ID not found" });

            var result = await _userService.DeleteAccount(userId);

            if (!result)
                return BadRequest(new { Message = "Failed to delete account" });

            return Ok(new { Message = "Account deleted successfully" });
        }



        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordDto forgetPasswordDto)
        {
            if (forgetPasswordDto == null || string.IsNullOrEmpty(forgetPasswordDto.Email))
                return BadRequest(new { Message = "Invalid request" });
            try
            {
                await _emailService.ForgetPassword(forgetPasswordDto);
                return Ok(new { Message = "Password reset link sent to your email." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }



        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (resetPasswordDto == null || string.IsNullOrEmpty(resetPasswordDto.Email) || string.IsNullOrEmpty(resetPasswordDto.Token) || string.IsNullOrEmpty(resetPasswordDto.NewPassword))
                return BadRequest(new { Message = "Invalid request" });
            try
            {
                await _emailService.ResetPassword(resetPasswordDto);
                return Ok(new { Message = "Password has been reset successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}
